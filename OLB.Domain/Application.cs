using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLB.Domain
{
    public class Application
    {
        public Guid ApplicationId { get; set; }
        public List<Parent> Parents { get; set; }
        public Student Student { get; set; }
        public bool ApplicationFeePaid { get; set; }
        public bool ApplicationFeeWaived { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public DateTimeOffset SubmissionDate { get; set; }
    }
}
