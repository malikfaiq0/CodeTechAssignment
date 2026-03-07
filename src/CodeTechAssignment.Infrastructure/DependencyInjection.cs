namespace CodeTechAssignment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. The Database Switchboard
        var dbProvider = configuration.GetValue<string>("DatabaseSettings:Provider");
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (dbProvider == "SqlServer")
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
        else if (dbProvider == "Postgres")
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));
        }
        else
        {
            throw new InvalidOperationException($"Unsupported database provider: {dbProvider}");
        }

        // 2. Register Repositories & Infrastructure Services
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOtpRepository, OtpRepository>();

        return services;
    }
}
