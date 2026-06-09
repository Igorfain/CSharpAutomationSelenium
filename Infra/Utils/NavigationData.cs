using System.Collections.Generic;

namespace Infra.Utils
{
    public static class LandingPageNavigationData
    {
        public static List<string> GetLandingPageNavItems()
        {
            return new List<string>
            {
                "Home",
                "Products",
                "Cart",
                "Signup / Login",
                "Test Cases",
                "API Testing",
                "Video Tutorials",
                "Contact us"
            };
        }
    }
}
