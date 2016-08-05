using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Domain.Service.Abstractions
{
    public interface IClientService : IDomainService<ClientDto>
    {
    }
}
