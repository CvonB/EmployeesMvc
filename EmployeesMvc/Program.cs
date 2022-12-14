using EmployeesMvc.Models;
using EmployeesMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<EmployeeService>();
//builder.Services.AddSingleton<IEmployeeService>(new JsonEmployeeService());
var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EmployeesContext>(o => o.UseSqlServer(connString));

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(o => o.MapControllers());

app.Run();