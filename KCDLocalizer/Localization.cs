namespace NSW.KCDLocalizer
{
    public class Localization
    {
        public string Key { get; set; }
        public string OriginalEnglish { get; set; }
        public string OriginalTranslation { get; set; }
        public string DestinationEnglish { get; set; }
        public string DestinationTranslation { get; set; }
        public override string ToString() => Key;
    }
}