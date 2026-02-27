using CodeBAssignment.Core.Entities;
using CodeBAssignment.Core.Interfaces;
using CodeBAssignment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeBAssignment.Services
{
    public class MockOtpService : IOtpService
    {
        private readonly AppDbContext _context;

        public MockOtpService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateAndSendOtpAsync(string mobileNumber)
        {
            // Generate 4-digit mock OTP
            string otp = new Random().Next(1000, 9999).ToString();

            var otpRecord = new OtpRecord
            {
                MobileNumber = mobileNumber,
                OtpCode = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5), // 5 mins expiry
                IsUsed = false
            };

            _context.OtpRecords.Add(otpRecord);
            await _context.SaveChangesAsync();

            return otp; // Returning just to see it in postman/swagger
        }

        public async Task<bool> ValidateOtpAsync(string mobileNumber, string otpCode)
        {
            var record = await _context.OtpRecords
                .Where(o => o.MobileNumber == mobileNumber && o.OtpCode == otpCode && !o.IsUsed)
                .OrderByDescending(o => o.ExpiryTime)
                .FirstOrDefaultAsync();

            if (record == null || record.ExpiryTime < DateTime.UtcNow)
                return false;

            record.IsUsed = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}