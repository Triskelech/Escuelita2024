using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Model.Context;
using Service.Contracts;
using Service.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1800);
    options.Cookie.HttpOnly = true;
    options.Cookie.Name = ".Web.Session";
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor(); // Access to context from outside controllers
#endregion

#region DB
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
var connection = configuration.GetConnectionString("db1");
builder.Services.AddDbContext<EscuelitaContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
#endregion

#region Services
builder.Services.AddTransient<IEntityService, EntityService>();
#endregion

var app = builder.Build();

#region Accesors
//AppSettings.Configuration = configuration;
//SystemEnvironment.Environment = builder.Environment;
#endregion


app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();