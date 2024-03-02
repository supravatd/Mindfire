using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.Models
{
    public class AddressModel
    {
        public int Type { get; set; }
        public string DoorNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int UserId {  get; set; }
    }
}
