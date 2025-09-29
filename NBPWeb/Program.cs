using Microsoft.EntityFrameworkCore;
using NBPWeb.IoC;
using NBPWebDatabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NbpDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("NBPDatabase"),
        b => b.MigrationsAssembly("NBPWebDatabase")));

builder.Services.AddIndividualServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NbpDbContext>();
    await db.Database.MigrateAsync();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Rates}/{action=Index}/{id?}");

app.Run();
