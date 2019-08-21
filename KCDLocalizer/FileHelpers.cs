using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using NSW.KCDLocalizer.Forms.Results;

namespace NSW.KCDLocalizer
{
    public static class FileHelpers
    {
        public const string FileFilter_Pak = "Package file|*.pak";
        public const string FileFilter_Xml = "XML file|*.xml";


        public static bool TryCreateBackup(string originalFileName, bool move, out string backupFileName)
        {
            backupFileName = $"{Path.GetDirectoryName(originalFileName)}\\{Path.GetFileNameWithoutExtension(originalFileName)}_{DateTime.UtcNow.Ticks}.bak";
            try
            {
                if(move)
                    File.Move(originalFileName, backupFileName);
                else
                    File.Copy(originalFileName, backupFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool TryExtractTemp(string pakFileName, string fileName, out string outputFileName)
        {
            outputFileName = null;
            try
            {
                using (var pakFile = ZipFile.OpenRead(pakFileName))
                {
                    var entry = pakFile.GetEntry(fileName);
                    if (entry != null)
                    {
                        var tempFile = Path.GetTempFileName();
                        entry.ExtractToFile(tempFile, true);
                        outputFileName = tempFile;
                    }
                }
                return !string.IsNullOrWhiteSpace(outputFileName);
            }
            catch
            {
                return false;
            }
        }

        public static bool TryGetPackageXmlContent(string pakFileName, out List<string> content)
        {
            content = new List<string>();
            try
            {
                using (var pakFile = ZipFile.OpenRead(pakFileName))
                {
                    foreach (var entry in pakFile.Entries)
                    {
                        if (string.Equals(Path.GetExtension(entry.Name), ".xml", StringComparison.OrdinalIgnoreCase))
                        {
                            content.Add(entry.Name);
                        }
                    }
                }

                return content.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}