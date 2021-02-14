using PhoneBookApp.Data;
using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Ef.Repository.Interfaces;
using PhoneBookApp.Data.Mappings;
using PhoneBookApp.Data.Models;
using PhoneBookApp.Services.Interfaces;
using System.Collections.Generic;

namespace PhoneBookApp.Services.Concrete
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepo;
        private readonly IPhoneBookService _pbService;
        private readonly EfDbContext _context;
        public EntryService(IEntryRepository userRepo, IPhoneBookService pbService, EfDbContext context)
        {
            _entryRepo = userRepo;
            _pbService = pbService;
            _context = context;
        }

        public int Add(EntryModel model)
        {
            var entry = ToData.ToEntryData(model);
            int entryId = _entryRepo.Add(entry, _context).Id;
            var phoneBook = _pbService.Get(entry.PhoneBookId);

            if (phoneBook.Entries == null) phoneBook.Entries = new List<Entry>();

            phoneBook.Entries.Add(entry);
            _pbService.Update(phoneBook);

            return entryId;
        }

        public bool Delete(int? entryId)
        {
            var entry = _entryRepo.Get(u => u.Id == entryId, _context);
            return entry != null ? _entryRepo.Delete(entry, _context) : false;
        }

        public EntryModel Get(int? id)
        {
            var entry = _entryRepo.Get(u => u.Id == id, _context);

            return ToModel.ToEntryModel(entry);
        }

        public List<EntryModel> GetAllForPhoneBook(int? phoneBookId)
        {
            var list = _entryRepo.GetList(_context, e => e.PhoneBookId == phoneBookId);

            return ToModel.ToEntryModelList(list);

        }
    }
}
