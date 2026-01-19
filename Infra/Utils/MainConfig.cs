using System.Collections.Generic;

namespace Infra.Utils
{
    public class MainConfig
    {
        public string url { get; set; } = string.Empty;
        public List<string> chromeArguments { get; set; } = new List<string>();
    }
}