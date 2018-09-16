using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLB.Domain
{
    public class Parent
    {
        public Guid ParentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string HomePhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public List<StudentParent> StudentParents { get; set; }

    }

    public class Address
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public string StreetSecondary { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

    }
}
