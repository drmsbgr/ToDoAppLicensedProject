using LicenseLib;

namespace AdminTool
{
    public partial class MainForm : Form
    {
        private string cachedMachineId = string.Empty;
        public MainForm()
        {
            InitializeComponent();
            copyButton.Hide();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(machineIdTextBox.Text))
            {
                MessageBox.Show("Cihaz kimliði giriniz!", "Uyarý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var licenseKey = LicenseManager.GenerateLicenseKey(machineIdTextBox.Text);
                licenseKeyTextBox.Text = licenseKey;
                copyButton.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (string.IsNullOrEmpty(cachedMachineId))
                {
                    var machineId = LicenseManager.GetMachineId();
                    cachedMachineId = machineId;
                }
                machineIdTextBox.Text = cachedMachineId;
            }
            else
            {
                machineIdTextBox.Text = string.Empty;
                machineIdTextBox.Select();
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(licenseKeyTextBox.Text);
        }
    }
}
