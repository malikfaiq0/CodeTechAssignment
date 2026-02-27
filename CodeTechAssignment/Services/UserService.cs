using CodeBAssignment.Core.DTOs;
using CodeBAssignment.Core.Entities;
using CodeBAssignment.Core.Interfaces;

namespace CodeBAssignment.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> RegisterNewCustomerAsync(RegisterUserDto request)
        {
            var existingUser = await _userRepository.GetUserByMobileAsync(request.MobileNumber);
            if (existingUser != null)
                throw new Exception("User with this mobile number already exists.");

            var newUser = new User
            {
                FullName = request.FullName,
                MobileNumber = request.MobileNumber,
                Cnic = request.Cnic,
                IsMigratedUser = false
            };

            await _userRepository.AddUserAsync(newUser);
            await _userRepository.SaveChangesAsync();

            return "New customer registered successfully.";
        }

        public async Task<string> MigrateExistingUserAsync(MigrateUserDto request)
        {
            var existingUser = await _userRepository.GetUserByMobileAsync(request.MobileNumber);
            if (existingUser != null)
                throw new Exception("User already exists in the new system.");

            // Here you would typically validate OldAccountNumber from a legacy DB. 
            // Since it's a test, we assume validation passes.

            var migratedUser = new User
            {
                FullName = "Migrated User", // In real scenario, fetch from legacy DB
                MobileNumber = request.MobileNumber,
                IsMigratedUser = true
            };

            await _userRepository.AddUserAsync(migratedUser);
            await _userRepository.SaveChangesAsync();

            return "Existing user migrated successfully.";
        }
    }
}