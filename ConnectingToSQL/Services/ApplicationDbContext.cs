using ConnectingToSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectingToSQL.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)      
        {
                
        }
        public DbSet<Course> Courses { get; set; }
    }
}
