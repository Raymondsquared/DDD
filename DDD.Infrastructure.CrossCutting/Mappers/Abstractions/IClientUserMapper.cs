using DDD.Domain.Model;
using DDD.Domain.Model.DTOs;

namespace DDD.Infrastructure.CrossCutting.Mappers.Abstractions
{
    public interface IClientUserMapper : IMapper<ClientDto, User>
    {
    }
}
