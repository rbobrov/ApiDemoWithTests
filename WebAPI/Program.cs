using WebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<WebAPIContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("WebAPIContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<WebAPIContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.MapControllers();
app.Run();

public partial class Program { }