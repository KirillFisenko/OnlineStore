using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using Serilog;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using OnlineShop.Db.Models;
using Microsoft.AspNetCore.Identity;

// создание нового экземпляра web application builder
var builder = WebApplication.CreateBuilder(args);

// добавление Serilog в хост для логирования запросов
builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "Online Shop"));

// добавление контроллеров с представлениями в коллекцию сервисов
builder.Services.AddControllersWithViews();

// добавление репозиториев в коллекцию сервисов
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
builder.Services.AddTransient<ICompareRepository, CompareDbRepository>();

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

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("online_shop");

// добавляем контекст DatabaseContext в качестве сервиса в приложение
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

// добавляем контекст IndentityContext в качестве сервиса в приложение
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

// указываем тип пользователя и роли
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

// создание экземпляра приложения
var app = builder.Build();

// если приложение не находится в режиме разработки
if (!app.Environment.IsDevelopment())
{
	// подключение обработчика исключений
	app.UseExceptionHandler("/Home/Error");

	// подключение HSTS
	app.UseHsts();
}

// подключение локализации запросов
app.UseRequestLocalization();

// подключение Serilog для логирования запросов
app.UseSerilogRequestLogging();

// подключение статических файлов
app.UseStaticFiles();

// подключение маршрутизации
app.UseRouting();

// подключение аутентификации
app.UseAuthentication();

// подключение авторизации
app.UseAuthorization(); 

// определение маршрута контроллера для area
app.MapControllerRoute(
	name: "MyArea",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// определение маршрута по умолчанию
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

// запуск приложения
app.Run();