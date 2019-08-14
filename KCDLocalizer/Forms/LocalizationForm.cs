using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NSW.KCDLocalizer.Properties;

namespace NSW.KCDLocalizer.Forms
{
    public partial class LocalizationForm : Form
    {
        private readonly bool _isNew;
        private readonly string _originalFileName;
        private readonly LocalizationLanguage _language;
        private readonly Dictionary<string, Localization> _current = new Dictionary<string, Localization>(StringComparer.OrdinalIgnoreCase);

        public string SourceFileName { get; }
        public bool IsChanged { get; set; }

        public LocalizationForm(string sourceFile, bool isNew, LocalizationLanguage language, string originalFileName)
        {
            InitializeComponent();
            gvMain.AutoGenerateColumns = false;
            SourceFileName = sourceFile;
            _isNew = isNew;
            _language = language;
            _originalFileName = originalFileName;
            LoadSourceFile();
        }

        private async void LoadSourceFile()
        {
            if(!string.IsNullOrWhiteSpace(SourceFileName))
                using (var stream = File.OpenRead(SourceFileName))
                {
                    await Localization.LoadAsync(stream, _current, _isNew);
                    BindTable();
                }
            UpdateControls();
        }

        private void UpdateControls()
        {
            Text = $"{_language.Name} Localization {_originalFileName}";
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
            colEnglishSrc.Width = colTransaltionDes.Width = (gvMain.Size.Width - colKey.Width - 20) / 2;
        }

        #region Src/Des file event handlers

        private async void BtnOpenDestinationFile_Click(object sender, System.EventArgs e)
        {
            if (openXmlFile.ShowDialog() == DialogResult.OK)
            {
                var fileName = GetFile(openXmlFile.FileName, _originalFileName);

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show(this, string.Format(Resources.Error_The_localization_file_not_found, _originalFileName), Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tbDestinationFile.Text = openXmlFile.FileName;

                using (var stream = File.OpenRead(fileName))
                    if (await Localization.LoadSampleAsync(stream, _current))
                    {
                        IsChanged = true;
                    }
                    else
                    {
                        MessageBox.Show(this, string.Format(Resources.Error_Error_reading_localization_file, _originalFileName), Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

            BindTable();
            UpdateControls();
        }

        private string GetFile(string fileName, string originalFileName)
        {
            var extension = Path.GetExtension(fileName);
            if(string.Equals(extension,".xml", StringComparison.OrdinalIgnoreCase))
            {
                return fileName;
            }

            if(string.Equals(extension,".pak", StringComparison.OrdinalIgnoreCase))
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
                using (var form = new LocalizationEditForm(localization, _language, _current))
                {
                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        IsChanged = true;
                    }
                    UpdateControls();
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

                if (localization.IsNew)
                {
                    color = Color.LightSkyBlue;
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
            using (var form = new LocalizationEditForm(new Localization(), _language, _current))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _current.Add(form.Current.Key, form.Current);
                    BindTable();
                }
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
    }
}
