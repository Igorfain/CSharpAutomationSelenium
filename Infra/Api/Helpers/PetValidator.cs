using NUnit.Framework;

namespace Infra.Api.Helpers
{
    public static class PetValidator
    {
        public static void ValidateCreatedPet(PetModel pet, long expectedId, string expectedName)
        {
            Assert.That(pet.Id, Is.EqualTo(expectedId));
            Assert.That(pet.Name, Is.EqualTo(expectedName));
            Assert.That(pet.Status, Is.EqualTo("available"));
        }
    }
}
