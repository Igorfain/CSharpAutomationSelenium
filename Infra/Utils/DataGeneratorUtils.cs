using System;

namespace Infra.Utils
{
    public static class DataGeneratorUtils
    {
        private static readonly Random Random = new Random();

        public static string GenerateRandomEmail()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            int num = Random.Next(1000, 9999);
            return $"user_{timestamp}_{num}@testmail.com";
        }

        public static string GenerateRandomPassword()
        {
            return "Pass_" + Guid.NewGuid().ToString().Substring(0, 8);
        }

        public static string GenerateRandomName()
        {
            string[] names = { "Igor", "Alex", "Jordan", "Taylor", "Morgan" };
            return names[Random.Next(names.Length)] + "_" + Random.Next(100, 999);
        }
    }
}