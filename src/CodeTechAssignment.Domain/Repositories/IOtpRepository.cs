namespace CodeTechAssignment.Repositories;

public interface IOtpRepository
{
    Task AddOtpRecordAsync(OtpRecord otpRecord);
    Task<OtpRecord?> GetLatestValidOtpAsync(string mobileNumber, string otpCode);
    Task InvalidatePreviousOtpsAsync(string mobileNumber);
    Task SaveChangesAsync();
}
