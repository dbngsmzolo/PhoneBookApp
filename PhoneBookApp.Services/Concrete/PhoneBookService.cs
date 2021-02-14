using PhoneBookApp.Data;
using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Ef.Repository.Interfaces;
using PhoneBookApp.Data.Mappings;
using PhoneBookApp.Data.Models;
using PhoneBookApp.Services.Interfaces;
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
        public int Add(PhoneBookModel model)
        {
            var phoneBook = ToData.ToPhoneBookData(model);

            return _phoneBookRepo.Add(phoneBook, _context).Id;
        }

        public bool Delete(int? phoneBookId)
        {
            var entry = _phoneBookRepo.Get(u => u.Id == phoneBookId, _context);

            return entry != null ? _phoneBookRepo.Delete(entry, _context) : false;
        }

        public PhoneBook Get(int? id)
        {
            return _phoneBookRepo.Get(u => u.Id == id, _context);
        }

        public List<PhoneBookModel> GetAll()
        {
            var list = _phoneBookRepo.GetList(_context);

            return ToModel.ToPhoneBookModelList(list);
        }

        public void Update(PhoneBook phoneBook)
        {
            _phoneBookRepo.Update(phoneBook, _context);
        }
    }
}
