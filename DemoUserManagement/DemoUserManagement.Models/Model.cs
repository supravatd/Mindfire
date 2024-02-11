using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagement.Models
{
    public class Model
    {
        public class CountryModel
        {
            public int CountryId { get; set; }
            public string CountryName { get; set; }
        }

        public class StateModel
        {
            public int StateId { get; set; }
            public string StateName { get; set; }
            public int CountryId { get; set; }
        }
    }
}
