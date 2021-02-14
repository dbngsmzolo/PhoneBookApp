using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Models;
using PhoneBookApp.Services.Interfaces;
using System.Collections.Generic;

namespace PhoneBookApp.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _pbService;
        public PhoneBookController(IPhoneBookService pbService)
        {
            _pbService = pbService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<PhoneBook>> Get()
        {
            return Ok(_pbService.GetAll());
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(PhoneBookModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_pbService.Add(model));
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int? phoneBookId)
        {
            if (phoneBookId == null)
                return BadRequest(ModelState);

            return Ok(_pbService.Delete(phoneBookId));
        }
    }
}
