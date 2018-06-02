namespace PB.DbContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "PB.DbContext.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Roles.Any())
            {
                Initializer.SeedRoles(context);
            }

            if (!context.Users.Any())
            {
                Initializer.SeedUser(context);
            }
            

        }
    }
}
