using Allure.NUnit.Attributes;
using Infra.Api;
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
        private Dictionary<string, int>? _inventoryData;

        public PetStoreApiSteps(RestClient client)
        {
            _client = client;
        }

        [AllureStep("Perform create pet")]
        public PetStoreApiSteps PerformCreatePet()
        {
            var (petRequest, petId, petName) = PetFactory.CreatePetRequest();
            _petId = petId;
            _petName = petName;

            LoggerUtils.LogStep($"Creating pet with ID: {petId}, Name: {petName}");
            _lastResponse = _client.Execute(petRequest);

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
            var deletePetRequest = new RestRequest($"pet/{_petId}", Method.Delete);
            deletePetRequest.AddHeader("Accept", "application/json");
            deletePetRequest.AddHeader("Content-Type", "application/json");

            LoggerUtils.LogStep($"Deleting pet with ID: {_petId}");
            _lastResponse = _client.Execute(deletePetRequest);

            return this;
        }

        [AllureStep("Perform get store inventory")]
        public PetStoreApiSteps PerformGetStoreInventory()
        {
            var inventoryRequest = new RestRequest(PetStoreEndpoints.GET_STORE_INVENTORY, Method.Get);
            inventoryRequest.AddHeader("Accept", "application/json");

            LoggerUtils.LogStep("Getting store inventory by status");
            _lastResponse = _client.Execute(inventoryRequest);

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

        [AllureStep("Verify inventory data is valid")]
        public PetStoreApiSteps VerifyInventoryDataIsValid()
        {
            _inventoryData = JsonConvert.DeserializeObject<Dictionary<string, int>>(_lastResponse?.Content);

            LoggerUtils.LogStep("Validating inventory data structure and content");

            Assert.That(_inventoryData, Is.Not.Null, "Failed to deserialize inventory data");
            Assert.That(_inventoryData, Is.Not.Empty, "Inventory data is empty");

            var inventoryStatusCount = _inventoryData!.Count;
            LoggerUtils.LogStep($"Found {inventoryStatusCount} inventory status entries");

            return this;
        }

        [AllureStep("Verify inventory contains expected statuses")]
        public PetStoreApiSteps VerifyInventoryContainsExpectedStatuses()
        {
            var expectedStatuses = StoreInventoryData.GetExpectedInventoryStatuses();

            LoggerUtils.LogStep($"Verifying inventory contains expected statuses: {string.Join(", ", expectedStatuses)}");

            foreach (var expectedStatus in expectedStatuses)
            {
                var statusExists = _inventoryData!.ContainsKey(expectedStatus);
                var statusCount = statusExists ? _inventoryData[expectedStatus] : 0;

                var sortedStatusKeys = new List<string>(_inventoryData.Keys);
                sortedStatusKeys.Sort();

                Assert.That(statusExists, Is.True,
                    $"Expected inventory status '{expectedStatus}' not found in inventory. Available: {string.Join(", ", sortedStatusKeys)}");

                LoggerUtils.LogStep($"Status '{expectedStatus}' found with count: {statusCount}");
            }

            return this;
        }

        [AllureStep("Verify pet data matches")]
        public PetStoreApiSteps VerifyPetData()
        {
            var actualPet = JsonConvert.DeserializeObject<PetModel>(_lastResponse?.Content);

            Assert.That(actualPet, Is.Not.Null, "Failed to deserialize PetModel");

            LoggerUtils.LogStep($"Validating pet data. ID: {_petId}, Name: {_petName}");
            PetValidator.ValidateCreatedPet(actualPet!, _petId, _petName);

            return this;
        }
    }
}
