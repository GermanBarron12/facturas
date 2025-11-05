using Microsoft.EntityFrameworkCore;
using facturas.Components;
using facturas.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configurar la base de datos SQLite
builder.Services.AddDbContext<FacturasDb>(options =>
    options.UseSqlite("Data Source=facturas.db"));

var app = builder.Build();

// Crear la base de datos si no existe
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FacturasDb>();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();