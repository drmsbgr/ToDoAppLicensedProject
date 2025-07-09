using System.Security.Cryptography;
using System.Text;

namespace LicenseLib;

public static class LicenseManager
{
    private const string LicenseFileName = "license.lic";
    private const string EncryptionKey = "TODOLICENSENCRYP"; // 16 karakter (AES)
    private const string SecretKey = "todolistappverysecretKEY!";

    public static bool IsActivated => IsLicenseValid();

    public static bool IsLicenseValid()
    {
        if (!File.Exists(LicenseFileName))
            return false;
        try
        {
            var encrypted = File.ReadAllText(LicenseFileName);
            var decrypted = Decrypt(encrypted);
            var parts = decrypted.Split('|');

            string licenseKey = parts[0];
            string machineId = parts[1];

            return machineId == GetMachineId() && IsLicenseKeyValid(licenseKey);
        }
        catch
        {
            return false;
        }
    }

    public static async Task<(bool, string)> TryActivateLicenseAsync(string licenseKey)
    {
        if (!IsLicenseKeyValid(licenseKey))
            return (false, "Lisans anahtarı geçersiz!");

        var (result, message) = await LicenseService.ActivateLicenseAsync(GetMachineId(), licenseKey);

        if (!result)
            return (false, message);

        string content = $"{licenseKey}|{GetMachineId()}";
        string encrypted = Encrypt(content);

        File.WriteAllText(LicenseFileName, encrypted);
        return (true, message);
    }

    public static string GetMachineId()
    {
        // Sadece volume serial number kullanılıyor
        var drive = DriveInfo.GetDrives()[0];
        string volumeSerial = drive.VolumeLabel + drive.Name;
        return ComputeSHA256(volumeSerial);
    }

    public static bool IsLicenseKeyValid(string key)
    {
        try
        {
            byte[] keyBytes = Convert.FromBase64String(key);
            string decoded = Encoding.UTF8.GetString(keyBytes);

            var parts = decoded.Split('|'); // Format: MachineIdHash|Timestamp|HMAC
            if (parts.Length != 3)
                return false;

            string machineIdHash = parts[0];
            string timestamp = parts[1];
            string hmac = parts[2];

            // Uygulamanın çalıştığı makine ID’si
            string localMachineId = GetMachineId();
            string localMachineIdHash = ComputeSHA256(localMachineId);

            if (localMachineIdHash != machineIdHash)
                return false;

            // HMAC doğrulama
            string message = $"{machineIdHash}|{timestamp}";
            string computedHmac = ComputeHMACSHA256(message, SecretKey);

            return computedHmac == hmac;
        }
        catch
        {
            return false;
        }
    }

    private static string ComputeSHA256(string input)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(bytes);
    }

    private static string ComputeHMACSHA256(string message, string secret)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
        byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        return Convert.ToBase64String(hash);
    }

    public static string GenerateLicenseKey(string machineId)
    {
        string machineIdHash = ComputeSHA256(machineId);
        string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        string message = $"{machineIdHash}|{timestamp}";
        string hmac = ComputeHMACSHA256(message, SecretKey);

        string full = $"{machineIdHash}|{timestamp}|{hmac}";
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(full));
    }

    private static string Encrypt(string plainText)
    {
        byte[] key = Encoding.UTF8.GetBytes(EncryptionKey);
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = key; // Demo amaçlı, gerçek uygulamada IV farklı olmalı

        ICryptoTransform encryptor = aes.CreateEncryptor();
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encrypted = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        return Convert.ToBase64String(encrypted);
    }

    private static string Decrypt(string encryptedText)
    {
        byte[] key = Encoding.UTF8.GetBytes(EncryptionKey);
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = key;

        ICryptoTransform decryptor = aes.CreateDecryptor();
        byte[] cipherBytes = Convert.FromBase64String(encryptedText);
        byte[] decrypted = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
        return Encoding.UTF8.GetString(decrypted);
    }
}
