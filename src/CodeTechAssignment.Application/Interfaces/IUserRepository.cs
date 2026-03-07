using CodeTechAssignment.Domain.Entities;

namespace CodeTechAssignment.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByMobileAsync(string mobileNumber);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}
