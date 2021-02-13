using PhoneBookApp.Core.Data;
using PhoneBookApp.Data.Ef.Concrete;

namespace PhoneBookApp.Data.Ef.Repository.Interfaces
{
    public interface IPhoneBookRepository: IEntityRepository<PhoneBook>
    {
    }
}
