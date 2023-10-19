using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using Serilog;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using OnlineShop.Db.Models;
using Microsoft.AspNetCore.Identity;
using OnlineShopWebApp.Helpers;

// �������� ������ ���������� web application builder
var builder = WebApplication.CreateBuilder(args);

// ���������� Serilog � ���� ��� ����������� ��������
builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "Online Shop"));

// ���������� ������������ � ��������������� � ��������� ��������
builder.Services.AddControllersWithViews();

// ���������� ������������ � ��������� ��������
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
builder.Services.AddTransient<ICompareRepository, CompareDbRepository>();
builder.Services.AddTransient<ImagesProvider>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ��������� ���������� ����������� ��������
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

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("online_shop");

// ��������� �������� DatabaseContext � �������� ������� � ����������
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

// ��������� �������� IndentityContext � �������� ������� � ����������
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

// ��������� ��� ������������ � ����
builder.Services.AddIdentity<User, IdentityRole>()
                // ������������� ��� ��������� - ��� ��������
                .AddEntityFrameworkStores<IdentityContext>();

// ��������� cookie
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

// �������� ���������� ����������
var app = builder.Build();

// ���� ���������� �� ��������� � ������ ����������
if (!app.Environment.IsDevelopment())
{
    // ����������� ����������� ����������
    app.UseExceptionHandler("/Home/Error");

    // ����������� HSTS
    app.UseHsts();
}

// ����������� ����������� ��������
app.UseRequestLocalization();

// ����������� Serilog ��� ����������� ��������
app.UseSerilogRequestLogging();

// ����������� ����������� ������
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
    }
});

// ����������� �������������
app.UseRouting();

// ����������� ��������������
app.UseAuthentication();

// ����������� �����������
app.UseAuthorization();

// ����������� �������� ����������� ��� area
app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// ����������� �������� �� ���������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ������������� ��������������
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, rolesManager);
}

// ������ ����������
app.Run();