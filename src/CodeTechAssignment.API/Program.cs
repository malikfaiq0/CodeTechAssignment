using CodeTechAssignment.API.Middleware;
using CodeTechAssignment.API.Validators;
using CodeTechAssignment.Core.Interfaces;
using CodeTechAssignment.Infrastructure.Data;
using CodeTechAssignment.Infrastructure.Repositories;
using CodeTechAssignment.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(context.Configuration));

// 1. Add DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Dependency Injection 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOtpRepository, OtpRepository>(); // Fixed DIP Violation
builder.Services.AddScoped<IOtpService, MockOtpService>();
builder.Services.AddScoped<IUserService, UserService>();

// Add Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserDtoValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Expose APIs [cite: 2]

var app = builder.Build();

// 3. Global Exception Handling Middleware
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization(); // No Auth required, but keeping default middleware
app.MapControllers();

app.Run();

public partial class Program { }