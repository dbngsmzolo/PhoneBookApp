using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Models;
using System.Collections.Generic;

namespace PhoneBookApp.Data.Mappings
{
    public static class ToModel
    {
        public static EntryModel ToEntryModel(Entry entry)
        {
            return new EntryModel()
            {
                Id = entry.Id,
                Name = entry.Name,
                PhoneNumber = entry.PhoneNumber,
                PhoneBookId = entry.PhoneBookId
            };
        }

        public static PhoneBookModel ToPhoneBookModel(PhoneBook phoneBook)
        {
            return new PhoneBookModel()
            {
                Id = phoneBook.Id,
                Name = phoneBook.Name
            };
        }

        public static List<PhoneBookModel> ToPhoneBookModelList(List<PhoneBook> list)
        {
            var modelList = new List<PhoneBookModel>();
            foreach(var phoneBook in list)
            {
                modelList.Add(ToPhoneBookModel(phoneBook));
            }
            return modelList;
            
        }

        public static List<EntryModel> ToEntryModelList(List<Entry> list)
        {
            var modelList = new List<EntryModel>();
            foreach (var entry in list)
            {
                modelList.Add(ToEntryModel(entry));
            }
            return modelList;

        }
    }
}
