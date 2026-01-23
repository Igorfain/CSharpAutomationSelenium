
using System.Text.Json;


namespace Infra.Utils
{
    public class MainConfig
    {
        public string url { get; set; } = string.Empty;
        public List<string> chromeArguments { get; set; } = new List<string>();
        public DbSettings DbSettings { get; set; } = new DbSettings();

        public static MainConfig Load()
        {

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "MainConfig.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Config file not found at: {filePath}");

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<MainConfig>(jsonString)
                   ?? throw new Exception("Failed to deserialize MainConfig.json");
        }
    }

    public class DbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
}