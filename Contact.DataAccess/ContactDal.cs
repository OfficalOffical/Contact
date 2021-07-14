using Contact.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess
{
  public  class ContactDal:IEntityBase<Entities.Contact,PhoneDBContext>, IContactDal
    {
        
        
    }
}
