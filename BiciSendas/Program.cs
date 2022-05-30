using BiciSendas.DA;
using BiciSendas.DA.DA;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection serviceCollection = builder.Services.AddDbContext<BicisendasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BicisendasContext")));
builder.Services.AddScoped<IncidenciaDA>();
builder.Services.AddScoped<TipoIncidenciaDA>();
builder.Services.AddScoped<EstadoDA>();
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

app.MapAreaControllerRoute(
            name: "Monitorizacion",
            areaName: "Monitorizacion",
            pattern: "Monitorizacion/{controller}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "Operacion",
            areaName: "Operaciones",
            pattern: "Operaciones/{controller}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
