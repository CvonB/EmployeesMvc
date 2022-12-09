using EmployeesMvc.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<EmployeeService>();
builder.Services.AddSingleton<IEmployeeService>(new JsonEmployeeService());
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(o => o.MapControllers());

app.Run();