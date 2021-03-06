using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using whatsappWeb.Data;
using whatsappWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<whatsappWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("whatsappWebContext") ?? throw new InvalidOperationException("Connection string 'whatsappWebContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRankingsService, RankingsService>();

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
    pattern: "{controller=Rankings}/{action=Search}/{id?}");

app.Run();
