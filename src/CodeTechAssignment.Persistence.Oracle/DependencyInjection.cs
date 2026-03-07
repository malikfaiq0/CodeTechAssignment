namespace CodeTechAssignment.Persistence.Oracle;

public static class DependencyInjection
{
    public static IServiceCollection AddOraclePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseOracle(connectionString));

        return services;
    }
}
