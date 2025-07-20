using System;
using System.Windows.Forms;
using LicenseLib;

namespace AdminLicenseGenerator
{
    public partial class AdminTool : Form
    {
        public AdminTool()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void useCurrentMachineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useCurrentMachineCheckBox.Checked)
            {
                machineIdTextBox.Text = LicenseManager.GetMachineId();
            }
        }
    }
}
