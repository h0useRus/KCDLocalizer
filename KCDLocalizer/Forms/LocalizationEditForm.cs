using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class LocalizationEditForm : Form
    {
        private readonly Dictionary<string, Localization> _current;
        public Localization Current { get; }

        public LocalizationEditForm(Localization localization, LocalizationLanguage language, Dictionary<string, Localization> source)
        {
            InitializeComponent();
            _current = source;
            Current = localization ?? new Localization();
            gbTranslation.Text = $" Localization {language.Name} Text ";
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
                tbSampleEnglish.Text = Current.SampleEnglish;
                tbSampleTranslation.Text = Current.SampleTranslation;
                tbEnglish.Text = Current.English;
                tbTranslation.Text = Current.Translation;
            }

            tbSampleEnglish.Enabled = btnEnglishCopy.Enabled = !string.IsNullOrWhiteSpace(tbSampleEnglish.Text);
            tbSampleTranslation.Enabled = btnTranslationCopy.Enabled = !string.IsNullOrWhiteSpace(tbSampleTranslation.Text);

            tbSampleEnglish.TextChanged += OnTextBoxTextChanged;
            tbSampleTranslation.TextChanged += OnTextBoxTextChanged;
            tbEnglish.TextChanged += OnTextBoxTextChanged;
            tbTranslation.TextChanged += OnTextBoxTextChanged;

            OnTextBoxTextChanged(this, EventArgs.Empty);
        }

        private void OnKeyTextChanged(object sender, EventArgs e)
        {
            var text = tbKey.Text?.Trim();
            if (string.IsNullOrWhiteSpace(text) || _current.ContainsKey(tbKey.Text))
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
            tbEnglish.BackColor = string.IsNullOrWhiteSpace(tbEnglish.Text) ? Color.LightSalmon : Color.White;
            tbTranslation.BackColor = string.IsNullOrWhiteSpace(tbTranslation.Text) ? Color.LightSalmon : Color.White;
            if(tbSampleEnglish.Enabled)
                tbSampleEnglish.BackColor = Color.White;

            if (tbSampleEnglish.Enabled && !string.Equals(tbSampleEnglish.Text, tbEnglish.Text, StringComparison.Ordinal))
                tbSampleEnglish.BackColor = tbEnglish.BackColor = Color.LightYellow;
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
