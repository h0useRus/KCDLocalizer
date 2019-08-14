using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
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

        public static async Task<bool> LoadAsync(Stream stream, Dictionary<string, Localization> source, bool isNew)
        {
            try
            {
                source.Clear();
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
                                            source.Add(cellId, new Localization { Key = cellId });
                                            break;
                                        case 1:
                                            source[cellId].English = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            break;
                                        case 2:
                                            if(!isNew)
                                                source[cellId].Translation = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
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
                source.Clear();
                return false;
            }
        }

        public static async Task<bool> LoadSampleAsync(Stream stream, Dictionary<string, Localization> source)
        {
            try
            {
                using (var reader = XmlReader.Create(stream, new XmlReaderSettings {Async = true}))
                {
                    foreach (var localization in source)
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
                                            if (!source.ContainsKey(cellId))
                                                source.Add(cellId, new Localization { Key = cellId });
                                            break;
                                        case 1:
                                            source[cellId].SampleEnglish = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            if (string.IsNullOrWhiteSpace(source[cellId].English))
                                                source[cellId].English =
                                                    source[cellId].SampleEnglish;
                                            break;
                                        case 2:
                                            source[cellId].SampleTranslation = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            if (string.IsNullOrWhiteSpace(source[cellId].Translation))
                                                source[cellId].Translation =
                                                    source[cellId].SampleTranslation;
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

        public static async Task<bool> SaveAsync(Dictionary<string, Localization> source, string fileName)
        {
            try
            {
                using (var stream = File.CreateText(fileName))
                {
                    await stream.WriteLineAsync("<Table>");
                    foreach (var localization in source)
                    {
                        await stream.WriteLineAsync(
                            $"<Row><Cell>{localization.Key}</Cell><Cell>{HttpUtility.HtmlEncode(localization.Value.English ?? string.Empty)}</Cell><Cell>{HttpUtility.HtmlEncode(localization.Value.Translation ?? string.Empty)}</Cell></Row>");
                    }
                    Application.DoEvents();
                    await stream.WriteLineAsync("</Table>");
                    await stream.FlushAsync();
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