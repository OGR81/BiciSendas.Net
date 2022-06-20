using BiciSendas.BL;
using BiciSendas.DA;
using BiciSendas.DA.DA;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection serviceCollection = builder.Services.AddDbContext<BicisendasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BicisendasContext")), ServiceLifetime.Transient);
//DA
builder.Services.AddScoped<IncidenciaDA>();
builder.Services.AddScoped<TipoIncidenciaDA>();
builder.Services.AddScoped<EstadoDA>();
builder.Services.AddScoped<ActuadorDA>();
builder.Services.AddScoped<ElementoViaDA>();
builder.Services.AddScoped<FaqDA>();
builder.Services.AddScoped<SensorDA>();
builder.Services.AddScoped<TipoSensorDA>();
builder.Services.AddScoped<EstadoSensorDA>();
builder.Services.AddScoped<TipoActuadorDA>();
//BL
builder.Services.AddScoped<EstadoBL>();
builder.Services.AddScoped<IncidenciaBL>();
builder.Services.AddScoped<ElementoViaBL>();
builder.Services.AddScoped<FaqBL>();
builder.Services.AddScoped<SensorBL>();
builder.Services.AddScoped<EstadoSensorBL>();
builder.Services.AddScoped<TipoActuadorBL>();
builder.Services.AddScoped<ActuadorBL>();
builder.Services.AddScoped<TipoSensorBL>();
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
