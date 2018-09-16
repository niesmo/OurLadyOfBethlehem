using Microsoft.EntityFrameworkCore;
using OLB.Domain;

namespace OLB.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Application>   Applications { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

    }
}
