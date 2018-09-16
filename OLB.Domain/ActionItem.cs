using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLB.Domain
{
    public class ActionItem
    {
        public Guid ActionItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Urgency ActionItemUrgency { get; set; }
        public Status ActionItemStatus { get; set; }
        public Guid RequestedBy { get; set; }
        public DateTimeOffset RequestedAt { get; set; }
        public Guid CompletedBy { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public AgeGroup AgeGroup { get; set; }

        public enum Urgency
        {
            Low,
            Medium,
            High
        }

        public enum Status
        {
            Requsted,
            Completed
        }
    }
}
