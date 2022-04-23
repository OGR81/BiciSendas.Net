var builder = WebApplication.CreateBuilder(args);

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
            pattern: "Monitorizacion/{controller=Incidencia}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "Monitorizacion",
            areaName: "Monitorizacion",
            pattern: "Monitorizacion/{controller=Sensor}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "Operacion",
            areaName: "Operacion",
            pattern: "Operacion/{controller=Actuador}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "Operacion",
            areaName: "Operaciones",
            pattern: "Operaciones/{controller=ElementoVia}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "Operacion",
            areaName: "Operaciones",
            pattern: "Operaciones/{controller=Faq}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();