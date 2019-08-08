using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            gvMain.AutoGenerateColumns = false;
            UpdateControls();
        }

        private void UpdateControls()
        {
            Text = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            lblSorceRows.Text = LocalizationFactory.Statistics.ToString();
            btnSave.Enabled = btnValidate.Enabled = tbDestinationFile.Enabled = btnOpenDestinationFile.Enabled = LocalizationFactory.Statistics.SourceRows > 0;
        }

        private void ResizeGridColumns()
        {
            colEnglishSrc.Width = colTransaltionDes.Width = (gvMain.Size.Width - colKey.Width - 20)/2;
        }

        private async void BtnOpenSourceFile_Click(object sender, System.EventArgs e)
        {
            if (openXmlFile.ShowDialog() == DialogResult.OK)
            {
                tbSourceFile.Text = openXmlFile.FileName;
                using (var stream = openXmlFile.OpenFile())
                    await LocalizationFactory.LoadSourceLocalizationsAsync(stream);
            }

            BindTable();
            UpdateControls();
        }

        private void BindTable()
        {
            gvMain.DataSource = null;
            gvMain.DataSource = LocalizationFactory.Localizations.Values.ToList();
            ResizeGridColumns();
        }

        private async void BtnOpenDestinationFile_Click(object sender, System.EventArgs e)
        {
            if (openXmlFile.ShowDialog() == DialogResult.OK)
            {
                tbDestinationFile.Text = openXmlFile.FileName;
                using (var stream = openXmlFile.OpenFile())
                    await LocalizationFactory.LoadDestinationLocalizationsAsync(stream);
            }

            BindTable();
            UpdateControls();
        }

        private void MainForm_SizeChanged(object sender, System.EventArgs e)
        {
            ResizeGridColumns();
        }

        private void GvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>= 0 && gvMain.Rows[e.RowIndex].DataBoundItem is Localization localization)
            {
                using (var form = new EditForm(localization))
                {
                    form.ShowDialog();
                }
            }
        }

        private void GvMain_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if(string.IsNullOrEmpty(tbDestinationFile.Text))
                return;

            var row = gvMain.Rows[e.RowIndex];
            if (row.DataBoundItem is Localization localization)
            {
                var color = Color.White;
                if (!string.Equals(localization.OriginalEnglish, localization.DestinationEnglish, StringComparison.Ordinal))
                {
                    color = Color.LightYellow;
                }

                if (string.IsNullOrWhiteSpace(localization.DestinationEnglish) || string.IsNullOrWhiteSpace(localization.DestinationTranslation))
                {
                    color = Color.LightSalmon;
                }

                row.DefaultCellStyle.BackColor = color;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var backupName = $"{Path.GetDirectoryName(tbDestinationFile.Text)}\\{Path.GetFileNameWithoutExtension(tbDestinationFile.Text)}_{DateTime.UtcNow.Ticks}{Path.GetExtension(tbDestinationFile.Text)}";
            File.Move(tbDestinationFile.Text, backupName);
            using (var stream = File.CreateText(tbDestinationFile.Text))
            {
                await stream.WriteLineAsync("<Table>");
                foreach (var localization in LocalizationFactory.Localizations)
                {
                    await stream.WriteLineAsync($"<Row><Cell>{localization.Key}</Cell><Cell>{HttpUtility.HtmlEncode(localization.Value.DestinationEnglish ?? string.Empty)}</Cell><Cell>{HttpUtility.HtmlEncode(localization.Value.DestinationTranslation ?? string.Empty)}</Cell></Row>");
                }
                await stream.WriteLineAsync("</Table>");
                await stream.FlushAsync();
            }
        }
    }
}
