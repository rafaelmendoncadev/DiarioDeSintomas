using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using DiarioDeSintomas.Data;
using DiarioDeSintomas.Models; // Certifique-se de importar o namespace correto

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DiarioContext>(options =>
    options.UseSqlite("Data Source=wwwroot/diario.db"));

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
    pattern: "{controller=DiarioSintomas}/{action=Index}/{id?}");

app.Run();
