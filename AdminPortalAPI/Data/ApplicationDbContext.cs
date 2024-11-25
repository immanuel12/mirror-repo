using Admin_Portal_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Admin_Portal_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
