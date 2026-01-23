using Infra.Base;
using Infra.Database.Factories;
using Infra.Database.Extensions;

namespace CSharpAutomationSelenium.Tests.DbTests;

[TestFixture]
public class UserFactoryTests : BaseDbTest
{
    [Test]
    public void Factory_ShouldCreateUser()
    {
        var email = UserFactory.CreateUser(Db, isActive: true, age: 30);

        var user = Db.GetUserByEmail(email);

        Assert.That(user, Is.Not.Null);
        Assert.That(user!.Email, Is.EqualTo(email));
        Assert.That(user.IsActive, Is.True);
        Assert.That(user.Age, Is.EqualTo(30));
    }

        [Test]
        public void UserCreatedPreviously_ShouldNotExist()
        {
            var email = "should_not_exist@test.com";

            var user = Db.GetUserByEmail(email);

            Assert.That(user, Is.Null, "User still exists — rollback failed");
        }
    }
