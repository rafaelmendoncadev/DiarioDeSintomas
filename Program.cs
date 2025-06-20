using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DiarioDeSintomas.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

// Contexto principal da aplicação
builder.Services.AddDbContext<DiarioContext>(options =>
    options.UseSqlite("Data Source=wwwroot/diario.db"));

// Contexto de autenticação (Identity)
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlite(connectionString));

// Configuração do Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<IdentityContext>();

// Adiciona suporte a controllers e views
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");
});

var app = builder.Build();

// Pipeline de requisição HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Necessário para Identity
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DiarioSintomas}/{action=Index}/{id?}");

// Mapeia as páginas de área do Identity (login, registro, etc.)
app.MapRazorPages();

app.Run();