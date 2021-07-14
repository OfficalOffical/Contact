using Contact.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Entities
{
   public class Contact:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Company { get; set; }
        public string Birthday { get; set; }
        public string Note { get; set; }
        public List<ContactDetail> ContactDetails { get; set; }

    }
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Birthday { get; set; }
        public string Note { get; set; }

    }
}
