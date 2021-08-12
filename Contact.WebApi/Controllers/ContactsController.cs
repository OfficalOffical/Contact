using Contact.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Contact.WebApi.Controllers
{
    public class ResponseModel<T>
    {
        public List<T> Data { get; set; }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IDetailedContactService _detailedContactService;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService contactService, ILogger<ContactsController> logger, IDetailedContactService detailedContactService )
        {
            _detailedContactService = detailedContactService;
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Entities printed successfuly");
            var data = _contactService.GetList();

            var model = new ResponseModel<ContactModel>()
            {
                Data = new List<ContactModel>()
            };
            model.Data = data;
            

            return Ok(model);

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
        public IActionResult Put( ContactModel contactModel)
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

        [HttpDelete("deletedetail")]
        public IActionResult Delete2(int EntityId)
        {
            try
            {
                _logger.LogInformation("Entity with Id : " + EntityId.ToString() + " successfuly deleted");
                _detailedContactService.DetailedDelete(EntityId);


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




