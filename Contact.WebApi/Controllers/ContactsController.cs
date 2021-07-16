using Contact.Business;
using Contact.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Microsoft.EntityFrameworkCore;
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
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService=contactService;
        }

        [HttpGet]
        public List<ContactModel> Get()
        {

            var data = _contactService.GetList();


            return data;

        }

        [HttpPost]
        public IActionResult Post(ContactModel model)
        {
            _contactService.Add(_contactService.GetPost(model));
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(Entities.Contact entity)
        {
            _contactService.Delete(entity);
            return Ok();
        }
    }                   
}


    

