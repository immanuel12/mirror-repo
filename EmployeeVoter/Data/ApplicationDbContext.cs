using EmployeeVoter.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace EmployeeVoter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //public DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<ChoiceVoter> ChoiceVoter { get; set; }
    }
}
