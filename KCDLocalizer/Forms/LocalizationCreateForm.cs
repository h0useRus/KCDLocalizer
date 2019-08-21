using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSW.KCDLocalizer.Forms.Results;
using NSW.KCDLocalizer.Properties;

namespace NSW.KCDLocalizer.Forms
{
    public partial class LocalizationCreateForm : Form
    {
        private readonly LocalizationAddResult _result;
        public string PakFileName { get; }
        public LocalizationCreateForm(LocalizationAddResult result, string destinationFolder)
        {
            InitializeComponent();
            _result = result;

            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            PakFileName = Path.Combine(destinationFolder, result.Language.FileName);
        }

        private void LocalizationCreateForm_Shown(object sender, System.EventArgs e)
        {
            DoWorkAsync();
        }

        private async Task DoWorkAsync()
        {
            try
            {
                using (var newPakFile = ZipFile.Open(PakFileName, ZipArchiveMode.Create))
                using (var pakFile = ZipFile.OpenRead(_result.PackageFileName))
                {
                    foreach (var entry in pakFile.Entries)
                    {
                        if (_result.IncludeFiles != null && !_result.IncludeFiles.Contains(entry.Name))
                        {
                            continue;
                        }

                        var tempFile = Path.GetTempFileName();
                        entry.ExtractToFile(tempFile, true);
                        Application.DoEvents();
                        if (!_result.IncludeTranslation)
                        {
                            var content = await Localization.LoadAsync(tempFile, true);
                            Application.DoEvents();
                            if (content != null)
                            {
                                await Localization.SaveAsync(content, tempFile);
                                Application.DoEvents();
                            }
                        }

                        newPakFile.CreateEntryFromFile(tempFile, entry.FullName);
                        Application.DoEvents();
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show(this, $"Cann't create package {_result.Language.FileName}!", Resources.Caption_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }
    }
}
