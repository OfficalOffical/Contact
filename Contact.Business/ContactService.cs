using Contact.DataAccess;
using Contact.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Contact.Business
{
    public class ContactService : IContactService
    {
        IContactDal _contactDal;

        public ContactService(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Entities.Contact entity)
        {
            _contactDal.Add(entity);
        }

        public  Entities.Contact ConverterBtoE(ContactModel contactModel)
        {
            //contactModel.ContactDetails = new ContactDetailModel;
            var data = new Entities.Contact
            {
                Id = contactModel.Id,
                Birthday = contactModel.Birthday,
                Company = contactModel.Company,
                Name = contactModel.Name,
                Note = contactModel.Note,
                Surname = contactModel.Surname,
                ContactDetails = contactModel.ContactDetails.Select(i => new ContactDetail
                {
                    ContactId = i.ContactId,
                    Id = i.Id,
                    Type = i.Type,
                    Value = i.Value
                }).ToList()
            };

            return data;
       
            
        }

        public List<ContactModel> GetList()
        {
            var data = _contactDal.GetQuery().Include(i => i.ContactDetails).Select(i => new ContactModel
            {
                Id = i.Id,
                Name = i.Name,
                Surname = i.Surname,
                Birthday = i.Birthday,
                Note = i.Note,
                Company = i.Company,
                ContactDetails = i.ContactDetails.Select(j => new ContactDetailModel
                {
                    ContactId = j.ContactId,
                    Id = j.Id,
                    Type = j.Type,
                    Value = j.Value
                }).ToList()
            }).ToList();



            return data;
        }
        public Entities.Contact GetPost(ContactModel model)
        {
            var entity = new Entities.Contact
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Note = model.Note,
                Birthday = model.Birthday,
                Company = model.Company,
                ContactDetails = model.ContactDetails.Select(i => new ContactDetail
                {
                    Id = i.Id,
                    ContactId = i.ContactId,
                    Value = i.Value,
                    Type = i.Type
                }).ToList()
            };

            return entity;
        }

        public void Delete(int entitiesId)
        {
            var result = _contactDal.Get(x => x.Id == entitiesId);
            // Create a control mechanism here 
            _contactDal.Delete(result);
        }

        public void Update(ContactModel contactModel)
        {
            
            _contactDal.Update(ConverterBtoE(contactModel));
            
        }
    }
}
