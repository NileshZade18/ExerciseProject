using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var Roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id="e00296de-f37c-4642-8846-052c8ede7cd6",
                    Name="Reader",
                    ConcurrencyStamp="e00296de-f37c-4642-8846-052c8ede7cd6",
                    NormalizedName="READER"
                },
                new IdentityRole
                {
                    Id="edaf9206-68fa-4dc8-826c-822e8773d075",
                    Name="Writer",
                    ConcurrencyStamp="edaf9206-68fa-4dc8-826c-822e8773d075",
                    NormalizedName="WRITER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(Roles);
        }
    }
}
