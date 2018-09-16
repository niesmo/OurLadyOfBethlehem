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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Key for the Student Parent Table
            modelBuilder.Entity<StudentParent>().HasKey(sp => new { sp.StudentId, sp.ParentId });

            // Key for the Parent Application Table
            modelBuilder.Entity<ParentApplication>().HasKey(pa => new { pa.ParentId, pa.ApplicationId });

            // Store enums as string in the db
            modelBuilder.Entity<ApplicationRequest>().Property(e => e.ApplicationRequestStatus).HasConversion(new EnumToStringConverter<ApplicationRequest.Status>());
            modelBuilder.Entity<Classroom>().Property(e => e.AgeGroup).HasConversion(new EnumToStringConverter<AgeGroup>());
            modelBuilder.Entity<Enrollment>().Property(e => e.Day).HasConversion(new EnumToStringConverter<Day>());
            modelBuilder.Entity<Enrollment>().Property(e => e.EnrollmentStatus).HasConversion(new EnumToStringConverter<Enrollment.Status>());


            base.OnModelCreating(modelBuilder);
        }
        

    }
}
