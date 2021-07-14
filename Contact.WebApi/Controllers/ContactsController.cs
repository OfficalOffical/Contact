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
                ContactDetails = i.ContactDetails.Select(j=>new ContactDetailModel { 
                ContactId = j.ContactId,
                Type = j.Type,
                Value = j.Value,
                Id = j.Id                         
                }).ToList()


            }).ToList();
            return data;

        }

        [HttpPost]
        public IActionResult Post( ContactModel model)
        {
            


            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
