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
using Microsoft.Extensions.Logging;

namespace Contact.WebApi.Controllers 
{
    
    
        

    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public List<ContactModel> Get()
        {
            _logger.LogInformation("Entities printed successfuly");
            var data = _contactService.GetList();


            return data;

        }

        [HttpPost]
        public IActionResult Post(ContactModel model)
        {
            try
            {
                _logger.LogInformation("New entity added");
                _contactService.Add(_contactService.GetPost(model));
                
            }
            catch (Exception e)
            {
                _logger.LogError("Invalid input : " + e.Message);
                return BadRequest();
            }
            return Ok();

        }
        [HttpDelete]
        public IActionResult Delete(int EntityId)
        {
            try
            {
                _logger.LogInformation("Entity with Id : " + EntityId.ToString() + " successfuly deleted");
                _contactService.Delete(EntityId);
                
            }
            catch (Exception e)
            {
                _logger.LogError("Invalid input : " + e.Message);
                return BadRequest();
            }


            return Ok();

        }
        [HttpPut]
        public IActionResult Update(ContactModel contactModel)
        {
            try
            {
                _logger.LogInformation("Entity with Id : " + contactModel.Id.ToString() + " successfuly updated");
                _contactService.Update(contactModel);
            }
            catch (Exception e)
            {
                _logger.LogError("Invalid input : " + e.Message);
                return BadRequest();
            }
            return Ok();
        }
    }                   
}


    

