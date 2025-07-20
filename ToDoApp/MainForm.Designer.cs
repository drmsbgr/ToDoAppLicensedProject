namespace ToDoApp;

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
        jobList = new ListView();
        columnJobName = new ColumnHeader();
        columnIsJobDone = new ColumnHeader();
        jobTitleTextBox = new TextBox();
        jobDescTextBox = new TextBox();
        isJobDoneCheckbox = new CheckBox();
        label1 = new Label();
        label2 = new Label();
        createNewJobButton = new Button();
        overwriteJobButton = new Button();
        deleteSelectedButton = new Button();
        backButton = new Button();
        SuspendLayout();
        // 
        // jobList
        // 
        jobList.Columns.AddRange(new ColumnHeader[] { columnJobName, columnIsJobDone });
        jobList.Font = new Font("Segoe UI", 10F);
        jobList.FullRowSelect = true;
        jobList.Location = new Point(12, 12);
        jobList.MultiSelect = false;
        jobList.Name = "jobList";
        jobList.RightToLeft = RightToLeft.No;
        jobList.Size = new Size(277, 537);
        jobList.TabIndex = 0;
        jobList.TileSize = new Size(1, 1);
        jobList.UseCompatibleStateImageBehavior = false;
        jobList.View = View.Details;
        jobList.SelectedIndexChanged += jobList_SelectedIndexChanged;
        // 
        // columnJobName
        // 
        columnJobName.Text = "İş Başlığı";
        columnJobName.Width = 100;
        // 
        // columnIsJobDone
        // 
        columnIsJobDone.Text = "Durum";
        columnIsJobDone.TextAlign = HorizontalAlignment.Center;
        columnIsJobDone.Width = 100;
        // 
        // jobTitleTextBox
        // 
        jobTitleTextBox.Location = new Point(440, 163);
        jobTitleTextBox.Name = "jobTitleTextBox";
        jobTitleTextBox.Size = new Size(238, 23);
        jobTitleTextBox.TabIndex = 1;
        // 
        // jobDescTextBox
        // 
        jobDescTextBox.Location = new Point(393, 229);
        jobDescTextBox.Multiline = true;
        jobDescTextBox.Name = "jobDescTextBox";
        jobDescTextBox.Size = new Size(322, 134);
        jobDescTextBox.TabIndex = 2;
        // 
        // isJobDoneCheckbox
        // 
        isJobDoneCheckbox.AutoSize = true;
        isJobDoneCheckbox.Location = new Point(482, 391);
        isJobDoneCheckbox.Name = "isJobDoneCheckbox";
        isJobDoneCheckbox.Size = new Size(156, 19);
        isJobDoneCheckbox.TabIndex = 3;
        isJobDoneCheckbox.Text = "İş Tamamlanma Durumu";
        isJobDoneCheckbox.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(539, 131);
        label1.Name = "label1";
        label1.Size = new Size(36, 15);
        label1.TabIndex = 4;
        label1.Text = "İş Adı";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(523, 200);
        label2.Name = "label2";
        label2.Size = new Size(67, 15);
        label2.TabIndex = 5;
        label2.Text = "İş Açıklama";
        // 
        // createNewJobButton
        // 
        createNewJobButton.Font = new Font("Segoe UI", 12F);
        createNewJobButton.Location = new Point(346, 455);
        createNewJobButton.Name = "createNewJobButton";
        createNewJobButton.Size = new Size(117, 45);
        createNewJobButton.TabIndex = 6;
        createNewJobButton.Text = "Yeni İş Kaydet";
        createNewJobButton.UseVisualStyleBackColor = true;
        createNewJobButton.Click += createNewJobButton_Click;
        // 
        // overwriteJobButton
        // 
        overwriteJobButton.Font = new Font("Segoe UI", 12F);
        overwriteJobButton.Location = new Point(491, 455);
        overwriteJobButton.Name = "overwriteJobButton";
        overwriteJobButton.Size = new Size(125, 45);
        overwriteJobButton.TabIndex = 7;
        overwriteJobButton.Text = "Üzerine Kaydet";
        overwriteJobButton.UseVisualStyleBackColor = true;
        overwriteJobButton.Click += overwriteJobButton_Click;
        // 
        // deleteSelectedButton
        // 
        deleteSelectedButton.Font = new Font("Segoe UI", 12F);
        deleteSelectedButton.Location = new Point(637, 455);
        deleteSelectedButton.Name = "deleteSelectedButton";
        deleteSelectedButton.Size = new Size(138, 45);
        deleteSelectedButton.TabIndex = 8;
        deleteSelectedButton.Text = "Seçileni Kaldır";
        deleteSelectedButton.UseVisualStyleBackColor = true;
        deleteSelectedButton.Click += deleteSelectedButton_Click;
        // 
        // backButton
        // 
        backButton.Font = new Font("Segoe UI", 12F);
        backButton.Location = new Point(777, 12);
        backButton.Name = "backButton";
        backButton.Size = new Size(95, 45);
        backButton.TabIndex = 9;
        backButton.Text = "Geri Dön";
        backButton.UseVisualStyleBackColor = true;
        backButton.Click += backButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 561);
        Controls.Add(backButton);
        Controls.Add(deleteSelectedButton);
        Controls.Add(overwriteJobButton);
        Controls.Add(createNewJobButton);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(isJobDoneCheckbox);
        Controls.Add(jobDescTextBox);
        Controls.Add(jobTitleTextBox);
        Controls.Add(jobList);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Ana Sayfa";
        Load += MainForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListView jobList;
    private ColumnHeader columnJobName;
    private ColumnHeader columnIsJobDone;
    private TextBox jobTitleTextBox;
    private TextBox jobDescTextBox;
    private CheckBox isJobDoneCheckbox;
    private Label label1;
    private Label label2;
    private Button createNewJobButton;
    private Button overwriteJobButton;
    private Button deleteSelectedButton;
    private Button backButton;
}
