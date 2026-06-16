namespace Infra.Utils
{
    public static class StoreInventoryData
    {
        public static List<string> GetExpectedInventoryStatuses()
        {
            var expectedStatuses = new List<string>
            {
                "available",
                "sold",
                "pending"
            };

            return expectedStatuses;
        }
    }
}
