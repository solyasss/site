using _03._03hw.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

string conn_str = builder.Configuration.GetConnectionString("default_connection");
builder.Services.AddDbContext<movie_context>(options => options.UseSqlServer(conn_str));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}"
);

app.Run();