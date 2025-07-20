namespace AdminLicenseGenerator
{
    partial class AdminTool
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
            this.machineIdTextBox = new System.Windows.Forms.TextBox();
            this.licenseKeyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.useCurrentMachineCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // machineIdTextBox
            // 
            this.machineIdTextBox.Location = new System.Drawing.Point(97, 45);
            this.machineIdTextBox.Name = "machineIdTextBox";
            this.machineIdTextBox.Size = new System.Drawing.Size(691, 20);
            this.machineIdTextBox.TabIndex = 0;
            // 
            // licenseKeyTextBox
            // 
            this.licenseKeyTextBox.Location = new System.Drawing.Point(97, 143);
            this.licenseKeyTextBox.Name = "licenseKeyTextBox";
            this.licenseKeyTextBox.Size = new System.Drawing.Size(691, 20);
            this.licenseKeyTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cihaz Kimliği";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lisans Anahtarı";
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.generateButton.Location = new System.Drawing.Point(618, 80);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(170, 48);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Üret";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // useCurrentMachineCheckBox
            // 
            this.useCurrentMachineCheckBox.AutoSize = true;
            this.useCurrentMachineCheckBox.Location = new System.Drawing.Point(97, 71);
            this.useCurrentMachineCheckBox.Name = "useCurrentMachineCheckBox";
            this.useCurrentMachineCheckBox.Size = new System.Drawing.Size(100, 17);
            this.useCurrentMachineCheckBox.TabIndex = 5;
            this.useCurrentMachineCheckBox.Text = "Bu cihazı kullan";
            this.useCurrentMachineCheckBox.UseVisualStyleBackColor = true;
            this.useCurrentMachineCheckBox.CheckedChanged += new System.EventHandler(this.useCurrentMachineCheckBox_CheckedChanged);
            // 
            // AdminTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 227);
            this.Controls.Add(this.useCurrentMachineCheckBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.licenseKeyTextBox);
            this.Controls.Add(this.machineIdTextBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "AdminTool";
            this.Text = "AdminTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox machineIdTextBox;
        private System.Windows.Forms.TextBox licenseKeyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.CheckBox useCurrentMachineCheckBox;
    }
}

