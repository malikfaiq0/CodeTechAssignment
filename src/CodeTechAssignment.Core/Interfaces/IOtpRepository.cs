using CodeTechAssignment.Core.Entities;

namespace CodeTechAssignment.Core.Interfaces
{
    public interface IOtpRepository
    {
        Task AddOtpRecordAsync(OtpRecord otpRecord);
        Task<OtpRecord?> GetLatestValidOtpAsync(string mobileNumber, string otpCode);
        Task InvalidatePreviousOtpsAsync(string mobileNumber);
        Task SaveChangesAsync();
    }
}
