using Microsoft.EntityFrameworkCore;
using Obligatorio.Datos;

var builder = WebApplication.CreateBuilder(args);

//Configurar conexion
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
{
    // Aquí, obtenemos la cadena de conexión desde la configuración de la aplicación.
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/*#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "filtrarMaquinas",
        pattern: "Maquinas/Filtrar",
        defaults: new { controller = "Maquinas", action = "Filtrar" });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations
*/