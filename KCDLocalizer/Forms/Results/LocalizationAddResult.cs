using System.Collections.Generic;

namespace NSW.KCDLocalizer.Forms.Results
{
    public class LocalizationAddResult
    {
        public Language Language { get; set; }
        public string PackageFileName { get; set; }
        public bool IsLocal { get; set; }
        public List<string> IncludeFiles;
        public bool IncludeTranslation { get; set; }
    }
}