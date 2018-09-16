using System;

namespace OLB.Domain
{
    public class Enrollment
    {
        public Guid EnrollmentId { get; set; }
        public Day Day { get; set; }
        public Status EnrollmentStatus { get; set; }
        public bool IsFlexible { get; set; }
        public DateTime StartDate { get; set; }
        public Guid ApplicationId { get; set; }
        public enum Status
        {
            Requested,
            Waitlisted,
            Enrolled,
            Declined
        }
    }

    public enum Day
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}