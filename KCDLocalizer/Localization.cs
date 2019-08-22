using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace NSW.KCDLocalizer
{
    public class Localization
    {
        public Localization(string key)
        {
            Key = key;
        }

        public string Key { get; set; }
        public string English { get; set; }
        public string Translation { get; set; }

        public bool IsTranslated => !IsError && !IsWarning && !string.IsNullOrWhiteSpace(Translation);
        public bool IsWarning => string.IsNullOrWhiteSpace(English);
        public bool IsError => string.IsNullOrWhiteSpace(Key);

        public override string ToString() => Key;

        public string ToXml()
        {
            var sb = new StringBuilder("<Row>");
            sb.Append($"<Cell>{Key}</Cell>");
            sb.Append(string.IsNullOrWhiteSpace(English) ? "<Cell></Cell>" : $"<Cell>{HttpUtility.HtmlEncode(English)}</Cell>");
            sb.Append(string.IsNullOrWhiteSpace(Translation) ? "<Cell></Cell>" : $"<Cell>{HttpUtility.HtmlEncode(Translation)}</Cell>");
            sb.Append("</Row>");
            return sb.ToString();
        }

        public static async Task<Dictionary<string, Localization>> LoadAsync(string fileName, bool ignoreTranslation = false, bool overrideDuplicated = true)
        {
            try
            {
                using (var stream = File.OpenRead(fileName))
                {
                    Log.LogInfo("File", $"Load localization from {fileName}");
                    return await LoadAsync(stream, ignoreTranslation, overrideDuplicated);
                }
            }
            catch(Exception exception)
            {
                Log.LogException(exception);
                return null;
            }
        }

        public static async Task<Dictionary<string, Localization>> LoadAsync(Stream stream, bool ignoreTranslation = false, bool overrideDuplicated = true)
        {
            try
            {
                var result = new Dictionary<string, Localization>(StringComparer.OrdinalIgnoreCase);
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
                                            if (result.ContainsKey(cellId))
                                            {
                                                Log.LogInfo("Key Duplication", cellId);
                                                if (!overrideDuplicated)
                                                {
                                                    cellId += "_duplicate";
                                                }
                                                
                                            }
                                            result[cellId] = new Localization(cellId);
                                            break;
                                        case 1:
                                            result[cellId].English = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            break;
                                        case 2:
                                            if(!ignoreTranslation)
                                                result[cellId].Translation = string.IsNullOrEmpty(value) ? string.Empty : HttpUtility.HtmlDecode(value);
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                }
                return result;
            }
            catch(Exception exception)
            {
                Log.LogException(exception);
                return null;
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
                        await stream.WriteLineAsync(localization.Value.ToXml());
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