using PhoneBookApp.Data;
using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Ef.Repository.Interfaces;
using PhoneBookApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace PhoneBookApp.Services.Concrete
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookRepository _phoneBookRepo;
        private readonly EfDbContext _context;
        public PhoneBookService(IPhoneBookRepository phoneBookRepo, EfDbContext context)
        {
            _phoneBookRepo = phoneBookRepo;
            _context = context;
        }
        public int Add(PhoneBook pb)
        {
            return _phoneBookRepo.Add(pb, _context).Id;
        }

        public bool Delete(int pb)
        {
            var entry = _phoneBookRepo.Get(u => u.Id == pb, _context);
            return entry != null ? _phoneBookRepo.Delete(entry, _context) : false;
        }

        public PhoneBook Get(int id)
        {
            return _phoneBookRepo.Get(u => u.Id == id, _context);
        }

        public List<PhoneBook> GetAll()
        {
            return _phoneBookRepo.GetList(_context);
        }

        public PhoneBook Update(PhoneBook pb)
        {
            return _phoneBookRepo.Update(pb, _context);
        }
    }
}
