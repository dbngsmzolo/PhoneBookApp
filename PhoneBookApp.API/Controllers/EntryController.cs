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
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;
        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Entry>> Get(int id)
        {
            return Ok(_entryService.GetAllForPhoneBook(id));
        }

        [HttpPut]
        [Route("add")]
        public ActionResult Add(Entry entry)
        {
            return Ok(_entryService.Add(entry));
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int entryId)
        {
            return Ok(_entryService.Delete(entryId));
        }
    }
}
