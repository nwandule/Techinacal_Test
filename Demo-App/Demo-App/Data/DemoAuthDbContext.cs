using Demo_App.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo_App.Data
{
    public class DemoAuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public DemoAuthDbContext(DbContextOptions<DemoAuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed roles
            var readerRoleId = "2a9823ea-9fd2-4416-b29f-cfadcb495133";
            var writerRoleId = "2137b0de-75d6-4890-9a00-6b669ee5de1e";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER"
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<ApplicationUser>()
         .Property(u => u.UpdatedAt)
         .HasColumnType("datetime") // no (6), just plain datetime
         .HasDefaultValueSql("CURRENT_TIMESTAMP")
         .ValueGeneratedOnAddOrUpdate();
        }
    }
}
