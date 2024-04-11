using StoreApp.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.ConfigureIdentity();

builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigureSession();





// Repo için IOS kayıtları
builder.Services.ConfigureRepositoryRegistration();

// Service için IOS kayıtları
builder.Services.ConfigureServiceRegistration();


// localization service configurations...
builder.Services.ConfigureRouting();


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddRazorPages();


var app = builder.Build();
app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapRazorPages();
});

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();
app.Run();
