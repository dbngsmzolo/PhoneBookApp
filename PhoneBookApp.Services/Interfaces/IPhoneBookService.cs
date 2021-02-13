using PhoneBookApp.Data.Ef.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Services.Interfaces
{
    public interface IPhoneBookService
    {
        List<PhoneBook> GetAll();
        PhoneBook Get(int PhoneBookId);
        bool Delete(int PhoneBookId);
        int Add(PhoneBook phoneBook);
        PhoneBook Update(PhoneBook phoneBook);

    }
}
