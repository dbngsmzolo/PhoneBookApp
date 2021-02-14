using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Services.Interfaces
{
    public interface IEntryService
    {
        List<EntryModel> GetAllForPhoneBook(int? phoneBookId);
        EntryModel Get(int? entryId);
        bool Delete(int? entryId);
        int Add(EntryModel entry);
    }
}
