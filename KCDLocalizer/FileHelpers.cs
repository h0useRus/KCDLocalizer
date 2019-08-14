using System;
using System.IO;
using System.IO.Compression;

namespace NSW.KCDLocalizer
{
    public static class FileHelpers
    {
        public static bool TryCreateBackup(string originalFileName, out string backupFileName)
        {
            backupFileName = $"{Path.GetDirectoryName(originalFileName)}\\{Path.GetFileNameWithoutExtension(originalFileName)}_{DateTime.UtcNow.Ticks}.bak";
            try
            {
                File.Move(originalFileName, backupFileName);
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
    }
}