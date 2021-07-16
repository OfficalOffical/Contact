using Contact.Business;
using Contact.DataAccess;
using Contact.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactDal _contactDal;

        public ContactsController(IContactDal ContactDal)
        {
            _contactDal = ContactDal;
        }

        [HttpGet]
        public List<ContactModel> Get()
        {
            var data = _contactDal.GetQuery().Include(i => i.ContactDetails).Select(i => new ContactModel
            {
                Id = i.Id,
                Name = i.Name,
                Surname = i.Surname,
                Birthday = i.Birthday,
                Company = i.Company,
                Note = i.Note,
                ContactDetails = i.ContactDetails.Select(j => new ContactDetailModel {
                    ContactId = j.ContactId,
                    Type = j.Type,
                    Value = j.Value,
                    Id = j.Id
                }).ToList()


            }).ToList();
            return data;

        }

        [HttpPost]
        public IActionResult Post(ContactModel model)
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

        _contactDal.Add(entity);
        return Ok();
        }
    }                   
}


    

