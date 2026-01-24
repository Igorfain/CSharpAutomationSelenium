using Infra.Database.Helpers;
using Infra.Database.Models;
using static Infra.Database.Queries.UserQueries;

namespace Infra.Database.Extensions;

public static class DbUserExtensions
{
    public static User? GetUserByEmail(this DbHelper db, string email)
    {
        return db.QuerySingle<User>(
            DbGetByEmail,
            new { Email = email }
        );
    }

    public static List<User> GetAllUsers(this DbHelper db)
    {
        return db.Query<User>(DbGetAllUsers).ToList();
    }

    public static List<User> GetActiveUsers(this DbHelper db)
    {
        return db.Query<User>(DbGetActiveUsers).ToList();
    }

    public static List<User> GetUsersByStatus(this DbHelper db, bool isActive)
    {
        return db.Query<User>(DbGetUsersByStatus, new { IsActive = isActive }).ToList();
    }


}
