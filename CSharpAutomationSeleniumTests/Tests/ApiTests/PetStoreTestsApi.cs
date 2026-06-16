using Allure.NUnit.Attributes;
using Infra.Base;
using Infra.Steps.ApiSteps;

namespace CSharpAutomationSelenium.Tests.Tests.ApiTests
{
    [AllureFeature("PetStore API")]
    public class PetStoreApiTest : BaseApiTest
    {
        private PetStoreApiSteps _petStoreApiSteps = null!;

        [SetUp]
        public void PetStoreTestSetup()
        {
            _petStoreApiSteps = new PetStoreApiSteps(client);
        }

        [Test]
        [AllureStory("Create Pet")]
        [AllureTag("pet-creation")]
        [AllureSuite("PetStore API")]
        public void CreatePetTest()
        {
            _petStoreApiSteps
                .PerformCreatePet()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK);
        }

        [Test]
        [AllureStory("Get Pet")]
        [AllureTag("pet-retrieval")]
        [AllureSuite("PetStore API")]
        public void GetPetTest()
        {
            _petStoreApiSteps
                .PerformCreatePet()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK)
                .PerformGetPet()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK)
                .VerifyResponseContentIsNotEmpty()
                .VerifyPetData();
        }

        [Test]
        [AllureStory("Delete Pet")]
        [AllureTag("pet-deletion")]
        [AllureSuite("PetStore API")]
        public void DeletePetTest()
        {
            _petStoreApiSteps
                .PerformCreatePet()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK)
                .PerformDeletePet()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK);
        }

        [Test]
        [AllureStory("Get Store Inventory")]
        [AllureTag("store-inventory")]
        [AllureSuite("PetStore API")]
        public void GetStoreInventoryTest()
        {
            _petStoreApiSteps
                .PerformGetStoreInventory()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK)
                .VerifyResponseContentIsNotEmpty()
                .VerifyInventoryDataIsValid()
                .VerifyInventoryContainsExpectedStatuses();
        }

    }
}
