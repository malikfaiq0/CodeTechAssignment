namespace CodeTechAssignment.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlServerPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Register SQL Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOtpRepository, OtpRepository>();

        return services;
    }
}
