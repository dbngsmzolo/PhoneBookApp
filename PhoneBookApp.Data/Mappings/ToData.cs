using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Data.Mappings
{
    public static class ToData
    {
        public static Entry ToEntryData(EntryModel model)
        {
            return new Entry()
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                PhoneBookId = model.PhoneBookId
            };
        }

        public static PhoneBook ToPhoneBookData(PhoneBookModel model)
        {
            return new PhoneBook()
            {
                Name = model.Name
            };
        }
    }
}
