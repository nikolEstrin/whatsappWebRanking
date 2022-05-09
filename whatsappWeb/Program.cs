using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using whatsappWeb.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<whatsappWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("whatsappWebContext") ?? throw new InvalidOperationException("Connection string 'whatsappWebContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AllRankings}/{action=Index}/{id?}");

app.Run();
