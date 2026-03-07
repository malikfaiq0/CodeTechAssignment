using CodeTechAssignment.Domain.Entities;

namespace CodeTechAssignment.Application.Interfaces
{
    public interface IOtpRepository
    {
        Task AddOtpRecordAsync(OtpRecord otpRecord);
        Task<OtpRecord?> GetLatestValidOtpAsync(string mobileNumber, string otpCode);
        Task InvalidatePreviousOtpsAsync(string mobileNumber);
        Task SaveChangesAsync();
    }
}
