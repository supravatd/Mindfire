using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.Models
{
    public class UserResult
    {
        public List<UserModel> Users { get; set; }
        public int TotalPages { get; set; }
    }
}
