using System;
using System.Xml.Serialization;

namespace NSW.KCDLocalizer
{
    [Serializable]
    [XmlRoot("kcd_mod")]
    public class ModManifest
    {
        [XmlElement("info")]
        public ModManifestInfo Info { get; set; }
        [XmlArray("supports")]
        [XmlArrayItem("kcd_version", typeof(string))]
        public string[] Supports { get; set; }
    }

    [Serializable]
    public class ModManifestInfo
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("author")]
        public string Author { get; set; }
        [XmlElement("version")]
        public string Version { get; set; }
        [XmlElement("created_on")]
        public string CreatedOn { get; set; }
        [XmlArray("dependencies")]
        [XmlArrayItem("req_mod", typeof(string))]
        public string[] Dependencies { get; set; }
    }
}