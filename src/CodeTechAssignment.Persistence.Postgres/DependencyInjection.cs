namespace CodeTechAssignment.Persistence.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        return services;
    }
}
