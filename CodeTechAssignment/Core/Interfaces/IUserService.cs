using CodeBAssignment.Core.DTOs;

namespace CodeBAssignment.Core.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterNewCustomerAsync(RegisterUserDto request);
        Task<string> MigrateExistingUserAsync(MigrateUserDto request);
    }
}