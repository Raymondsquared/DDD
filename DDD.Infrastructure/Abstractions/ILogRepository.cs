using DDD.Infrastructure.CrossCutting.Abstractions;
using DDD.Infrastructure.CrossCutting.Models;

namespace DDD.Infrastructure.Abstractions
{
    public interface ILogRepository : IRepository<Log>
    {
    }
}
