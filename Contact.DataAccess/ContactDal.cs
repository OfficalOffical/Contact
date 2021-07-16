using Contact.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess
{
    public class ContactDal : EntityBase<Entities.Contact, PhoneDBContext>, IContactDal
    {
     
    }
}
