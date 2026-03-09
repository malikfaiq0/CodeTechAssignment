namespace CodeTechAssignment.Application;

public interface IUserService
{
    Task<string> RegisterNewCustomerAsync(RegisterUserDto request);
    Task<string> MigrateExistingUserAsync(MigrateUserDto request);
}
