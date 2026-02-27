using CodeBAssignment.API.Middleware;
using CodeBAssignment.Core.Interfaces;
using CodeBAssignment.Infrastructure.Data;
using CodeBAssignment.Infrastructure.Repositories;
using CodeBAssignment.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// 2. Dependency Injection 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOtpService, MockOtpService>();
builder.Services.AddScoped<IUserService, UserService>();

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