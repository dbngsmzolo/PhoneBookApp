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
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;
        public EntryController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Entry>> Get(int? phoneBookId)
        {
            if (phoneBookId == null)
                return BadRequest(ModelState);

            return Ok(_entryService.GetAllForPhoneBook(phoneBookId));
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(EntryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_entryService.Add(model));
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int? entryId)
        {
            if (entryId == null)
                return BadRequest(ModelState);

            return Ok(_entryService.Delete(entryId));
        }
    }
}
