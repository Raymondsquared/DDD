using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.Abstractions
{
    public interface IClientRepository : IRepository<ClientDto>
    {
    }
}
