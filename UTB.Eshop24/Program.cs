using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Infrastructure.Database;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.Implementation;
using Microsoft.AspNetCore.Identity;
using UTB.Eshop.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.38");
builder.Services.AddDbContext<EshopDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));


//Configuration for Identity
builder.Services.AddIdentity<User, Role>()
     .AddEntityFrameworkStores<EshopDbContext>()
     .AddDefaultTokenProviders();


//registrace služeb aplikační vrstvy
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<ICarouselAppService, CarouselAppService>();
builder.Services.AddScoped<IHomeService, HomeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

