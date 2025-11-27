using Allure.NUnit.Attributes;
using Infra.Api.Helpers;
using Infra.Api.Requests;
using Infra.Base;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace CSharpAutomationSelenium.Tests.Tests.ApiTests
{
    [AllureFeature("PetStore API")]
    public class PetStoreTestsApi : BaseApiTest
    {
        private const long PetId = 77701;

        [Test]
        [Order(1)]
        [AllureStory("Create Pet")]
        public void CreatePet()
        {
            var json = JsonHelper.Read("CreatePet.json");

            PetRequests.Create(request, json);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Null);
        }

        [Test]
        [Order(2)]
        [AllureStory("Get Pet")]
        public void GetPet()
        {
            PetRequests.Get(request, PetId);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var pet = JsonConvert.DeserializeObject<PetModel>(response.Content);

            PetValidator.ValidateCreatedPet(pet, PetId, "FreeWindPet");
        }

        [Test]
        [Order(3)]
        [AllureStory("Delete Pet")]
        public void DeletePet()
        {
            PetRequests.Delete(request, PetId);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
