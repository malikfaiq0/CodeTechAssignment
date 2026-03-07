namespace CodeTechAssignment.Application.Interfaces
{
    public interface IOtpService
    {
        Task<string> GenerateAndSendOtpAsync(string mobileNumber);
        Task<bool> ValidateOtpAsync(string mobileNumber, string otpCode);
    }
}
