using System.Collections.Generic;
using System.Linq;

namespace Contact.Business
{
    public interface IContactService
    {
        public void Add(Contact.Entities.Contact entity);
        List<ContactModel> GetList();
        Entities.Contact GetPost(ContactModel model);
        public void Delete(int entitiesId);
        public void Update(ContactModel contactModel);

        public Entities.Contact ConverterBtoE(ContactModel contactModel);
    }
}