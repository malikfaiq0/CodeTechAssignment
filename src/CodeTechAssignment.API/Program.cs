var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(context.Configuration));

// The API delegates DI registration to the respective layers
builder.Services.AddApplicationServices();

// Database Provider Switchboard
var dbProvider = builder.Configuration.GetValue<string>("DatabaseSettings:Provider");
if (dbProvider == "SqlServer")
{
    builder.Services.AddSqlServerPersistence(builder.Configuration);
}
else if (dbProvider == "Postgres")
{
    builder.Services.AddPostgresPersistence(builder.Configuration);
}
else if (dbProvider == "Oracle")
{
    builder.Services.AddOraclePersistence(builder.Configuration);
}
else
{
    throw new InvalidOperationException($"Unsupported database provider: {dbProvider}");
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global Exception Handling Middleware
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
