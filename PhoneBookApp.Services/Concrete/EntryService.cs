using PhoneBookApp.Data;
using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Ef.Repository.Interfaces;
using PhoneBookApp.Services.Interfaces;
using System;
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
        public int Add(Entry entry)
        {
            int entryId =_entryRepo.Add(entry, _context).Id;
            PhoneBook pb = _pbService.Get(entry.PhoneBookId);
            if(pb.Entries == null)
            {
                pb.Entries = new List<Entry>();
            }
            pb.Entries.Add(entry);
            _pbService.Update(pb);
            return entryId;
        }

        public bool Delete(int EntryId)
        {
            var entry = _entryRepo.Get(u => u.Id == EntryId, _context);
            return entry != null ? _entryRepo.Delete(entry, _context) : false;
        }

        public Entry Get(int id)
        {
            return _entryRepo.Get(u => u.Id == id, _context);
        }

        public List<Entry> GetAll()
        {
            return _entryRepo.GetList(_context);
        }

        public List<Entry> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        List<Entry> IEntryService.GetAllForPhoneBook(int phoneBookId)
        {
            return _entryRepo.GetList(_context, e => e.PhoneBookId == phoneBookId);

        }
    }
}
