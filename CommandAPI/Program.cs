using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var npgsqlConBuilder = new NpgsqlConnectionStringBuilder();
npgsqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
npgsqlConBuilder.Username = builder.Configuration["UserID"];
npgsqlConBuilder.Password = builder.Configuration["Password"];
builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(npgsqlConBuilder.ConnectionString));

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
