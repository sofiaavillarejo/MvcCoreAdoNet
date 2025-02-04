var builder = WebApplication.CreateBuilder(args);

//añadir los servicios de vistas y controllers
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}"); // /{id?}
//usamos static files
app.UseStaticFiles();
app.Run();
