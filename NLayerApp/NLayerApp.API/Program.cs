var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello user");

app.Run();