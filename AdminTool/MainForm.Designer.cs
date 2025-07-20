namespace AdminTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            machineIdTextBox = new TextBox();
            checkBox1 = new CheckBox();
            generateButton = new Button();
            label2 = new Label();
            licenseKeyTextBox = new TextBox();
            copyButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(100, 21);
            label1.TabIndex = 0;
            label1.Text = "Cihaz Kimliği";
            // 
            // machineIdTextBox
            // 
            machineIdTextBox.Location = new Point(134, 11);
            machineIdTextBox.Name = "machineIdTextBox";
            machineIdTextBox.Size = new Size(883, 23);
            machineIdTextBox.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(134, 40);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(108, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Bu cihazı kullan";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // generateButton
            // 
            generateButton.Font = new Font("Segoe UI", 12F);
            generateButton.Location = new Point(861, 40);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(156, 37);
            generateButton.TabIndex = 3;
            generateButton.Text = "Üret";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(481, 161);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 4;
            label2.Text = "Lisans Anahtarı";
            // 
            // licenseKeyTextBox
            // 
            licenseKeyTextBox.Location = new Point(12, 211);
            licenseKeyTextBox.Name = "licenseKeyTextBox";
            licenseKeyTextBox.ReadOnly = true;
            licenseKeyTextBox.Size = new Size(1005, 23);
            licenseKeyTextBox.TabIndex = 5;
            // 
            // copyButton
            // 
            copyButton.Font = new Font("Segoe UI", 12F);
            copyButton.Location = new Point(441, 256);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(156, 37);
            copyButton.TabIndex = 6;
            copyButton.Text = "Kopyala";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 305);
            Controls.Add(copyButton);
            Controls.Add(licenseKeyTextBox);
            Controls.Add(label2);
            Controls.Add(generateButton);
            Controls.Add(checkBox1);
            Controls.Add(machineIdTextBox);
            Controls.Add(label1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox machineIdTextBox;
        private CheckBox checkBox1;
        private Button generateButton;
        private Label label2;
        private TextBox licenseKeyTextBox;
        private Button copyButton;
    }
}
