namespace CodeTechAssignment.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // services.AddDbContext<AppDbContext>(options =>
        //     options.UseNpgsql(connectionString));

        // TODO: Create Postgres-specific Repository implementations
        // services.AddScoped<IUserRepository, PostgresUserRepository>();
        // services.AddScoped<IOtpRepository, PostgresOtpRepository>();

        return services;
    }
}
