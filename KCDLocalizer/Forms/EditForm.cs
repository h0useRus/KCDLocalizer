using System;
using System.Drawing;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class EditForm : Form
    {
        public Localization Current { get; private set; }

        public EditForm(Localization localization)
        {
            InitializeComponent();
            Current = localization ?? new Localization();
            UpdateControls();
        }

        private void UpdateControls()
        {
            if (string.IsNullOrWhiteSpace(Current.Key))
            {
                Text = $"Add new";
                tbKey.TextChanged += OnKeyTextChanged;
            }
            else
            {
                Text = $"Edit '{Current.Key}'";
                tbKey.Text = Current.Key;
                tbKey.ReadOnly = true;
                tbOriginalEnglish.Text = Current.OriginalEnglish;
                tbOriginalTranslation.Text = Current.OriginalTranslation;
                tbDestinationEnglish.Text = Current.DestinationEnglish;
                tbDestinationTranslation.Text = Current.DestinationTranslation;
            }

            tbOriginalEnglish.TextChanged += OnTextBoxTextChanged;
            tbOriginalTranslation.TextChanged += OnTextBoxTextChanged;
            tbDestinationEnglish.TextChanged += OnTextBoxTextChanged;
            tbDestinationTranslation.TextChanged += OnTextBoxTextChanged;

            OnTextBoxTextChanged(this, EventArgs.Empty);
        }

        private void OnKeyTextChanged(object sender, EventArgs e)
        {
            var text = tbKey.Text?.Trim();
            if (string.IsNullOrWhiteSpace(text) || Localization.Current.ContainsKey(tbKey.Text))
            {
                tbKey.BackColor = Color.LightSalmon;
            }
            else
            {
                Current.Key = text;
                tbKey.BackColor = Color.White;
            }
        }

        private void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            tbOriginalTranslation.BackColor = string.IsNullOrWhiteSpace(tbOriginalTranslation.Text) ? Color.LightSalmon : Color.White;

            if (string.Equals(tbOriginalEnglish.Text, tbDestinationEnglish.Text, StringComparison.Ordinal))
                tbOriginalEnglish.BackColor = tbDestinationEnglish.BackColor = Color.LightGreen;
            else
                tbOriginalEnglish.BackColor = tbDestinationEnglish.BackColor = Color.LightYellow;

            tbOriginalEnglish.BackColor = string.IsNullOrWhiteSpace(tbOriginalEnglish.Text) ? Color.LightSalmon : tbOriginalEnglish.BackColor;
            tbDestinationEnglish.BackColor = string.IsNullOrWhiteSpace(tbDestinationEnglish.Text) ? Color.LightSalmon : tbDestinationEnglish.BackColor;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Current.OriginalEnglish = tbOriginalEnglish.Text;
            Current.OriginalTranslation = tbOriginalTranslation.Text;
            Current.DestinationEnglish = tbDestinationEnglish.Text;
            Current.DestinationTranslation = tbDestinationTranslation.Text;
        }

        private void BtnEnglishCopy_Click(object sender, EventArgs e)
        {
            tbDestinationEnglish.Text = tbOriginalEnglish.Text;
        }

        private void BtnTranslationCopy_Click(object sender, EventArgs e)
        {
            tbDestinationTranslation.Text = tbOriginalTranslation.Text;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
