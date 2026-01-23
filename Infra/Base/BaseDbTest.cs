using Infra.Database.Helpers;
using Infra.Utils;
using NUnit.Framework;

namespace Infra.Base
{
    [TestFixture]
    public class BaseDbTest
    {
        protected MainConfig config = null!;
        protected DbHelper Db = null!;

        [SetUp]
        public virtual void SetUp()
        {
            config = MainConfig.Load();

            Db = new DbHelper(config.DbSettings.ConnectionString);
            Db.BeginTransaction();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Db.Rollback();
            Db.Dispose();
        }
    }
}
