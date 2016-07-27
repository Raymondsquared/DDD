using DDD.Domain.Model;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Domain.Service.Abstractions
{
    public interface IUserService : IDomainService<User>
    {
    }
}
