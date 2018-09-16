using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLB.Domain
{
    public class ParentApplication
    {
        public Guid ParentId { get; set; }
        public Parent Parent { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
