using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities
{
   public class ContactDetail
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Value{ get; set; }
        public int Type { get; set; }
        public Contact Contact { get; set; }
    }

}
