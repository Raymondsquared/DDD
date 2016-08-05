using DDD.Domain.Model;
using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Mappers.Abstractions
{
    public interface IClientUserMapper : IMapper<ClientDto, User>
    {
    }
}
