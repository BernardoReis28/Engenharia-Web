using Microsoft.EntityFrameworkCore;
using Tutorial_06;
using Tutorial_06.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Class06Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Class06Context")));

builder.Services.AddTransient<DbInitializer>();

builder.Services.AddRouting(options =>
options.ConstraintMap.Add("myRule", typeof(MyRulesConstraint)));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var initializer = services.GetRequiredService<DbInitializer>();
initializer.Run();


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
    name: "Ordered",
    pattern: "Order/{by}/{way?}",
    defaults: new { Controller = "Students", Action = "Index3" },
    constraints: new { by = @"(byNumber|byName)", way = @"(ascending|descending)" });

app.MapControllerRoute(
    name: "Filtered",
    pattern: "Filter/{letter?}",
    defaults: new { Controller = "Students", Action = "Index2" },
    constraints: new { letter = @"[A-Zбаис]" }); //regular expression to validate "letter" field

//------------------------------------------------------------------------------------------

//"Inline Constraint" constraint for "Checking Data Types"
// See more at https://www.tektutorialshub.com/asp-net-core/asp-net-core-route-constraints/
//app.MapControllerRoute(
//    name: "filtered2",
//    pattern: "Filter/{letter:alpha:length(1)?}",
//    defaults: new { Controller = "Students", Action = "Index2" }); 

//------------------------------------------------------------------------------------------

//app.MapControllerRoute(
//    name: "filtered4",
//    pattern: "Filter/{letter:myRule?}", // fourth version using the same class in inline format
//    defaults: new { Controller = "Students", Action = "Index2" }); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
