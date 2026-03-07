using CodeTechAssignment.Core.DTOs;

namespace CodeTechAssignment.Core.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterNewCustomerAsync(RegisterUserDto request);
        Task<string> MigrateExistingUserAsync(MigrateUserDto request);
    }
}
