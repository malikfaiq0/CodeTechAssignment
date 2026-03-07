namespace CodeTechAssignment.Core.Entities
{
    public class OtpRecord
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty;
        public DateTime ExpiryTime { get; set; }
        public bool IsUsed { get; set; }
    }
}
