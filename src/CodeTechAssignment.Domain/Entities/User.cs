namespace CodeTechAssignment.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Cnic { get; set; } = string.Empty;
        public bool IsMigratedUser { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
