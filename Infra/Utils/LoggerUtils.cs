using NUnit.Framework;

namespace Infra.Utils
{
    public static class LoggerUtils
    {
        public static void LogStep(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string formattedMessage = $"[{timestamp}] STEP: {message}";
            TestContext.WriteLine(formattedMessage);
        }
    }
}