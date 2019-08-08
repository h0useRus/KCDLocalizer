namespace NSW.KCDLocalizer
{
    public class LocalizationStat
    {
        public int SourceRows { get; set; }
        public int DestinationRows { get; set; }
        public int MissedKeys { get; set; }
        public int NewKeys { get; set; }
        public int NotMatchedEnglish { get; set; }

        public override string ToString()
        {
            return $"Src: {SourceRows} | Des: {DestinationRows} | Missed: {MissedKeys} | New: {NewKeys} | Not matched: {NotMatchedEnglish}";
        }
    }
}