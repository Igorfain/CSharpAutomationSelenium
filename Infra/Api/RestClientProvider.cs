using RestSharp;

namespace Infra.Api
{
    public static class PetStoreClientProvider
    {
        private static readonly RestClient _client = Create();
        public static RestClient Client => _client;

        private static RestClient Create()
        {
            var options = new RestClientOptions(PetStoreEndpoints.BASE_API)
            {
                ThrowOnAnyError = false,
                Timeout = TimeSpan.FromSeconds(30)
            };

            var client = new RestClient(options);

            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader("User-Agent", "CSharpAutomation/1.0");

            return client;
        }
    }
}
