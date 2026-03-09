namespace CodeTechAssignment.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByMobileAsync(string mobileNumber);
    Task AddUserAsync(User user);
    Task SaveChangesAsync();
}
