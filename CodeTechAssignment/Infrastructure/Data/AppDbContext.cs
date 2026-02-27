using CodeBAssignment.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeBAssignment.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<OtpRecord> OtpRecords { get; set; }
    }
}