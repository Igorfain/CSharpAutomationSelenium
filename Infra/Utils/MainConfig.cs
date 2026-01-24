using System.Text.Json;
using DotNetEnv;

namespace Infra.Utils
{
    public class MainConfig
    {
        public string url { get; set; } = string.Empty;
        public List<string> chromeArguments { get; set; } = new();
        public DbSettings DbSettings { get; set; } = new();

        public static MainConfig Load()
        {
            var rootPath = FindRepoRoot();

            // Load .env
            var envPath = Path.Combine(rootPath, ".env");
            if (File.Exists(envPath))
                Env.Load(envPath);

            // Load MainConfig.json
            var configPath = Path.Combine(rootPath, "Infra", "Config", "MainConfig.json");
            if (!File.Exists(configPath))
                throw new FileNotFoundException($"Config file not found at: {configPath}");

            var jsonString = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<MainConfig>(jsonString)
                         ?? throw new Exception("Failed to deserialize MainConfig.json");

            config.DbSettings.ConnectionString =
                Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                ?? throw new Exception("DB_CONNECTION_STRING is not set");

            return config;
        }

        private static string FindRepoRoot()
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (dir != null)
            {
                if (dir.GetFiles("*.sln").Any())
                    return dir.FullName;

                dir = dir.Parent;
            }

            throw new Exception("Solution root not found");
        }
    }

    public class DbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
}
