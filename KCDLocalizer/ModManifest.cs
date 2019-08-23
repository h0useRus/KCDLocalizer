using System;
using System.IO;
using System.Xml.Serialization;

namespace NSW.KCDLocalizer
{
    [Serializable]
    [XmlRoot("kcd_mod")]
    public class ModManifest
    {
        private static readonly Lazy<XmlSerializer> _serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(ModManifest)));
        public const string ManifestFileName = "mod.manifest";
        [XmlElement("info")]
        public ModManifestInfo Info { get; set; }
        [XmlArray("supports")]
        [XmlArrayItem("kcd_version", typeof(string))]
        public string[] Supports { get; set; }

        public bool ShouldSerializeInfo() => Info != null;
        public bool ShouldSerializeSupports() => Supports != null && Supports.Length > 0;

        public static ModManifest Load(string modFolder)
        {
            try
            {
                var fileName = Path.Combine(modFolder, ManifestFileName);
                if (File.Exists(fileName))
                {
                    using (var stream = File.OpenRead(fileName))
                    {
                        return _serializer.Value.Deserialize(stream) as ModManifest;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.LogException(exception);
            }

            var pathParts = modFolder.Split('\\');
            return new ModManifest
            {
                Info = new ModManifestInfo
                {
                    Name = pathParts[pathParts.Length - 1],
                    Version = "1.0.0.0",
                    CreatedOn = DateTime.Today.ToString("d")
                }
            };
        }

        public bool Save(string modFolder)
        {
            try
            {
                using (var stream = File.CreateText(Path.Combine(modFolder, ManifestFileName)))
                {
                    var ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);

                    _serializer.Value.Serialize(stream, this, ns);
                    return true;
                }
            }
            catch (Exception exception)
            {
                Log.LogException(exception);
                return false;
            }
        }
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

        public bool ShouldSerializeName() => !string.IsNullOrWhiteSpace(Name);
        public bool ShouldSerializeDescription() => !string.IsNullOrWhiteSpace(Description);
        public bool ShouldSerializeAuthor() => !string.IsNullOrWhiteSpace(Author);
        public bool ShouldSerializeVersion() => !string.IsNullOrWhiteSpace(Version);
        public bool ShouldSerializeCreatedOn() => !string.IsNullOrWhiteSpace(CreatedOn);
        public bool ShouldSerializeDependencies() => Dependencies != null && Dependencies.Length > 0;
    }
}