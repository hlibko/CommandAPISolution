using CommandAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
