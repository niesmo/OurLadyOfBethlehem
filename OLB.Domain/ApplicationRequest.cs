using System;

namespace OLB.Domain
{
    public class ApplicationRequest
    {
        public Guid ApplicationRequestId { get; set; }
        public DateTimeOffset SubmissionDate { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public DateTimeOffset SentAtDate { get; set; }
        public Guid SentById { get; set; }
        public string SentToEmailAddress { get; set; }
        public Guid Token { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Sent,
        Expired,
        Submitted,
        Approved,
        Completed
    }

    public enum ApplicationType
    {
        Staff,
        Existing,
        New
    }
}
