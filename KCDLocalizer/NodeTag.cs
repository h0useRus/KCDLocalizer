﻿using System.Collections.Generic;

namespace NSW.KCDLocalizer
{
    public enum NodeType
    {
        Root = 0,
        Package,
        Folder,
        File
    }

    public class NodeTag
    {
        public bool IsNew { get; set; }
        public NodeType Type { get; set; }
        public List<string> Sources { get; } = new List<string>();
        public LocalizationLanguage Localization { get; set; }

        public static NodeTag Root => new NodeTag { Type = NodeType.Root };
        public static NodeTag Folder => new NodeTag { Type = NodeType.Folder };

        public static NodeTag CreatePackage(string fileName, LocalizationLanguage localization)
        {
            var tag = new NodeTag { Type = NodeType.Package, Localization = localization};
            tag.Sources.Add(fileName);
            return tag;
        }

        public static NodeTag CreateFile(string fileName, LocalizationLanguage localization, bool isNew)
        {
            var tag = new NodeTag { Type = NodeType.File, Localization = localization, IsNew = isNew};
            tag.Sources.Add(fileName);
            return tag;
        }
    }
}