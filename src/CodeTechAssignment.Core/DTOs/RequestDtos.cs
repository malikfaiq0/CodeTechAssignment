namespace CodeTechAssignment.Core.DTOs
{
    public class RegisterUserDto
    {
        public string MobileNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Cnic { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty; // Added
    }

    public class MigrateUserDto
    {
        public string MobileNumber { get; set; } = string.Empty;
        public string OldAccountNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty; // Added
    }

    public class OtpRequestDto
    {
        public string MobileNumber { get; set; } = string.Empty;
    }

    public class OtpVerifyDto
    {
        public string MobileNumber { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty;
    }
}
