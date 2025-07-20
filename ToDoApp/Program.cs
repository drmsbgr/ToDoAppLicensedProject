using LicenseLib;

namespace ToDoApp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        if (LicenseManager.IsLicenseValid())
            Application.Run(new MainForm(true));
        else
            Application.Run(new LicenseValidationForm());
    }
}