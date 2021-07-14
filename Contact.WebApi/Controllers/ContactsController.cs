using Contact.DataAccess;
using Contact.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IContactDal _directoryDal;

        public ContactsController(IContactDal directoryDal)
        {
            _directoryDal = directoryDal;
        }

        [HttpGet]
        public IEnumerable<ContactModel> Get()
        {
            var data = _directoryDal.GetList().Select(i => new ContactModel
            {

                Birthday = i.Birthday,
                Company = i.Company
            });
            return data;

        }
    }
}
