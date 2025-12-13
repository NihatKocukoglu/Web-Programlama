using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
//harita kontrolü
app.MapControllerRoute(name:"default",pattern:"{controller=Home}/{action=Index}/{id?}");
app.Run();
