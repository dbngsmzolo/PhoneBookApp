using System;
using System.Collections.Generic;
using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhoneBookApp.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
