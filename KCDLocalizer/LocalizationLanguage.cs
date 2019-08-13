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
            new LocalizationLanguage("Chinese", "chineses_xml.pak"),
            new LocalizationLanguage("Czech", "czech_xml.pak"),
            new LocalizationLanguage("English", "english_xml.pak"),
            new LocalizationLanguage("French", "french_xml.pak"),
            new LocalizationLanguage("German", "german_xml.pak"),
            new LocalizationLanguage("Italian", "italian_xml.pak"),
            new LocalizationLanguage("Russian", "russian_xml.pak"),
            new LocalizationLanguage("Spanish", "spanish_xml.pak"),
            new LocalizationLanguage("Turkish", "turkish_xml.pak")
        };
    }
}