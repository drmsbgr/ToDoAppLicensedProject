namespace ToDoApp
{
    partial class LicenseValidationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            keyTextBox = new MaskedTextBox();
            validateButton = new Button();
            quitButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            continueFreeButton = new Button();
            label1 = new Label();
            generateLicenseButton = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // keyTextBox
            // 
            keyTextBox.Location = new Point(115, 206);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(555, 23);
            keyTextBox.TabIndex = 0;
            // 
            // validateButton
            // 
            validateButton.Font = new Font("Segoe UI", 14F);
            validateButton.Location = new Point(8, 8);
            validateButton.Name = "validateButton";
            validateButton.Size = new Size(125, 73);
            validateButton.TabIndex = 1;
            validateButton.Text = "Doğrula";
            validateButton.UseVisualStyleBackColor = true;
            validateButton.Click += validateButton_Click;
            // 
            // quitButton
            // 
            quitButton.Font = new Font("Segoe UI", 14F);
            quitButton.Location = new Point(553, 8);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(125, 73);
            quitButton.TabIndex = 2;
            quitButton.Text = "Çık";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += quitButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(validateButton);
            flowLayoutPanel1.Controls.Add(generateLicenseButton);
            flowLayoutPanel1.Controls.Add(continueFreeButton);
            flowLayoutPanel1.Controls.Add(quitButton);
            flowLayoutPanel1.Location = new Point(44, 357);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(687, 92);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // continueFreeButton
            // 
            continueFreeButton.Font = new Font("Segoe UI", 14F);
            continueFreeButton.Location = new Point(270, 8);
            continueFreeButton.Name = "continueFreeButton";
            continueFreeButton.Size = new Size(277, 73);
            continueFreeButton.TabIndex = 3;
            continueFreeButton.Text = "Ücretsiz Versiyonla Devam Et";
            continueFreeButton.UseVisualStyleBackColor = true;
            continueFreeButton.Click += continueFreeButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(255, 107);
            label1.Name = "label1";
            label1.Size = new Size(267, 32);
            label1.TabIndex = 4;
            label1.Text = "Lisans Anahtarını Giriniz";
            // 
            // generateLicenseButton
            // 
            generateLicenseButton.Font = new Font("Segoe UI", 14F);
            generateLicenseButton.Location = new Point(139, 8);
            generateLicenseButton.Name = "generateLicenseButton";
            generateLicenseButton.Size = new Size(125, 73);
            generateLicenseButton.TabIndex = 4;
            generateLicenseButton.Text = "Lisans Al";
            generateLicenseButton.UseVisualStyleBackColor = true;
            generateLicenseButton.Click += generateLicenseButton_Click;
            // 
            // LicenseValidationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(keyTextBox);
            Name = "LicenseValidationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lisans Doğrulama";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox keyTextBox;
        private Button validateButton;
        private Button quitButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button continueFreeButton;
        private Label label1;
        private Button generateLicenseButton;
    }
}