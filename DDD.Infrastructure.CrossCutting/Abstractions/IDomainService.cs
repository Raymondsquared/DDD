using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Infrastructure.CrossCutting.Abstractions
{
    public interface IDomainService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        Task PostAsync(T input);
        Task PostManyAsync(IEnumerable<T> input);
        Task PutAsync(T input);
    }
}
