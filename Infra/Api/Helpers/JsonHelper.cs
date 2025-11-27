
namespace Infra.Api.Helpers
{
    public static class JsonHelper
    {
        public static string Read(string fileName)
        {
            var path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                $@"..\..\..\..\Infra\Api\Requests\{fileName}"
            );

            return File.ReadAllText(path);
        }
    }
}
