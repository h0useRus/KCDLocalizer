using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class LocalizationForm : Form
    {
        private readonly string _sourceFileName;
        private readonly bool _isNew;
        private readonly string _originalFileName;
        private readonly LocalizationLanguage _language;

        public LocalizationForm(string sourceFile, bool isNew, LocalizationLanguage language, string originalFileName)
        {
            InitializeComponent();
            gvMain.AutoGenerateColumns = false;
            _sourceFileName = sourceFile;
            _isNew = isNew;
            _language = language;
            _originalFileName = originalFileName;
            LoadSourceFile();
        }

        private async void LoadSourceFile()
        {
            if(!string.IsNullOrWhiteSpace(_sourceFileName))
                using (var stream = File.OpenRead(_sourceFileName))
                {
                    await Localization.LoadSourceLocalizationsAsync(stream, _isNew);
                    UpdateStatistics();
                    BindTable();
                }
            UpdateControls();
        }

        private void UpdateControls()
        {
            Text = $"{_language.Name} Localization {_originalFileName}";
            cbHideTranslated.Enabled =
                    btnAddNew.Enabled =
                        btnSave.Enabled =
                            tbDestinationFile.Enabled =
                                btnOpenDestinationFile.Enabled = Localization.Current.Count > 0;
        }

        private void BindTable()
        {
            gvMain.DataSource = null;
            gvMain.DataSource = (cbHideTranslated.Checked
                ? Localization.Current.Values.Where(i => !i.IsTranslated)
                : Localization.Current.Values).ToList();
            ResizeGridColumns();
        }

        private void ResizeGridColumns()
        {
            colEnglishSrc.Width = colTransaltionDes.Width = (gvMain.Size.Width - colKey.Width - 20) / 2;
        }

        private void UpdateStatistics()
        {
            lblSorceRows.Text = Localization.Current.Count.ToString();
            lblErrorRows.Text = Localization.Current.Count(i => i.Value.IsError).ToString();
        }

        #region Src/Des file event handlers

        private async void BtnOpenDestinationFile_Click(object sender, System.EventArgs e)
        {
            if (openXmlFile.ShowDialog() == DialogResult.OK)
            {
                var fileName = GetFile(openXmlFile.FileName, _originalFileName);

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    MessageBox.Show(this, "The localization file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tbDestinationFile.Text = openXmlFile.FileName;

                using (var stream = File.OpenRead(fileName))
                    await Localization.LoadDestinationLocalizationsAsync(stream);
                UpdateStatistics();
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
            {
                using (var form = new EditForm(localization))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        UpdateStatistics();
                    }
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
            using (var form = new EditForm(new Localization()))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Localization.Current.Add(form.Current.Key, form.Current);
                    BindTable();
                    UpdateStatistics();
                }
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            mainProgress.Maximum = Localization.Current.Count;
            mainProgress.Step = 0;
            mainProgress.Visible = true;

            if (FileHelpers.TryCreateBackup(tbDestinationFile.Text, out _))
                try
                {
                    using (var stream = File.CreateText(tbDestinationFile.Text))
                    {
                        await stream.WriteLineAsync("<Table>");
                        foreach (var localization in Localization.Current)
                        {
                            await stream.WriteLineAsync(
                                $"<Row><Cell>{localization.Key}</Cell><Cell>{HttpUtility.HtmlEncode(localization.Value.DestinationEnglish ?? string.Empty)}</Cell><Cell>{HttpUtility.HtmlEncode(localization.Value.DestinationTranslation ?? string.Empty)}</Cell></Row>");
                            mainProgress.Step++;
                            Application.DoEvents();
                        }

                        mainProgress.Visible = false;
                        await stream.WriteLineAsync("</Table>");
                        await stream.FlushAsync();
                    }
                }
                finally
                {
                    mainProgress.Visible = false;
                }
        }

        private void CbHideTranslated_CheckedChanged(object sender, EventArgs e)
        {
            BindTable();
        }
    }
}
