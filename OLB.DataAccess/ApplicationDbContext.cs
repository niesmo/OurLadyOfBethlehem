using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OLB.Domain;

namespace OLB.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ApplicationRequest>   ApplicationRequests { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ParentApplication> ParentApplications { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<ActionItem> ActionItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Key for the Student Parent Table
            modelBuilder.Entity<StudentParent>().HasKey(sp => new { sp.StudentId, sp.ParentId });

            // Key for the Parent Application Table
            modelBuilder.Entity<ParentApplication>().HasKey(pa => new { pa.ParentId, pa.ApplicationId });

            // Store enums as string in the db
            modelBuilder.Entity<ApplicationRequest>().Property(e => e.ApplicationRequestStatus).HasConversion<string>();
            modelBuilder.Entity<Classroom>().Property(e => e.AgeGroup).HasConversion<string>();
            modelBuilder.Entity<Enrollment>().Property(e => e.Day).HasConversion<string>();
            modelBuilder.Entity<Enrollment>().Property(e => e.EnrollmentStatus).HasConversion<string>();
            modelBuilder.Entity<ActionItem>().Property(e => e.ActionItemStatus).HasConversion<string>();
            modelBuilder.Entity<ActionItem>().Property(e => e.AgeGroup).HasConversion<string>();
            modelBuilder.Entity<ActionItem>().Property(e => e.ActionItemUrgency).HasConversion<string>();


            base.OnModelCreating(modelBuilder);
        }
        

    }
}
