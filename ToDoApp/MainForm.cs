using LicenseLib;
using ToDoApp.Entities;
using ToDoApp.Helpers;

namespace ToDoApp;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        RefreshJobs();
    }

    private void RefreshJobs()
    {
        var jobs = JobManager.LoadJobs();

        jobList.Items.Clear();
        jobList.Refresh();
        jobs.ForEach(x => jobList.Items.Add(new ListViewItem([x.Title!, x.GetDoneState()]) { Tag = x }));
        jobList.Refresh();
    }

    private void createNewJobButton_Click(object sender, EventArgs e)
    {
        if (!LicenseManager.IsActivated && JobManager.LoadJobs().Count ==5)
        {
            MessageBox.Show("Ürün aktifleþtirilmediði için daha fazla iþ ekleyemezsiniz.", "Uyarý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        if (string.IsNullOrEmpty(jobTitleTextBox.Text) || string.IsNullOrEmpty(jobDescTextBox.Text))
        {
            MessageBox.Show("Boþ alan býrakmayýnýz.", "Uyarý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var job = new Job()
        {
            Title = jobTitleTextBox.Text,
            Desc = jobDescTextBox.Text,
            IsDone = isJobDoneCheckbox.Checked
        };

        JobManager.AddRecord(job);
        RefreshJobs();
        jobTitleTextBox.Clear();
        jobDescTextBox.Clear();
        isJobDoneCheckbox.Checked = false;
    }

    private void overwriteJobButton_Click(object sender, EventArgs e)
    {
        if (jobList.SelectedItems.Count == 0) return;

        var selectedItem = jobList.SelectedItems[0];

        if (selectedItem is null) return;

        if (selectedItem.Tag is not Job data) return;

        if (string.IsNullOrEmpty(jobTitleTextBox.Text) || string.IsNullOrEmpty(jobDescTextBox.Text))
        {
            MessageBox.Show("Boþ alan býrakmayýnýz.", "Uyarý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var jobs = JobManager.LoadJobs();

        var targetJob = jobs.Find(x => x.Id == data.Id);

        if(targetJob is null) return;

        targetJob.Title = jobTitleTextBox.Text;
        targetJob.Desc = jobDescTextBox.Text;
        targetJob.IsDone = isJobDoneCheckbox.Checked;

        JobManager.Save(jobs);
        RefreshJobs();
    }

    private void deleteSelectedButton_Click(object sender, EventArgs e)
    {
        if (jobList.SelectedItems.Count == 0) return;

        var selectedItem = jobList.SelectedItems[0];

        if (selectedItem is null) return;

        if (selectedItem.Tag is not Job data) return;

        JobManager.RemoveRecord(data.Id);
        RefreshJobs();
    }

    private void jobList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (jobList.SelectedItems.Count == 0)
        {
            jobTitleTextBox.Text = string.Empty;
            jobDescTextBox.Text = string.Empty;
            isJobDoneCheckbox.Checked = false;
            return;
        }

        var selectedItem = jobList.SelectedItems[0];
        if (selectedItem == null) return;

        if (selectedItem.Tag is not Job data) return;

        jobTitleTextBox.Text = data.Title;
        jobDescTextBox.Text = data.Desc;
        isJobDoneCheckbox.Checked = data.IsDone;
    }
}
