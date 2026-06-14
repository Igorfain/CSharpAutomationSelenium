using Allure.NUnit.Attributes;
using Infra.Api.Factories;
using Infra.Api.Helpers;
using Infra.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace Infra.Steps.ApiSteps
{
    public class PetStoreApiSteps
    {
        private readonly RestClient _client;
        private RestResponse? _lastResponse;
        private long _petId;
        private string _petName = string.Empty;

        public PetStoreApiSteps(RestClient client)
        {
            _client = client;
        }

        [AllureStep("Perform create pet")]
        public PetStoreApiSteps PerformCreatePet()
        {
            var (request, id, name) = PetFactory.CreatePetRequest();
            _petId = id;
            _petName = name;

            LoggerUtils.LogStep($"Creating pet with ID: {id}, Name: {name}");
            _lastResponse = _client.Execute(request);

            return this;
        }

        [AllureStep("Perform get pet")]
        public PetStoreApiSteps PerformGetPet()
        {
            var request = new RestRequest($"pet/{_petId}", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            LoggerUtils.LogStep($"Getting pet with ID: {_petId}");
            _lastResponse = _client.Execute(request);

            return this;
        }

        [AllureStep("Perform delete pet")]
        public PetStoreApiSteps PerformDeletePet()
        {
            var request = new RestRequest($"pet/{_petId}", Method.Delete);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            LoggerUtils.LogStep($"Deleting pet with ID: {_petId}");
            _lastResponse = _client.Execute(request);

            return this;
        }

        [AllureStep("Verify response status code is {expectedStatusCode}")]
        public PetStoreApiSteps VerifyResponseStatusCode(HttpStatusCode expectedStatusCode)
        {
            LoggerUtils.LogStep($"Verifying response status code. Expected: {expectedStatusCode}, Actual: {_lastResponse?.StatusCode}");

            Assert.That(_lastResponse?.StatusCode, Is.EqualTo(expectedStatusCode),
                $"Response status code mismatch. Expected: {expectedStatusCode}, Actual: {_lastResponse?.StatusCode}");

            return this;
        }

        [AllureStep("Verify response content is not empty")]
        public PetStoreApiSteps VerifyResponseContentIsNotEmpty()
        {
            LoggerUtils.LogStep("Verifying response content is not null and not empty");

            Assert.That(_lastResponse?.Content, Is.Not.Null.And.Not.Empty,
                "Response content is empty");

            return this;
        }

        [AllureStep("Verify pet data matches")]
        public PetStoreApiSteps VerifyPetData()
        {
            var pet = JsonConvert.DeserializeObject<PetModel>(_lastResponse?.Content);

            Assert.That(pet, Is.Not.Null, "Failed to deserialize PetModel");

            LoggerUtils.LogStep($"Validating pet data. ID: {_petId}, Name: {_petName}");
            PetValidator.ValidateCreatedPet(pet!, _petId, _petName);

            return this;
        }
    }
}
