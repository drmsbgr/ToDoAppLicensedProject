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
            buyLicenseButton = new Button();
            generateLicenseButton = new Button();
            continueFreeButton = new Button();
            label1 = new Label();
            getMachineIdButton = new Button();
            SuspendLayout();
            // 
            // keyTextBox
            // 
            keyTextBox.Location = new Point(29, 206);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(743, 23);
            keyTextBox.TabIndex = 0;
            // 
            // validateButton
            // 
            validateButton.Font = new Font("Segoe UI", 14F);
            validateButton.Location = new Point(336, 249);
            validateButton.Name = "validateButton";
            validateButton.Size = new Size(105, 49);
            validateButton.TabIndex = 1;
            validateButton.Text = "Doğrula";
            validateButton.UseVisualStyleBackColor = true;
            validateButton.Click += validateButton_Click;
            // 
            // quitButton
            // 
            quitButton.Font = new Font("Segoe UI", 14F);
            quitButton.Location = new Point(678, 394);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(94, 45);
            quitButton.TabIndex = 2;
            quitButton.Text = "Çık";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += quitButton_Click;
            // 
            // buyLicenseButton
            // 
            buyLicenseButton.Font = new Font("Segoe UI", 14F);
            buyLicenseButton.Location = new Point(29, 345);
            buyLicenseButton.Name = "buyLicenseButton";
            buyLicenseButton.Size = new Size(251, 43);
            buyLicenseButton.TabIndex = 4;
            buyLicenseButton.Text = "Lisans Al (WEB)";
            buyLicenseButton.UseVisualStyleBackColor = true;
            buyLicenseButton.Click += buyLicenseButton_Click;
            // 
            // generateLicenseButton
            // 
            generateLicenseButton.Font = new Font("Segoe UI", 14F);
            generateLicenseButton.Location = new Point(29, 394);
            generateLicenseButton.Name = "generateLicenseButton";
            generateLicenseButton.Size = new Size(251, 43);
            generateLicenseButton.TabIndex = 5;
            generateLicenseButton.Text = "Lisans Üret (DEV)";
            generateLicenseButton.UseVisualStyleBackColor = true;
            generateLicenseButton.Click += generateLicenseButton_Click;
            // 
            // continueFreeButton
            // 
            continueFreeButton.Font = new Font("Segoe UI", 14F);
            continueFreeButton.Location = new Point(286, 345);
            continueFreeButton.Name = "continueFreeButton";
            continueFreeButton.Size = new Size(266, 43);
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
            // getMachineIdButton
            // 
            getMachineIdButton.Font = new Font("Segoe UI", 14F);
            getMachineIdButton.Location = new Point(286, 394);
            getMachineIdButton.Name = "getMachineIdButton";
            getMachineIdButton.Size = new Size(266, 43);
            getMachineIdButton.TabIndex = 6;
            getMachineIdButton.Text = "Cihaz Kimliğini Al";
            getMachineIdButton.UseVisualStyleBackColor = true;
            getMachineIdButton.Click += getMachineIdButton_Click;
            // 
            // LicenseValidationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(getMachineIdButton);
            Controls.Add(buyLicenseButton);
            Controls.Add(generateLicenseButton);
            Controls.Add(validateButton);
            Controls.Add(continueFreeButton);
            Controls.Add(label1);
            Controls.Add(quitButton);
            Controls.Add(keyTextBox);
            Name = "LicenseValidationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lisans Doğrulama";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox keyTextBox;
        private Button validateButton;
        private Button quitButton;
        private Button continueFreeButton;
        private Label label1;
        private Button buyLicenseButton;
        private Button generateLicenseButton;
        private Button getMachineIdButton;
    }
}