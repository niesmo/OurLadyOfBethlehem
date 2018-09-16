using System;
using System.Collections.Generic;
using System.Text;

namespace OLB.Domain
{
    public class Classroom
    {
        public Guid ClassroomId { get; set; }
        public string Name { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public int Capacity { get; set; }
    }

    public enum AgeGroup
    {
        Infant,
        Toddler
    }
}
