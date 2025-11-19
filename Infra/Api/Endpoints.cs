namespace Infra.Api
{
    public static class PetStoreEndpoints
    {
        public const string BaseUrl = "https://petstore.swagger.io/v2";

        public static string CreatePet => "/pet";
        public static string GetPet(long id) => $"/pet/{id}";
        public static string DeletePet(long id) => $"/pet/{id}";
    }
}
