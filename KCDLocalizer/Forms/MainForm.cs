﻿using System;
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
            cbHideGood.Enabled =
                btnNew.Enabled =
                    btnAddNew.Enabled =
                        btnSave.Enabled =
                            tbDestinationFile.Enabled =
                                btnOpenDestinationFile.Enabled = Localization.Current.Count > 0;
        }

        private void BindTable()
        {
            gvMain.DataSource = null;
            gvMain.DataSource = (cbHideGood.Checked
                ? Localization.Current.Values.Where(i => i.IsNew || i.IsWarning || i.IsError)
                : Localization.Current.Values).ToList();
            ResizeGridColumns();
        }

        private void ResizeGridColumns()
        {
            colEnglishSrc.Width = colTransaltionDes.Width = (gvMain.Size.Width - colKey.Width - 20)/2;
        }

        private void UpdateStatistics()
        {
            lblSorceRows.Text = Localization.Current.Count.ToString();
            lblTranslated.Text = Localization.Current.Count(i => i.Value.IsGood).ToString();
            lblWariningRows.Text = Localization.Current.Count(i => i.Value.IsWarning).ToString();
            lblErrorRows.Text = Localization.Current.Count(i => i.Value.IsError).ToString();
        }

        #region Src/Des file event handlers
        private async void BtnOpenSourceFile_Click(object sender, System.EventArgs e)
        {
            if (openXmlFile.ShowDialog() == DialogResult.OK)
            {
                tbSourceFile.Text = openXmlFile.FileName;
                tbDestinationFile.Text = null;
                using (var stream = openXmlFile.OpenFile())
                    await Localization.LoadSourceLocalizationsAsync(stream);
                UpdateStatistics();
            }

            BindTable();
            UpdateControls();
        }

        private void TbSourceFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BtnOpenSourceFile_Click(sender, EventArgs.Empty);
        }

        private async void BtnOpenDestinationFile_Click(object sender, System.EventArgs e)
        {
            if (openXmlFile.ShowDialog() == DialogResult.OK)
            {
                tbDestinationFile.Text = openXmlFile.FileName;
                using (var stream = openXmlFile.OpenFile())
                    await Localization.LoadDestinationLocalizationsAsync(stream);
                UpdateStatistics();
            }

            BindTable();
            UpdateControls();
        }

        private void TbDestinationFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BtnOpenDestinationFile_Click(sender, EventArgs.Empty);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (newXmlFile.ShowDialog() == DialogResult.OK)
            {
                tbDestinationFile.Text = newXmlFile.FileName;
                foreach (var localization in Localization.Current)
                {
                    localization.Value.DestinationEnglish = localization.Value.OriginalEnglish;
                    localization.Value.DestinationTranslation = null;
                }
                UpdateStatistics();
            }
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
            if (string.IsNullOrEmpty(tbDestinationFile.Text))
                return;

            var row = gvMain.Rows[e.RowIndex];
            if (row.DataBoundItem is Localization localization)
            {
                var color = Color.White;
                if (localization.IsGood)
                {
                    color = Color.LightGreen;
                }

                if (localization.IsWarning)
                {
                    color = Color.LightYellow;
                }

                if (localization.IsNew)
                {
                    color = Color.LightBlue;
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

            try
            {
                var backupName =
                    $"{Path.GetDirectoryName(tbDestinationFile.Text)}\\{Path.GetFileNameWithoutExtension(tbDestinationFile.Text)}_{DateTime.UtcNow.Ticks}{Path.GetExtension(tbDestinationFile.Text)}";
                File.Move(tbDestinationFile.Text, backupName);
                using (var stream = File.CreateText(tbDestinationFile.Text))
                {
                    await stream.WriteLineAsync("<Table>");
                    foreach (var localization in Localization.Current)
                    {
                        await stream.WriteLineAsync($"<Row><Cell>{localization.Key}</Cell><Cell>{HttpUtility.HtmlEncode(localization.Value.DestinationEnglish ?? string.Empty)}</Cell><Cell>{HttpUtility.HtmlEncode(localization.Value.DestinationTranslation ?? string.Empty)}</Cell></Row>");
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
