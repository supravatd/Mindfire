using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }
        public string MotherLastName { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string BloodGroup { get; set; }
        public string MobileNo { get; set; }
        public string IDType { get; set; }
        public string IDNo { get; set; }
        public string Gender {  get; set; }
        public string Hobbies { get; set;}

        public AddressModel PresentAddress { get; set; }
        public AddressModel PermanentAddress { get; set; }
    }
}
