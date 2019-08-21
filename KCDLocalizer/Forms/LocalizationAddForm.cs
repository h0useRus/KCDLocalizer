using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NSW.KCDLocalizer.Forms.Results;
using NSW.KCDLocalizer.Properties;

namespace NSW.KCDLocalizer.Forms
{
    public partial class LocalizationAddForm : Form
    {
        private readonly List<Language> _existing;

        public LocalizationAddResult Result { get; set; }

        public LocalizationAddForm(List<Language> existingLanguages)
        {
            InitializeComponent();
            _existing = existingLanguages;
            InitControls();
        }

        private void InitControls()
        {
            cbLanguages.DataSource = Language.Supported.Where(lng => _existing.All(l => l.Name != lng.Name)).ToList();
            if (_existing.Count > 0)
            {
                cbExistingLanguages.DataSource = _existing;
                rbFromExisting.Checked = true;
            }
            else
            {
                rbFromExisting.Enabled =
                    cbExistingLanguages.Enabled = false;
                rbFromPackage.Checked = true;
            }
        }

        private void BtnOpenPackage_Click(object sender, System.EventArgs e)
        {
            tbNewPackage.Text = string.Empty;
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = FileHelpers.FileFilter_Pak;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    if (FileHelpers.TryGetPackageXmlContent(dlg.FileName, out var content))
                    {
                        tbNewPackage.Text = dlg.FileName;
                        cbPakResources.Items.Clear();
                        foreach (var file in content)
                        {
                            cbPakResources.Items.Add(file, true);
                        }
                        rbFromPackage.Checked = true;
                    }
                }
            }
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            var result = new LocalizationAddResult
            {
                Language = (Language)cbLanguages.SelectedItem,
                IncludeTranslation = cbIncludeTranslation.Checked
            };
            if (rbFromExisting.Checked)
            {
                result.IsLocal = true;
                result.PackageFileName = ((Language) cbExistingLanguages.SelectedItem).FileName;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbNewPackage.Text))
                {
                    MessageBox.Show(this, Resources.Package_file_is_not_selected, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                result.PackageFileName = tbNewPackage.Text;

                result.IncludeFiles = new List<string>();
                foreach (var item in cbPakResources.CheckedItems)
                {
                    result.IncludeFiles.Add((string)item);
                }

                if (result.IncludeFiles.Count == 0)
                {
                    MessageBox.Show(this, Resources.Zero_resources_selected_, Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Result = result;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
