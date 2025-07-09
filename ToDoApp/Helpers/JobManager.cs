using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ToDoApp.Entities;

namespace ToDoApp.Helpers
{
    public static class JobManager
    {
        private const string JOBS_PATH = "jobs.dat";

        private static byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        private static byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
        };

        public static List<Job> LoadJobs()
        {
            if (CheckFileExists())
            {
                return LoadEncryptedJson();
            }

            CreateFile();
            return [];
        }

        public static void AddRecord(Job job)
        {
            var jobs = LoadJobs();

            var id = jobs.Count > 0 ? jobs.Max(x => x.Id) + 1 : 1;
            job.Id = id;

            jobs.Add(job);

            Save(jobs);
        }

        public static bool RemoveRecord(int id)
        {
            var jobs = LoadJobs();

            int foundIndex = jobs.FindIndex(x => x.Id == id);

            if (foundIndex == -1)
                return false;
            else
            {
                jobs.RemoveAt(foundIndex);
                Save(jobs);
                return true;
            }
        }

        public static void Save(List<Job> jobs)
        {
            SaveEncryptedJson(jobs);
        }

        private static bool CheckFileExists() => File.Exists(JOBS_PATH);

        private static void CreateFile()
        {
            SaveEncryptedJson([]);
        }

        private static void SaveEncryptedJson(List<Job> data)
        {
            // 1. JSON string olarak serialize et
            string json = JsonSerializer.Serialize(data, Options);

            // 2. AES ile şifrele
            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt);

            swEncrypt.Write(json);
            swEncrypt.Flush();
            csEncrypt.FlushFinalBlock();

            byte[] encrypted = msEncrypt.ToArray();

            // 3. .dat dosyasına yaz
            File.WriteAllBytes(JOBS_PATH, encrypted);
        }

        public static List<Job> LoadEncryptedJson()
        {
            byte[] encrypted = File.ReadAllBytes(JOBS_PATH);

            using Aes aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            using MemoryStream msDecrypt = new(encrypted);
            using CryptoStream csDecrypt = new(msDecrypt, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            string json = srDecrypt.ReadToEnd();

            return JsonSerializer.Deserialize<List<Job>>(json)!;
        }
    }
}
