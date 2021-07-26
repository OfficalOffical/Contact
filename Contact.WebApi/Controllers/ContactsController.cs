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
using NLog;

namespace Contact.WebApi.Controllers 
{
    
    
        

    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private static Logger logger = LogManager.GetLogger("ContactRule");

        public ContactsController(IContactService contactService)
        {
            _contactService=contactService;
        }

        [HttpGet]
        public List<ContactModel> Get()
        {
            logger.Info("vololo");
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
        public IActionResult Delete(int EntityId)
        {
            _contactService.Delete(EntityId);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(ContactModel contactModel)
        {
            _contactService.Update(contactModel);
            return Ok();
        }
    }                   
}


    

