using CodeBAssignment.Core.Entities;

namespace CodeBAssignment.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByMobileAsync(string mobileNumber);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}