using Microsoft.EntityFrameworkCore;
using OLB.Domain;

namespace OLB.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ApplicationRequest>   Applications { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentParent>()
                .HasKey(sp => new { sp.StudentId, sp.ParentId });
            base.OnModelCreating(modelBuilder);
        }
        

    }
}
