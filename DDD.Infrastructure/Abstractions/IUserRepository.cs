using DDD.Domain.Model;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
