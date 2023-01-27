using Microsoft.EntityFrameworkCore;
using MyRent.API.Business.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(builder.Environment.ContentRootPath, "DataSource"));

var tz = AppDomain.CurrentDomain;
//builder.Environment.ContentRootPath

//builder.Configuration
builder.Services.AddDbContext<Entities>(options => options
    .UseSqlServer(builder.Configuration["Entities:target"]));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
