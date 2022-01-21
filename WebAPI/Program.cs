var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/{id}", (int id) => $"��={id+1}");
app.MapGet("/", () => "<div>Hello world!</div>");

app.Run();

public partial class Program { }