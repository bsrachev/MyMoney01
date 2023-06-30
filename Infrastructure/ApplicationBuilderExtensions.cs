using MyMoney.Data;
using MyMoney.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static MyMoney.Data.DataConstants.Roles;

namespace MyMoney.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;

            MigrateDatabase(serviceProvider);

            SeedRolesAndAdministrator(serviceProvider);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<MyMoneyDbContext>();

            data.Database.Migrate();
        }

        private static void SeedRolesAndAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var adminRole = new IdentityRole<int> { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(adminRole);

                    var user = new User
                    {
                        Email = "admin@mymoney.bg",
                        UserName = "Admin",
                        FullName = "MyMoney Admin"
                    };

                    await userManager.CreateAsync(user, "theadmin");

                    await userManager.AddToRoleAsync(user, adminRole.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
