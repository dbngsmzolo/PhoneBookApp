using PhoneBookApp.Core.Entities;
using System.Linq;

namespace PhoneBookApp.Core.Data
{
    public interface IQueryableRepository<T> 
        where T: 
        class, 
        IEntity, 
        new()
    {
        IQueryable<T> Table { get; }
    }
}
