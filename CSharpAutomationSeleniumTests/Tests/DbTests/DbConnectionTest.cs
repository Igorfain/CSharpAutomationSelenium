using Infra.Base;
using Infra.Database.Extensions;
using static Infra.TestData.TestUsers;

namespace CSharpAutomationSelenium.Tests.DbTests
{
    [TestFixture]
    public class UserDbTests : BaseDbTest
    {
        [Test]
        public void CheckUserExistsInDb()
        {
            var user = Db.GetUserByEmail(ExistingUserEmail);

            Assert.That(user, Is.Not.Null);
            Assert.That(user!.Age, Is.GreaterThan(0));
            Assert.That(user.IsActive, Is.True);
            Console.WriteLine($"User: {user.Email}, Age: {user.Age}, Active: {user.IsActive}");
        }

        [Test]
        public void CheckUsersList()
        {
            var users = Db.GetAllUsers();

            Assert.That(users.Count, Is.GreaterThanOrEqualTo(10));
            Assert.That(users.All(u => u.Age > 0));
            Console.WriteLine($"Loaded users: {users.Count}");
        }

        [Test]
        public void CheckActiveUsersOnly()
        {
            var users = Db.GetActiveUsers();

            Assert.That(users.Count, Is.GreaterThan(0));
            Assert.That(users.All(u => u.IsActive));
            Console.WriteLine($"Active users: {users.Count}");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void CheckUsersByStatus(bool isActive)
        {
            var users = Db.GetUsersByStatus(isActive);
            Assert.That(users.Count, Is.GreaterThan(0));
            Assert.That(users.All(u => u.IsActive == isActive));
            Console.WriteLine($"{(isActive ? "Active" : "Inactive")} users: {users.Count}");
        }

        //    [Test]
        //    public void TransactionRollback_Works()
        //    {
        //        Db.Execute("""
        //    INSERT INTO users (email, name)
        //    VALUES ('temp@test.com', 'Temp User')
        //""");

        //        var user = Db.GetUserByEmail("temp@test.com");
        //        Assert.That(user, Is.Not.Null);
        //    }


    }
}