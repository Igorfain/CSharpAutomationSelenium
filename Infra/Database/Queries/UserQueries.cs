namespace Infra.Database.Queries;

public static class UserQueries
{
    public const string DbGetByEmail = """
    SELECT id, email, name, age, is_active AS IsActive, created_at AS CreatedAt
    FROM users
    WHERE email = @Email
""";

    public const string DbGetAllUsers = """
    SELECT id, email, name, age, is_active AS IsActive, created_at AS CreatedAt
    FROM users
    ORDER BY id
""";

    public const string DbGetActiveUsers = """
    SELECT id, email, name, age, is_active AS IsActive, created_at AS CreatedAt
    FROM users
    WHERE is_active = TRUE
    ORDER BY id
""";

    public const string DbGetUsersByStatus = """
    SELECT id, email, name, age, is_active AS IsActive, created_at AS CreatedAt
    FROM users
    WHERE is_active = @IsActive
    ORDER BY id
""";



}
