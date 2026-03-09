namespace CodeTechAssignment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationContracts(this IServiceCollection services)
    {
        // Application layer now only holds DTOs and Interfaces.
        // Implementations moved to Infrastructure/API.
        return services;
    }
}
