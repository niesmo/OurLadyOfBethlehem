using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace OLB.Web.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public DbSet<Application> Application { get; set; }
    }
    public class Application
    {
        public Guid ApplicationId { get; set; }
        public DateTimeOffset SubmissionDate { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public DateTimeOffset SentAtDate { get; set; }
        public Guid SentById { get; set; }
        public string SentToEmailAddress { get; set; }
        public Guid Token { get; set; }
        public ApplicationType ApplicationType { get; set; }
    }

    public enum ApplicationType
    {
        Staff,
        Existing,
        New
    }
}
