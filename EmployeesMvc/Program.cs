using EmployeesMvc.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<EmployeeService>();
builder.Services.AddSingleton<EmployeeService>();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(o => o.MapControllers());

app.Run();