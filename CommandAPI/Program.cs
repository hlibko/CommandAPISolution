using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var npgsqlConBuilder = new NpgsqlConnectionStringBuilder();
npgsqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
npgsqlConBuilder.Username = builder.Configuration["UserID"];
npgsqlConBuilder.Password = builder.Configuration["Password"];
builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(npgsqlConBuilder.ConnectionString));

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

var app = builder.Build();

// migrate database changes on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CommandContext>();
    db.Database.Migrate();
}


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
