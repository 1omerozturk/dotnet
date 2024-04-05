using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtnsion
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryContext>();
            // veritabanında her güncellemeden sonra manuel olarak girilen "dotnet ef database update" komutu yerine yapılan değişiklikleri otomatik olarak yapan kod bloğu tanımlandı.
            // Sadece uygulama ilk başladığında init yapmak gerekiyor. Geri kalanı kendisi update yapacaktır.

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        // Para birimleri ölçü birimleri için yerelleştirme ve genelleştirme yapmak için bu tarz fonksiyonlar kullanılır.
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                // örnek olarak türkiye eklendiğinde bu şekilde eklenir ve aralarına virgül konarak istenildiği kadar ekleme yapılabilir.
                options.AddSupportedCultures("tr-TR")
                .AddSupportedCultures("tr-TR")
                .SetDefaultCulture("tr-TR");
            });
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            // UserManager
            UserManager<IdentityUser> userManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

            // RoleManager
            RoleManager<IdentityRole> roleManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "oozturk@gmail.com",
                    PhoneNumber = "93593875896",
                    UserName = "adminUser",
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                    throw new Exception("Admin user could not created.");

                var roleResult = await userManager.AddToRolesAsync(user,
                roleManager
                .Roles
                .Select(r => r.Name)
                .ToList()
                );
                if(!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for admin");
            }   



        }

    }
}