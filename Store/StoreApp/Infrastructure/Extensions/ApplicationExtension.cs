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
            app.UseRequestLocalization(options=>{
                // örnek olarak türkiye eklendiğinde bu şekilde eklenir ve aralarına virgül konarak istenildiği kadar ekleme yapılabilir.
                options.AddSupportedCultures("tr-TR")
                .AddSupportedCultures("tr-TR")
                .SetDefaultCulture("tr-TR");
            });
        }
    }
}