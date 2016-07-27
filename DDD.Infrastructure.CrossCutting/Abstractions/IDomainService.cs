using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Infrastructure.CrossCutting.Abstractions
{
    public interface IDomainService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
