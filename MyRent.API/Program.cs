using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using MyRent.API.Business.Model;
using MyRent.API.Rest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(builder.Environment.ContentRootPath, "DataSource"));

//builder.Configuration
builder.Services.AddDbContext<Entities>(options => options
    .UseSqlServer(builder.Configuration["Entities:target"]))
    .AddControllers()
    .AddOData(opt => opt.AddRouteComponents(builder.Configuration["dataschemaPrefix"], ODataBuilder.GetEdmModel())
    .Select()
    .Filter()
    .OrderBy()
    .SetMaxTop(20)
    .Count()
    .Expand());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UsePathBase(builder.Configuration["base"]);

app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapODataRoute("odata", ODataBuilder.GetEdmModel());
//});

//app.UseAuthorization();

app.MapControllers();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
