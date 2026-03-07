namespace CodeTechAssignment.Services;

public class MockOtpService : IOtpService
{
    private readonly IOtpRepository _otpRepository;

    public MockOtpService(IOtpRepository otpRepository)
    {
        _otpRepository = otpRepository;
    }

    public async Task<string> GenerateAndSendOtpAsync(string mobileNumber)
    {
        // Invalidate any existing unused OTPs for this number
        await _otpRepository.InvalidatePreviousOtpsAsync(mobileNumber);

        // Generate 4-digit mock OTP
        string otp = new Random().Next(1000, 9999).ToString();

        var otpRecord = new OtpRecord
        {
            MobileNumber = mobileNumber,
            OtpCode = otp,
            ExpiryTime = DateTime.UtcNow.AddMinutes(5), // 5 mins expiry
            IsUsed = false
        };

        await _otpRepository.AddOtpRecordAsync(otpRecord);
        await _otpRepository.SaveChangesAsync();

        return otp; // Returning just to see it in postman/swagger
    }

    public async Task<bool> ValidateOtpAsync(string mobileNumber, string otpCode)
    {
        var record = await _otpRepository.GetLatestValidOtpAsync(mobileNumber, otpCode);

        if (record == null || record.ExpiryTime < DateTime.UtcNow)
            return false;

        record.IsUsed = true;
        await _otpRepository.SaveChangesAsync();
        return true;
    }
}
