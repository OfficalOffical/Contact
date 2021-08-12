using Contact.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business
{

    public class DetailedContactService:IDetailedContactService
    {
        IContactDetailsDal _contactDetailsDal;
        public DetailedContactService(IContactDetailsDal contactDetailsDal)
        {
            _contactDetailsDal = contactDetailsDal;
        }

        public void DetailedDelete(int entitiesId)
        {
            var result = _contactDetailsDal.Get(x => x.Id == entitiesId);
            _contactDetailsDal.Delete(result);

        }
    }
}
