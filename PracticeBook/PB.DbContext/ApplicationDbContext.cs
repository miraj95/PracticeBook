using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PB.DbContext.Migrations;
using PB.Entities;

namespace PB.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("PBConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PB.Entities.Practice> Practices { get; set; }

        public System.Data.Entity.DbSet<PB.Entities.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<PB.Entities.PracticeCompany> PracticeCompanies { get; set; }
    }
}
