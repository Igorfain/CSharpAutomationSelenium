using RestSharp;

namespace Infra.Api.Requests
{
    public static class PetRequests
    {
        public static void Create(RestRequest request, string json)
        {
            request.Method = Method.Post;
            request.Resource = PetStoreEndpoints.CREATE_PET;
            request.AddStringBody(json, DataFormat.Json);
        }

        public static void Get(RestRequest request, long petId)
        {
            request.Method = Method.Get;
            request.Resource = PetStoreEndpoints.GET_PET + petId;
        }

        public static void Delete(RestRequest request, long petId)
        {
            request.Method = Method.Delete;
            request.Resource = PetStoreEndpoints.DELETE_PET + petId;
        }
    }
}
