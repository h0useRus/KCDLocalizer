using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class SelectLanguageForm : Form
    {
        public SelectLanguageForm(IReadOnlyCollection<LocalizationLanguage> existingLanguages)
        {
            InitializeComponent();

            foreach (var language in LocalizationLanguage.Supported)
            {
                if(existingLanguages!=null && existingLanguages.Any(l=>string.Equals(l.Name, language.Name )))
                   continue;
                cbLanguages.Items.Add(language);
            }

            if (cbLanguages.Items.Count > 0)
                cbLanguages.SelectedIndex = 0;
        }

        public LocalizationLanguage SelectedLanguage => cbLanguages.SelectedItem as LocalizationLanguage;
    }
}
