using System;
using System.Collections.Generic;
using System.Text;

namespace OLB.Domain
{
    public class Classroom
    {
        public Guid ClassroomId { get; set; }
        public string Name { get; set; }
        public ClassroomGrade Grade { get; set; }
        public int Capacity { get; set; }
    }

    public enum ClassroomGrade
    {
        Infint,
        Toddler
    }
}
