using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using Serilog;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using OnlineShop.Db.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShopWebApp.Helpers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Online shop API",
        Description = "Online shop ASP .NET Core Web API",
        
    });
});

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("online_shop");

// добавление репозиториев в коллекцию сервисов
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
builder.Services.AddTransient<ICompareRepository, CompareDbRepository>();
builder.Services.AddTransient<ImagesProvider>();

// сервис для автомаппинга
builder.Services.AddAutoMapper(typeof(MappingProfile));

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();