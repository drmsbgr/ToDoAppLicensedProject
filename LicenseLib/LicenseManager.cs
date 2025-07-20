using System.Security.Cryptography;
using System.Text;
using System.Management;

namespace LicenseLib;

public static class LicenseManager
{
    private static readonly string LicenseFileName = "license.lic";
    private static readonly string EncryptionKey = "TODOLICENSENCRYP"; // 16 karakter (AES)
    private static readonly string SecretKey = "todolistappverysecretKEY!";

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

    public static async Task<(bool, string)> TryActivateLicenseOnlineAsync(string licenseKey)
    {
        if (!IsLicenseKeyValid(licenseKey))
            return (false, "Lisans anahtarı geçersiz!");

        var (result, message) = await LicenseService.ActivateLicenseAsync(GetMachineId(), licenseKey);

        if (!result)
            return (false, message);
        CreateLicenseFile(licenseKey);
        return (true, message);
    }

    public static void CreateLicenseFile(string licenseKey)
    {
        string content = $"{licenseKey}|{GetMachineId()}";
        string encrypted = Encrypt(content);

        File.WriteAllText(LicenseFileName, encrypted);
    }

    public static string GetMachineId()
    {
        try
        {
            string cpuId = GetWmiProperty("Win32_Processor", "ProcessorId");
            string biosSerial = GetWmiProperty("Win32_BIOS", "SerialNumber");
            string diskSerial = GetWmiProperty("Win32_DiskDrive", "SerialNumber");
            string macAddress = GetWmiProperty("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");

            string combined = $"{cpuId}|{biosSerial}|{diskSerial}|{macAddress}";
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(combined));
            return Convert.ToBase64String(hash);
        }
        catch
        {
            return Guid.NewGuid().ToString(); // Fail-safe fallback
        }
    }

    private static string GetWmiProperty(string className, string propertyName, string? conditionProperty = null)
    {
        using ManagementClass mc = new(className);
        foreach (ManagementObject mo in mc.GetInstances().Cast<ManagementObject>())
        {
            if (conditionProperty != null && !(bool)(mo[conditionProperty] ?? false))
                continue;

            return mo[propertyName]?.ToString() ?? "";
        }
        return "";
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
        aes.GenerateIV(); // Rastgele IV üret
        byte[] iv = aes.IV;

        ICryptoTransform encryptor = aes.CreateEncryptor();
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        // IV + EncryptedData birleştirilip tek parça halinde base64'e çevrilir
        byte[] result = new byte[iv.Length + encryptedBytes.Length];
        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
        Buffer.BlockCopy(encryptedBytes, 0, result, iv.Length, encryptedBytes.Length);

        return Convert.ToBase64String(result);
    }

    private static string Decrypt(string encryptedText)
    {
        byte[] key = Encoding.UTF8.GetBytes(EncryptionKey);
        byte[] fullCipher = Convert.FromBase64String(encryptedText);

        using Aes aes = Aes.Create();
        aes.Key = key;

        // IV ilk 16 byte olarak alınır
        byte[] iv = new byte[16];
        byte[] cipherBytes = new byte[fullCipher.Length - 16];
        Buffer.BlockCopy(fullCipher, 0, iv, 0, 16);
        Buffer.BlockCopy(fullCipher, 16, cipherBytes, 0, cipherBytes.Length);
        aes.IV = iv;

        ICryptoTransform decryptor = aes.CreateDecryptor();
        byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
