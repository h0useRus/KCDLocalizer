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
        public string English { get; set; }
        public string Translation { get; set; }
        public string SampleEnglish { get; set; }
        public string SampleTranslation { get; set; }

        public bool IsTranslated => !string.IsNullOrWhiteSpace(Translation) && !IsError;
        public bool IsError => string.IsNullOrWhiteSpace(English);
        public bool IsWarning => !string.IsNullOrWhiteSpace(SampleEnglish)
                                 && !string.IsNullOrWhiteSpace(English)
                                 && !string.IsNullOrWhiteSpace(SampleEnglish)
                                 && !string.Equals(English, SampleEnglish, StringComparison.Ordinal);
        public bool IsNew => string.IsNullOrWhiteSpace(English) &&
                             !string.IsNullOrWhiteSpace(SampleEnglish);

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
                                            Current[cellId].English = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            break;
                                        case 2:
                                            if(!isNew)
                                                Current[cellId].Translation = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
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
                        localization.Value.SampleEnglish = null;
                        localization.Value.SampleTranslation = null;
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
                                            Current[cellId].SampleEnglish = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            if (string.IsNullOrWhiteSpace(Current[cellId].English))
                                                Current[cellId].English =
                                                    Current[cellId].SampleEnglish;
                                            break;
                                        case 2:
                                            Current[cellId].SampleTranslation = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            if (string.IsNullOrWhiteSpace(Current[cellId].Translation))
                                                Current[cellId].Translation =
                                                    Current[cellId].SampleTranslation;
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