using LicenseLib;
using System.Reflection.PortableExecutable;

namespace ToDoApp
{
    public partial class LicenseValidationForm : Form
    {
        public LicenseValidationForm()
        {
            InitializeComponent();
        }

        private async void validateButton_Click(object sender, EventArgs e)
        {
            var isValid = LicenseManager.IsLicenseKeyValid(keyTextBox.Text);

            if (!isValid)
            {
                MessageBox.Show("Geçersiz bir lisans anahtarı girdiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                keyTextBox.Clear();
                keyTextBox.Select();
            }
            else
            {
                var (isActivated, message) = await LicenseManager.TryActivateLicense(keyTextBox.Text);
                if (!isActivated)
                {
                    MessageBox.Show(message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    keyTextBox.Clear();
                    keyTextBox.Select();
                }
                else
                {
                    MessageBox.Show(message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    var form = new MainForm();
                    form.ShowDialog();
                    this.Close();
                }
            }
        }

        private void continueFreeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new MainForm();
            form.ShowDialog();
            this.Close();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void generateLicenseButton_Click(object sender, EventArgs e)
        {
            var (result, isGenerated) = await LicenseService.GetLicenseAsync(LicenseManager.GetMachineId());
            if (isGenerated)
            {
                keyTextBox.Text = result[1..(result.Length - 1)];
                generateLicenseButton.Enabled = false;
            }
            MessageBox.Show(result);
        }
    }
}
