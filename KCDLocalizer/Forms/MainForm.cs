using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace NSW.KCDLocalizer.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateControls();
        }

        private void UpdateControls()
        {
            Text = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
            lblSorceRows.Text = LocalizationFactory.Statistics.ToString();
            tbDestinationFile.Enabled = btnOpenDestinationFile.Enabled = LocalizationFactory.Statistics.SourceRows > 0;
        }

        private void ResizeGridColumns()
        {
            colEnglishSrc.Width = colTransaltionDes.Width = (gvMain.Size.Width - colKey.Width - gvMain.RowHeadersWidth - 20)/2;
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
            gvMain.AutoGenerateColumns = false;
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

        private void GvMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var row = gvMain.Rows[e.RowIndex];
            if (row.DataBoundItem is Localization localization)
            {
                if(localization.DestinationTranslation == null)
                    row.Cells[2].Style.BackColor = Color.DarkSalmon;

                if (string.IsNullOrWhiteSpace(localization.OriginalEnglish) || string.IsNullOrWhiteSpace(localization.DestinationEnglish))
                {
                    row.Cells[0].Style.BackColor = Color.DarkSalmon;
                    row.Cells[1].Style.BackColor = Color.DarkSalmon;
                    row.Cells[2].Style.BackColor = Color.DarkSalmon;
                }
            }
        }

        private void GvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var key = gvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
            var value = LocalizationFactory.Localizations[key];
            using (var form = new EditForm(value))
            {
                form.ShowDialog();
            }
        }
    }
}
