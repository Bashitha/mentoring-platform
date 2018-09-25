using Microsoft.EntityFrameworkCore;
using Security.Domain.Entities;

namespace Security.Infrastructure.Data
{
    public class MentoringPlatformSecurityContext : DbContext
    {
        //Add-Migration InitialMigrationUserandUserRole -Project Security.Infrastructure
        //Update-Database
        //Remove-Migration
        public MentoringPlatformSecurityContext(DbContextOptions<MentoringPlatformSecurityContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
