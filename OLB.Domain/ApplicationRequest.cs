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
        public ApplicationRequestType ApplicationRequestType { get; set; }
        public Status ApplicationRequestStatus { get; set; }
        
        public enum Status
        {
            Sent,
            Expired,
            SubmittedApplication
        }
    }


    public enum ApplicationRequestType
    {
        Staff,
        Existing,
        New
    }
}
