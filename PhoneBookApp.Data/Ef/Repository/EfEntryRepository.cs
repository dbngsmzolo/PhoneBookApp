using PhoneBookApp.Core.Data.Ef;
using PhoneBookApp.Data.Ef.Concrete;
using PhoneBookApp.Data.Ef.Repository.Interfaces;

namespace PhoneBookApp.Data.Ef.Repository
{
    public class EfEntryRepository :
        EfRepository<Entry>,
        IEntryRepository
    {
    }
}
