namespace LicenseLib;

public static class LicenseService
{
    private static readonly HttpClient httpClient = new();
    private const string URL = "http://localhost:5243/api";

    public static async Task<(string, bool)> GetLicenseAsync(string machineId)
    {
        try
        {
            string url = $"{URL}/createlic?machineId={machineId}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            var message = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return (message, true);
            else
                return (message, false);
        }
        catch (Exception ex)
        {
            return ($"İstisna: {ex.Message}", false);
        }
    }

    public static async Task<(bool, string)> ActivateLicenseAsync(string machineId, string key)
    {
        try
        {
            string url = $"{URL}/validatelic?machineId={machineId}&key={key}";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            var message = await response.Content.ReadAsStringAsync();

            return (response.IsSuccessStatusCode, message);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
