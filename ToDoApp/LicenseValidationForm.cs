using LicenseLib;

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
                if (await LicenseHelper.IsServerAvailable(LicenseService.URL) && LicenseHelper.IsInternetAvailable())
                {
                    var (isActivated, message) = await LicenseManager.TryActivateLicenseOnlineAsync(keyTextBox.Text);
                    if (!isActivated)
                    {
                        MessageBox.Show(message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        keyTextBox.Clear();
                        keyTextBox.Select();
                    }
                    else
                        ActivateApp(message);
                }
                else
                {
                    MessageBox.Show("İnternet veya api sunucusu aktif olmadığından çevrimdışı lisans doğrulaması yapılıyor.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LicenseManager.CreateLicenseFile(keyTextBox.Text);
                    ActivateApp("Ürün aktifleştirildi!");
                }
            }
        }

        private void ActivateApp(string message)
        {
            MessageBox.Show(message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            var form = new MainForm(true);
            form.ShowDialog();
            this.Close();
        }

        private void continueFreeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new MainForm(false);
            form.ShowDialog();
            this.Close();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void buyLicenseButton_Click(object sender, EventArgs e)
        {
            if (await LicenseHelper.IsServerAvailable(LicenseService.URL) && LicenseHelper.IsInternetAvailable())
            {
                var (result, isGenerated) = await LicenseService.GetLicenseAsync(LicenseManager.GetMachineId());
                if (isGenerated)
                {
                    keyTextBox.Text = result[1..(result.Length - 1)];
                    buyLicenseButton.Enabled = false;
                    generateLicenseButton.Enabled = false;
                }
                MessageBox.Show(result);
            }
            else
                MessageBox.Show("İnternetiniz veya api sunucusu aktif değil!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void generateLicenseButton_Click(object sender, EventArgs e)
        {
            var key = LicenseManager.GenerateLicenseKey(LicenseManager.GetMachineId());
            keyTextBox.Text = key;
            buyLicenseButton.Enabled = false;
            generateLicenseButton.Enabled = false;
            MessageBox.Show("Anahtar başarılı bir şekilde üretildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void getMachineIdButton_Click(object sender, EventArgs e)
        {
            var machineId = LicenseManager.GetMachineId();
            Clipboard.SetText(machineId);
            MessageBox.Show("Cihaz kimliğiniz üretildi ve kopyalandı. Lütfen lisans sağlayıcısına ulaştırınız.", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
