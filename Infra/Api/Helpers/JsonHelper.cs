using System;
using System.IO;

namespace Infra.Api.Helpers
{
    public static class JsonHelper
    {
        public static string Read(string fileName)
        {
            var basePath = AppContext.BaseDirectory;
            var filePath = Path.Combine(basePath, "Api", "Requests", fileName);

            return File.ReadAllText(filePath);
        }
    }
}
