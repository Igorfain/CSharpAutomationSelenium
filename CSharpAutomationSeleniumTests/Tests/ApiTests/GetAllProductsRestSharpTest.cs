using Allure.NUnit.Attributes;
using Infra.Base;
using Newtonsoft.Json;
using RestSharp;

namespace CSharpAutomationSelenium.Tests.ApiTests
{
  
    [AllureFeature("PetStore API")]
    public class PetStoreTests : BaseApiTest
    {
        [Test]
        [Order(1)]
        [AllureStory("Create Pet")]
        public void CreatePet()
        {
            var pet = new
            {
                Id = 77701,
                Name = "FreeWindPet",
                Status = "available"
            };

            var request = new RestRequest("/pet", Method.Post);
            request.AddJsonBody(pet);

            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        [Order(2)]
        [AllureStory("Get Pet")]
        public void GetPet()
        {
            var request = new RestRequest("/pet/77701", Method.Get);
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            dynamic pet = JsonConvert.DeserializeObject(response.Content);

            Assert.That((string)pet.name, Is.EqualTo("FreeWindPet"));
        }

        [Test]
        [Order(3)]
        [AllureStory("Delete Pet")]
        public void DeletePet()
        {
            var request = new RestRequest("/pet/77701", Method.Delete);
            var response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
    }
}
