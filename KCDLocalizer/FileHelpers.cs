using System;
using System.IO;

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
    }
}