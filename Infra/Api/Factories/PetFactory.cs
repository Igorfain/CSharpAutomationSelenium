using RestSharp;
using Infra.Api.Helpers;
using Infra.Utils;

namespace Infra.Api.Factories
{
    public static class PetFactory
    {
        // Creates a fully prepared RestRequest for Pet creation
        public static (RestRequest Request, long Id, string Name) CreatePetRequest()
        {
            var id = DataGeneratorUtils.GeneratePetId();
            var name = DataGeneratorUtils.GeneratePetName();

            var request = new RestRequest("pet", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            // Getting JSON and injecting dynamic data
            var json = JsonHelper.Read("CreatePet.json")
                .Replace("77701", id.ToString())
                .Replace("FreeWindPet", name);

            request.AddJsonBody(json);

            return (request, id, name);
        }
    }
}