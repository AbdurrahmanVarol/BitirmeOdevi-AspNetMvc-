namespace BitirmeOdevi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BitirmeOdevi.DataAccess.Concrate.EntityFramework.BitirmeOdeviContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BitirmeOdevi.DataAccess.Concrate.EntityFramework.BitirmeOdeviContext";
        }

        protected override void Seed(BitirmeOdevi.DataAccess.Concrate.EntityFramework.BitirmeOdeviContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
