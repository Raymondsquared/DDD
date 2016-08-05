using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Infrastructure.CrossCutting.Abstractions
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> SelectAllAsync();
        Task<T> SelectAsync(long id);
        Task InsertAsync(T input);
        Task InsertManyAsync(IEnumerable<T> inputCollection);
        Task PutAsync(T input);
    }
}
