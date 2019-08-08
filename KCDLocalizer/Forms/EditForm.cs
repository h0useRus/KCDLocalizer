using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class EditForm : Form
    {
        public EditForm(Localization localization)
        {
            InitializeComponent();
            UpdateControls(localization);
        }

        private void UpdateControls(Localization localization)
        {
            Text = $"Edit {localization.Key}";
            tbKey.Text = localization.Key;
            tbOriginalEnglish.Text = localization.OriginalEnglish;
            tbOriginalTranslation.Text = localization.OriginalTranslation;
            tbDestinationEnglish.Text = localization.DestinationEnglish;
            tbDestinationTranslation.Text = localization.DestinationTranslation;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
