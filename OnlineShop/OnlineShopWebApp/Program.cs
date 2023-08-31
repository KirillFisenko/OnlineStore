using Microsoft.AspNetCore.Localization;
using OnlineShopWebApp;
using System.Globalization;
//Serilog
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Serilog
builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "Online Shop"));

builder.Services.AddControllersWithViews();
//��������� ������������ DI, ������ ��������� ��� ������ ���������
builder.Services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();
builder.Services.AddSingleton<ICartsRepository, CartsInMemoryRepository>();
builder.Services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
builder.Services.AddSingleton<IFavouritesRepository, FavouritesInMemoryRepository>();
builder.Services.AddSingleton<ICompareRepository, CompareInMemoryRepository>();
builder.Services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
builder.Services.AddSingleton<IUsersRepository, UsersInMemoryRepository>();

//��������� ����������� ��� ����������� ����������� ����� "."
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US")
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

//Serilog
app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseRequestLocalization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();