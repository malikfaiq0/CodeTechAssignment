namespace CodeTechAssignment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLogic(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOtpService, MockOtpService>();

        return services;
    }
}
