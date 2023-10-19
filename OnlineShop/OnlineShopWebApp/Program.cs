using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using Serilog;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using OnlineShop.Db.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShopWebApp.Helpers;

// создание нового экземпл€ра web application builder
var builder = WebApplication.CreateBuilder(args);

// добавление Serilog в хост дл€ логировани€ запросов
builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "Online Shop"));

// добавление контроллеров с представлени€ми в коллекцию сервисов
builder.Services.AddControllersWithViews();

// добавление репозиториев в коллекцию сервисов
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
builder.Services.AddTransient<ICompareRepository, CompareDbRepository>();
builder.Services.AddTransient<ImagesProvider>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// настройка параметров локализации запросов
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

// получаем строку подключени€ из файла конфигурации
string connection = builder.Configuration.GetConnectionString("online_shop");

// добавл€ем контекст DatabaseContext в качестве сервиса в приложение
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

// добавл€ем контекст IndentityContext в качестве сервиса в приложение
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

// указываем тип пользовател€ и роли
builder.Services.AddIdentity<User, IdentityRole>()
                // устанавливаем тип хранилища - наш контекст
                .AddEntityFrameworkStores<IdentityContext>();

// настройка cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.Cookie = new CookieBuilder
    {
        IsEssential = true
    };
});

// создание экземпл€ра приложени€
var app = builder.Build();

// если приложение не находитс€ в режиме разработки
if (!app.Environment.IsDevelopment())
{
    // подключение обработчика исключений
    app.UseExceptionHandler("/Home/Error");

    // подключение HSTS
    app.UseHsts();
}

// подключение локализации запросов
app.UseRequestLocalization();

// подключение Serilog дл€ логировани€ запросов
app.UseSerilogRequestLogging();

// подключение статических файлов
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
    }
});

// подключение маршрутизации
app.UseRouting();

// подключение аутентификации
app.UseAuthentication();

// подключение авторизации
app.UseAuthorization();

// определение маршрута контроллера дл€ area
app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// определение маршрута по умолчанию
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// инициализаци€ администратора
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, rolesManager);
}

// запуск приложени€
app.Run();