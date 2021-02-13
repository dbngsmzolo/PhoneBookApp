using System;
using System.Collections.Generic;
using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
        [Route("get")]
        public ActionResult<Entry> Get(int id)
        {
            return Ok(_pbService.Get(id));
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<PhoneBook>> Get()
        {
            return Ok(_pbService.GetAll());
        }

        [HttpPut]
        [Route("add")]
        public ActionResult Add(PhoneBook pb)
        {
            return Ok(_pbService.Add(pb));
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int pbId)
        {
            return Ok(_pbService.Delete(pbId));
        }
    }
}
