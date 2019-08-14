using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace NSW.KCDLocalizer
{
    public class Localization
    {
        public string Key { get; set; }
        public string OriginalEnglish { get; set; }
        public string OriginalTranslation { get; set; }
        public string DestinationEnglish { get; set; }
        public string DestinationTranslation { get; set; }

        public bool IsTranslated => !string.IsNullOrWhiteSpace(OriginalTranslation) && !IsError;
        public bool IsError => string.IsNullOrWhiteSpace(OriginalEnglish);
        public bool IsWarning => !string.IsNullOrWhiteSpace(DestinationEnglish)
                                 && !string.IsNullOrWhiteSpace(OriginalEnglish)
                                 && !string.IsNullOrWhiteSpace(DestinationEnglish)
                                 && !string.Equals(OriginalEnglish, DestinationEnglish, StringComparison.Ordinal);
        public bool IsNew => string.IsNullOrWhiteSpace(OriginalEnglish) &&
                             !string.IsNullOrWhiteSpace(DestinationEnglish);

        public override string ToString() => Key;

        public static readonly Dictionary<string, Localization> Current = new Dictionary<string, Localization>(StringComparer.OrdinalIgnoreCase);

        public static async Task<bool> LoadSourceLocalizationsAsync(Stream stream, bool isNew)
        {
            try
            {
                Current.Clear();
                using (var reader = XmlReader.Create(stream, new XmlReaderSettings { Async = true }))
                {
                    var cellIndex = 0;
                    var cellStarted = false;
                    var cellId = string.Empty;
                    while (await reader.ReadAsync())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name.Equals("Cell"))
                                {
                                    cellStarted = true;
                                }
                                break;
                            case XmlNodeType.EndElement:
                                if (reader.Name.Equals("Row"))
                                {
                                    cellId = string.Empty;
                                    cellIndex = 0;
                                }
                                else if (reader.Name.Equals("Cell"))
                                {
                                    cellStarted = false;
                                    cellIndex++;
                                }
                                break;
                            case XmlNodeType.Text:
                                if (cellStarted)
                                {
                                    var value = await reader.GetValueAsync();
                                    switch (cellIndex)
                                    {
                                        case 0:
                                            cellId = value;
                                            Current.Add(cellId, new Localization { Key = cellId });
                                            break;
                                        case 1:
                                            Current[cellId].OriginalEnglish = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            break;
                                        case 2:
                                            if(!isNew)
                                                Current[cellId].OriginalTranslation = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                }
                return true;
            }
            catch
            {
                Current.Clear();
                return false;
            }
        }

        public static async Task<bool> LoadDestinationLocalizationsAsync(Stream stream)
        {
            try
            {
                using (var reader = XmlReader.Create(stream, new XmlReaderSettings {Async = true}))
                {
                    foreach (var localization in Current)
                    {
                        localization.Value.DestinationEnglish = null;
                        localization.Value.DestinationTranslation = null;
                    }
                    var cellIndex = 0;
                    var cellStarted = false;
                    var cellId = string.Empty;
                    while (await reader.ReadAsync())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name.Equals("Cell"))
                                {
                                    cellStarted = true;
                                }

                                break;
                            case XmlNodeType.EndElement:
                                if (reader.Name.Equals("Row"))
                                {
                                    cellId = string.Empty;
                                    cellIndex = 0;
                                }
                                else if (reader.Name.Equals("Cell"))
                                {
                                    cellStarted = false;
                                    cellIndex++;
                                }

                                break;
                            case XmlNodeType.Text:
                                if (cellStarted)
                                {
                                    var value = await reader.GetValueAsync();
                                    switch (cellIndex)
                                    {
                                        case 0:
                                            cellId = value;
                                            if (!Current.ContainsKey(cellId))
                                                Current.Add(cellId, new Localization { Key = cellId });
                                            break;
                                        case 1:
                                            Current[cellId].DestinationEnglish = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            break;
                                        case 2:
                                            Current[cellId].DestinationTranslation = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            if (string.IsNullOrWhiteSpace(Current[cellId].OriginalTranslation))
                                                Current[cellId].OriginalTranslation =
                                                    Current[cellId].DestinationTranslation;
                                            break;
                                    }
                                }

                                break;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}