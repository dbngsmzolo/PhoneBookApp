using PhoneBookApp.Data.Ef.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Services.Interfaces
{
    public interface IEntryService
    {
        List<Entry> GetAll(int id);
        Entry Get(int EntryId);
        bool Delete(int EntryId);
        int Add(Entry entry);
        List<Entry> GetAllForPhoneBook(int phoneBookId);
    }
}
