using CodeTechAssignment.Application.DTOs;

namespace CodeTechAssignment.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterNewCustomerAsync(RegisterUserDto request);
        Task<string> MigrateExistingUserAsync(MigrateUserDto request);
    }
}
