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

        public class DocumentTypeModel
        {
            public string DocumentTypeName { get; set; }
            public int DocumentTypeID { get; set; }
        }

        public class DocumentModel
        {
            public int DocumentID { get; set; }
            public int ObjectID { get; set; }
            public int ObjectType { get; set; }
            public int DocumentType { get; set; }
            public string DocumnetNameOnDisk { get; set; }
            public string DocumentOriginalName { get; set; }
            public string AddedOn { get; set; }
        }
    }
}
