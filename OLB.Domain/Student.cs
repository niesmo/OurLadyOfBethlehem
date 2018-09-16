using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLB.Domain
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ImageUrl { get; set; }
        public List<StudentParent> StudentParents { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
