using NUnit.Framework;

namespace Infra.Utils
{
    public static class LoggerUtils
    {
        public static void LogStep(string message)
        {
            string timestamp = DateTime.Now.ToString("MM-dd HH:mm:ss");
            string formattedMessage = $"[{timestamp}] STEP: {message}";
            TestContext.WriteLine(formattedMessage);
        }
    }
}