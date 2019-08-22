using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSW.KCDLocalizer.Properties;

namespace NSW.KCDLocalizer.Forms
{
    public sealed partial class LocalizationForm : Form
    {
        private Dictionary<string, Localization> _current;
        private Dictionary<string, Localization> _sample;

        public Language Language { get; }
        public string SourceFileName { get; private set; }
        public string OriginalFileName { get; }
        public bool IsChanged { get; set; }

        public LocalizationForm(Language language, string originalFileName)
        {
            InitializeComponent();
            gvMain.AutoGenerateColumns = false;
            OriginalFileName = originalFileName;
            Language = language;
            colTransaltion.HeaderText = Language.Name;
        }

        public async Task LoadAsync(string sourceFileName, bool isNew)
        {
            if (!string.IsNullOrWhiteSpace(sourceFileName))
            {
                SourceFileName = sourceFileName;
                _current = await Localization.LoadAsync(sourceFileName, isNew);
                BindTable();
            }

            UpdateControls();
        }

        private void UpdateControls()
        {
            Text = string.Format(Resources.Title_LocalizationForm, Language, OriginalFileName) + (IsChanged ? " *" : string.Empty);
            cbHideTranslated.Enabled =
                    btnAddNew.Enabled =
                        tbDestinationFile.Enabled =
                                btnOpenDestinationFile.Enabled = _current.Count > 0;
            btnSave.Enabled = IsChanged;
        }

        private void BindTable()
        {
            gvMain.DataSource = null;
            gvMain.DataSource = (cbHideTranslated.Checked
                ? _current.Values.Where(i => !i.IsTranslated)
                : _current.Values).ToList();
            ResizeGridColumns();
        }

        private void ResizeGridColumns()
        {
            colEnglish.Width = colTransaltion.Width = (gvMain.Size.Width - colKey.Width - 20) / 2;
        }

        #region Src/Des file event handlers

        private async void BtnOpenDestinationFile_Click(object sender, System.EventArgs e)
        {
            if (openXmlFile.ShowDialog() == DialogResult.OK)
            {
                var fileName = GetFile(openXmlFile.FileName, OriginalFileName);

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show(this, string.Format(Resources.Error_The_localization_file_not_found, OriginalFileName), Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                _sample = await Localization.LoadAsync(fileName);
                if (_sample != null)
                {
                    tbDestinationFile.Text = openXmlFile.FileName;

                    foreach (var localization in _sample)
                    {
                        if (!_current.ContainsKey(localization.Key) && cbAddMissedKeys.Checked)
                        {
                            _current.Add(localization.Key, localization.Value);
                            IsChanged = true;
                        }

                        if (_current.ContainsKey(localization.Key)
                            && string.IsNullOrEmpty(_current[localization.Key].Translation)
                            && !string.IsNullOrEmpty(localization.Value.Translation)
                            && cbAutoTranslate.Checked)
                        {
                            if (!string.IsNullOrWhiteSpace(localization.Value.English)
                                && string.IsNullOrWhiteSpace(_current[localization.Key].English))
                                _current[localization.Key].English = localization.Value.English;

                            _current[localization.Key].Translation = localization.Value.Translation;
                            IsChanged = true;
                        }
                    }

                    BindTable();
                    UpdateControls();
                }
                else
                {
                    MessageBox.Show(this, string.Format(Resources.Error_Error_reading_localization_file, OriginalFileName), Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetFile(string fileName, string originalFileName)
        {
            var extension = Path.GetExtension(fileName);
            if (string.Equals(extension, ".xml", StringComparison.OrdinalIgnoreCase))
            {
                return fileName;
            }

            if (string.Equals(extension, ".pak", StringComparison.OrdinalIgnoreCase))
            {
                if (FileHelpers.TryExtractTemp(fileName, originalFileName, out var tempFileName))
                {
                    return tempFileName;
                }
            }

            return null;
        }

        private void TbDestinationFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BtnOpenDestinationFile_Click(sender, EventArgs.Empty);
        }
        #endregion

        #region Data view event handlers
        private void GvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && gvMain.Rows[e.RowIndex].DataBoundItem is Localization localization)
            {
                var source = _sample != null && _sample.TryGetValue(localization.Key, out var sample) ? sample : null;
                using (var form = new LocalizationEditForm(localization, source, Language))
                {
                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        if (form.IsChanged)
                            IsChanged = true;
                    }

                    UpdateControls();
                }
            }
        }

        private void GvMain_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = gvMain.Rows[e.RowIndex];
            if (row.DataBoundItem is Localization localization)
            {
                var color = Color.White;
                if (localization.IsTranslated)
                {
                    color = Color.LightGreen;
                }

                if (localization.IsWarning)
                {
                    color = Color.LightYellow;
                }

                if (localization.IsError)
                {
                    color = Color.LightSalmon;
                }

                row.DefaultCellStyle.BackColor = color;
            }
        }
        #endregion

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeGridColumns();
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            using (var form = new LocalizationEditForm(Language, key => !string.IsNullOrWhiteSpace(key) && !_current.ContainsKey(key)))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _current.Add(form.Current.Key, form.Current);
                    BindTable();
                    if (form.IsChanged)
                        IsChanged = true;
                }
                UpdateControls();
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (await Localization.SaveAsync(_current, SourceFileName))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(this, Resources.Error_Failed_on_saving_localization_file, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbHideTranslated_CheckedChanged(object sender, EventArgs e)
        {
            BindTable();
        }

        private void BtnDeleteKey_Click(object sender, EventArgs e)
        {
            var selected = gvMain.SelectedRows[0];
            if (selected.DataBoundItem is Localization localization)
            {
                _current.Remove(localization.Key);
                BindTable();
                IsChanged = true;
            }
            UpdateControls();
        }
    }
}
