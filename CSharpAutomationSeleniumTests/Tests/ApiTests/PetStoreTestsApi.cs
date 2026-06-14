using Allure.NUnit.Attributes;
using Infra.Base;
using Infra.Steps.ApiSteps;

namespace CSharpAutomationSelenium.Tests.Tests.ApiTests
{
    [AllureFeature("PetStore API")]
    [Parallelizable(ParallelScope.Children)]
    public class PetStoreTestsApi : BaseApiTest
    {
        private PetStoreApiSteps _petStoreApiSteps = null!;

        [SetUp]
        public void PetStoreTestSetup()
        {
            _petStoreApiSteps = new PetStoreApiSteps(client);
        }

        [Test]
        [AllureStory("Create Pet")]
        public void CreatePet()
        {
            _petStoreApiSteps
                .PerformCreatePet()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK);
        }

        [Test]
        [AllureStory("Get Pet")]
        public void GetPet()
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
        public void DeletePet()
        {
            _petStoreApiSteps
                .PerformCreatePet()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK)
                .PerformDeletePet()
                .VerifyResponseStatusCode(System.Net.HttpStatusCode.OK);
        }
    }
}
