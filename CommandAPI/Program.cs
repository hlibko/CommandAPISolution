using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var postgreSqlConnection = builder.Configuration.GetConnectionString("PostgreSqlConnection");
builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(postgreSqlConnection));

builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
