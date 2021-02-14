using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Services.Interfaces
{
    public interface IPhoneBookService
    {
        List<PhoneBookModel> GetAll();
        PhoneBook Get(int? PhoneBookId);
        bool Delete(int? PhoneBookId);
        int Add(PhoneBookModel model);
        void Update(PhoneBook phoneBook);

    }
}
