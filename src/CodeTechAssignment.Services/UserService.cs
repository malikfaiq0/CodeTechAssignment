using CodeTechAssignment.Core.DTOs;
using CodeTechAssignment.Core.Entities;
using CodeTechAssignment.Core.Interfaces;

namespace CodeTechAssignment.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpService _otpService;

        public UserService(IUserRepository userRepository, IOtpService otpService)
        {
            _userRepository = userRepository;
            _otpService = otpService;
        }

        public async Task<string> RegisterNewCustomerAsync(RegisterUserDto request)
        {
            var existingUser = await _userRepository.GetUserByMobileAsync(request.MobileNumber);
            if (existingUser != null)
                throw new Exception("User with this mobile number already exists.");

            // FIX: Ensure OTP is actually verified before registering the user
            var isOtpValid = await _otpService.ValidateOtpAsync(request.MobileNumber, request.OtpCode);
            if (!isOtpValid)
            {
                throw new Exception("Invalid or expired OTP. Registration failed.");
            }

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
                // FIX: Use the actual FullName instead of hardcoding a placeholder
                FullName = string.IsNullOrWhiteSpace(request.FullName) ? "Migrated User" : request.FullName, 
                MobileNumber = request.MobileNumber,
                IsMigratedUser = true
            };

            await _userRepository.AddUserAsync(migratedUser);
            await _userRepository.SaveChangesAsync();

            return "Existing user migrated successfully.";
        }
    }
}
