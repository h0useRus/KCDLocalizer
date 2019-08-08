using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace NSW.KCDLocalizer
{
    public static class LocalizationFactory
    {
        public static readonly Dictionary<string, Localization> Localizations = new Dictionary<string, Localization>(StringComparer.OrdinalIgnoreCase);
        public static LocalizationStat Statistics { get; set; } = new LocalizationStat();

        public static async Task<bool> LoadSourceLocalizationsAsync(Stream stream)
        {
            try
            {
                Localizations.Clear();
                Statistics = new LocalizationStat();
                using (var reader = XmlReader.Create(stream, new XmlReaderSettings { Async = true }))
                {
                    var rowIndex = 0;
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
                                    rowIndex++;
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
                                            Localizations.Add(cellId, new Localization { Key = cellId });
                                            break;
                                        case 1:
                                            Localizations[cellId].OriginalEnglish = HttpUtility.HtmlDecode(value);
                                            break;
                                        case 2:
                                            Localizations[cellId].OriginalTranslation = HttpUtility.HtmlDecode(value);
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                    Statistics.SourceRows = rowIndex;
                    Statistics.MissedKeys = rowIndex;
                }
                return true;
            }
            catch
            {
                Localizations.Clear();
                Statistics = new LocalizationStat();
                return false;
            }
        }

        public static async Task<bool> LoadDestinationLocalizationsAsync(Stream stream)
        {
            try
            {
                using (var reader = XmlReader.Create(stream, new XmlReaderSettings {Async = true}))
                {
                    var rowIndex = 0;
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
                                    rowIndex++;
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
                                            if (!Localizations.ContainsKey(cellId))
                                            {
                                                Localizations.Add(cellId, new Localization {Key = cellId});
                                                Statistics.NewKeys++;
                                            }
                                            else
                                            {
                                                Statistics.MissedKeys--;
                                            }

                                            break;
                                        case 1:
                                            Localizations[cellId].DestinationEnglish = HttpUtility.HtmlDecode(value);
                                            if (!string.Equals(Localizations[cellId].OriginalEnglish, Localizations[cellId].DestinationEnglish))
                                                Statistics.NotMatchedEnglish++;
                                            break;
                                        case 2:
                                            Localizations[cellId].DestinationTranslation = HttpUtility.HtmlDecode(value);
                                            break;
                                    }
                                }

                                break;
                        }
                    }
                    Statistics.DestinationRows = rowIndex;
                }
                return true;
            }
            catch
            {
                Statistics.DestinationRows = Statistics.NewKeys = Statistics.NotMatchedEnglish = 0;
                Statistics.MissedKeys = Statistics.SourceRows;
                return false;
            }
        }
    }
}