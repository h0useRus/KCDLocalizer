using System;
using System.Drawing;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class EditForm : Form
    {
        public Localization Localization { get; }

        public EditForm(Localization localization)
        {
            InitializeComponent();
            Localization = localization;
            UpdateControls();
        }

        private void UpdateControls()
        {
            Text = $"Edit {Localization.Key}";
            tbKey.Text = Localization.Key;
            tbOriginalEnglish.Text = Localization.OriginalEnglish;
            tbOriginalTranslation.Text = Localization.OriginalTranslation;
            tbDestinationEnglish.Text = Localization.DestinationEnglish;
            tbDestinationTranslation.Text = Localization.DestinationTranslation;

            tbOriginalEnglish.TextChanged += OnTextBoxTextChanged;
            tbOriginalTranslation.TextChanged += OnTextBoxTextChanged;
            tbDestinationEnglish.TextChanged += OnTextBoxTextChanged;
            tbDestinationTranslation.TextChanged += OnTextBoxTextChanged;

            OnTextBoxTextChanged(this, EventArgs.Empty);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            if (string.Equals(tbOriginalEnglish.Text, tbDestinationEnglish.Text))
            {
                tbOriginalEnglish.BackColor = tbDestinationEnglish.BackColor = Color.LightGreen;
            }
            else
            {
                tbDestinationEnglish.BackColor = Color.LightYellow;

                tbOriginalEnglish.BackColor = string.IsNullOrWhiteSpace(tbOriginalEnglish.Text) ? Color.LightSalmon : tbOriginalEnglish.BackColor;
                tbDestinationEnglish.BackColor = string.IsNullOrWhiteSpace(tbDestinationEnglish.Text) ? Color.LightSalmon : tbDestinationEnglish.BackColor;
            }

            tbOriginalTranslation.BackColor = string.IsNullOrWhiteSpace(tbOriginalTranslation.Text) ? Color.LightSalmon : Color.White;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Localization.OriginalEnglish = tbOriginalEnglish.Text;
            Localization.OriginalTranslation = tbOriginalTranslation.Text;
            Localization.DestinationEnglish = tbDestinationEnglish.Text;
            Localization.DestinationTranslation = tbDestinationTranslation.Text;
            BtnClose_Click(sender, e);
        }
    }
}
