using ExerciseProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProject.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Epmloyee> EpmloyeesDbSet { get; set; }
        public DbSet<SalaryDetails> salaryDetailsDbSet { get; set; }

    }
}
