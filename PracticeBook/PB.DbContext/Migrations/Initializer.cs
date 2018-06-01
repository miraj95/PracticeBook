using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PB.Common;
using PB.Entities;

namespace PB.DbContext.Migrations
{
    internal class Initializer
    {
        internal static void SeedRoles(ApplicationDbContext context)
        {
            string[] roles =
            {
                "Administrator",
                "Company",
                "Student"
            };

            foreach (var role in roles)
            {
                var roleStore = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.Create(new IdentityRole(role));
                }
            }
        }

        internal static void SeedUser(ApplicationDbContext context)
        {
            string userName = "Admin";
            string role = "Administrator";
            var userRole = new IdentityRole { Id = new CustomId().ToString(), Name = role};
            context.Roles.Add(userRole);

            var hasher = new PasswordHasher();

            var user = new User
            {
                UserName = userName,
                PasswordHash = hasher.HashPassword("1"),
                Email = "admin@domain.com",
                EmailConfirmed = true,
                SecurityStamp = new CustomId().ToString()
            };

            user.Roles.Add(new IdentityUserRole {RoleId = userRole.Id, UserId = user.Id });
            context.Users.AddOrUpdate(user);
        }
    }
}