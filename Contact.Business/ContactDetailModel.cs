using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business
{

        public class ContactDetailModel
        {
            public int Id { get; set; }
            public int ContactId { get; set; }
            public string Value { get; set; }   
            public int Type { get; set; }
        }

}
