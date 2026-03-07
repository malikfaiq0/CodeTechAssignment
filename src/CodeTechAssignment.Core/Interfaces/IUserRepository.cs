using CodeTechAssignment.Core.Entities;

namespace CodeTechAssignment.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByMobileAsync(string mobileNumber);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}
