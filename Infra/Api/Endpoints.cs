namespace Infra.Api
{
    public static class PetStoreEndpoints
    {
        public const string BASE_API = "https://petstore.swagger.io/v2";

        public const string CREATE_PET = BASE_API + "/pet";
        public const string GET_PET = BASE_API + "/pet/";     // + id
        public const string DELETE_PET = BASE_API + "/pet/";  // + id
    }
}
