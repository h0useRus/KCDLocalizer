using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class LocalizationEditForm : Form
    {
        public Localization Current { get; }
        public Localization Source { get; }
        public Language Language { get; }

        public bool IsChanged { get; set; }

        public Func<string, bool> CheckKeyFunc { get; } = s => false;

        public LocalizationEditForm(Language language, Func<string, bool> checkKeyFunc)
        {
            Language = language;
            CheckKeyFunc = checkKeyFunc;
        }

        public LocalizationEditForm(Localization current, Localization source, Language language)
        {
            InitializeComponent();
            Current = current;
            Source = source;
            Language = language;
            InitControls();
        }

        private void InitControls()
        {
            gbTranslation.Text = $" {Language} Text ";

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
            }

            if (Current != null)
            {
                tbEnglish.Text = Current.English;
                tbTranslation.Text = Current.Translation;

                tbEnglish.TextChanged += OnTextBoxTextChanged;
                tbTranslation.TextChanged += OnTextBoxTextChanged;
            }

            if (Source != null)
            {
                tbSampleEnglish.Text = Source.English;
                tbSampleTranslation.Text = Source.Translation;

                tbSampleEnglish.TextChanged += OnTextBoxTextChanged;
                tbSampleTranslation.TextChanged += OnTextBoxTextChanged;

            }
            else
            {
                tbSampleEnglish.Enabled =
                    btnEnglishCopy.Enabled =
                        tbSampleTranslation.Enabled =
                            btnTranslationCopy.Enabled = false;
            }

            UpdateControls();
        }

        private void UpdateControls()
        {
            tbEnglish.BackColor = string.IsNullOrWhiteSpace(tbEnglish.Text) ? Color.LightSalmon : Color.White;
            tbTranslation.BackColor = string.IsNullOrWhiteSpace(tbTranslation.Text) ? Color.LightSalmon : Color.White;
            if(tbSampleEnglish.Enabled)
                tbSampleEnglish.BackColor = Color.White;

            if (tbSampleEnglish.Enabled && !string.Equals(tbSampleEnglish.Text, tbEnglish.Text, StringComparison.Ordinal))
                tbSampleEnglish.BackColor = tbEnglish.BackColor = Color.LightYellow;

            btnSave.Enabled = IsChanged;
        }

        private void OnKeyTextChanged(object sender, EventArgs e)
        {
            var text = tbKey.Text?.Trim();
            if (CheckKeyFunc(text))
            {
                tbKey.BackColor = Color.LightSalmon;
                IsChanged = false;
            }
            else
            {
                Current.Key = text;
                tbKey.BackColor = Color.White;
                IsChanged = true;
            }

            UpdateControls();
        }

        private void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb && (tb.Name=="tbEnglish" || tb.Name=="tbTranslation"))
                IsChanged = true;

            UpdateControls();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Current.English = tbEnglish.Text;
            Current.Translation = tbTranslation.Text;
        }

        private void BtnEnglishCopy_Click(object sender, EventArgs e)
        {
            tbEnglish.Text = tbSampleEnglish.Text;
        }

        private void BtnTranslationCopy_Click(object sender, EventArgs e)
        {
            tbTranslation.Text = tbSampleTranslation.Text;
        }

        private void BtnFromEnglishToTranslation_Click(object sender, EventArgs e)
        {
            tbTranslation.Text = tbEnglish.Text;
        }
    }
}
