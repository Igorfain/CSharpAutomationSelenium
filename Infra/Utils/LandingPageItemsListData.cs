
namespace Infra.Utils
{
    public static class LandingPageItemsListData
    {
        static string username = "TestUser";

        public static List<string> NavTopBarItemsReferenceList()
        {
            return new List<string>
            {
                "Home",
                "Products",
                "Cart",
                "Logout",
                "Delete Account",
                "Test Cases",
                "API Testing",
                "Video Tutorials",
                "Contact us",
                $"Logged in as {username}"
            };
        }

        public static List<string> BrandsBarItemsReferenceList()
        {
            return new List<string>
    {
        "POLO",
        "H&M",
        "MADAME",
        "MAST & HARBOUR",
        "BABYHUG",
        "ALLEN SOLLY JUNIOR",
        "KOOKIE KIDS",
        "BIBA"
    };

        }
    }

   
}
