namespace CodeTechAssignment.Repositories;

public class OtpRepository : IOtpRepository
{
    private readonly AppDbContext _context;

    public OtpRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddOtpRecordAsync(OtpRecord otpRecord)
    {
        await _context.OtpRecords.AddAsync(otpRecord);
    }

    public async Task<OtpRecord?> GetLatestValidOtpAsync(string mobileNumber, string otpCode)
    {
        return await _context.OtpRecords
            .Where(o => o.MobileNumber == mobileNumber && o.OtpCode == otpCode && !o.IsUsed)
            .OrderByDescending(o => o.ExpiryTime)
            .FirstOrDefaultAsync();
    }

    public async Task InvalidatePreviousOtpsAsync(string mobileNumber)
    {
        var activeOtps = await _context.OtpRecords
            .Where(o => o.MobileNumber == mobileNumber && !o.IsUsed)
            .ToListAsync();

        foreach (var otp in activeOtps)
        {
            otp.IsUsed = true;
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
