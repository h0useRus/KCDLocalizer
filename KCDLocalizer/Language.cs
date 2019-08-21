namespace NSW.KCDLocalizer
{
    public class Language
    {
        public string Name { get; }
        public string FileName { get; }

        private Language(string name, string fileName)
        {
            Name = name;
            FileName = fileName;
        }

        public override string ToString() => Name;

        public static Language[] Supported => new[]
        {
            new Language("Chinese", "Chineses_xml.pak"),
            new Language("Czech", "Czech_xml.pak"),
            new Language("English", "English_xml.pak"),
            new Language("Estonian", "Estonian_xml.pak"),
            new Language("French", "French_xml.pak"),
            new Language("German", "German_xml.pak"),
            new Language("Italian", "Italian_xml.pak"),
            new Language("Polish", "Polish_xml.pak"),
            new Language("Russian", "Russian_xml.pak"),
            new Language("Spanish", "Spanish_xml.pak"),
            new Language("Turkish", "Turkish_xml.pak"),
            new Language("Ukrainian", "Ukrainian_xml.pak")
        };
    }
}