using Microsoft.EntityFrameworkCore;
using HelloWorldApp.Models;

namespace HelloWorldApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<NameEntry> NameEntries { get; set; }
    }
}
