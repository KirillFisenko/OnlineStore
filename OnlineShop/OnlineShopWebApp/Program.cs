using Microsoft.EntityFrameworkCore;
using OnlineShopWebApp;
using OnlineShop.Db;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "Online Shop"));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
builder.Services.AddTransient<IFavouritesRepository, FavouritesDbRepository>();
builder.Services.AddTransient<ICompareRepository, CompareDbRepository>();
builder.Services.AddTransient<IRolesRepository, RolesDbRepository>();
builder.Services.AddTransient<IUsersRepository, UsersDbRepository>();

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("online_shop");

// добавляем контекст DatabaseContext в качестве сервиса в приложение
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();