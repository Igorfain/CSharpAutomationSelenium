using Infra.Database.Helpers;

namespace Infra.Database.Factories;

public static class UserFactory
{
    public static string CreateUser(DbHelper db, bool isActive = true, int age = 25)
    {
        var email = $"user_{Guid.NewGuid()}@test.com";

        db.Execute("""
            INSERT INTO users (email, name, age, is_active)
            VALUES (@Email, @Name, @Age, @IsActive)
        """, new
        {
            Email = email,
            Name = "Auto User",
            Age = age,
            IsActive = isActive
        });

        return email;
    }
}
