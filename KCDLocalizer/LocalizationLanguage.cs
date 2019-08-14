namespace NSW.KCDLocalizer
{
    public class LocalizationLanguage
    {
        public string Name { get; }
        public string FileName { get; }

        private LocalizationLanguage(string name, string fileName)
        {
            Name = name;
            FileName = fileName;
        }

        public override string ToString() => Name;

        public static LocalizationLanguage[] Supported => new[]
        {
            new LocalizationLanguage("Chinese", "Chineses_xml.pak"),
            new LocalizationLanguage("Czech", "Czech_xml.pak"),
            new LocalizationLanguage("English", "English_xml.pak"),
            new LocalizationLanguage("Estonian", "Estonian_xml.pak"),
            new LocalizationLanguage("French", "French_xml.pak"),
            new LocalizationLanguage("German", "German_xml.pak"),
            new LocalizationLanguage("Italian", "Italian_xml.pak"),
            new LocalizationLanguage("Polish", "Polish_xml.pak"),
            new LocalizationLanguage("Russian", "Russian_xml.pak"),
            new LocalizationLanguage("Spanish", "Spanish_xml.pak"),
            new LocalizationLanguage("Turkish", "Turkish_xml.pak"),
            new LocalizationLanguage("Ukrainian", "Ukrainian_xml.pak")
        };
    }
}