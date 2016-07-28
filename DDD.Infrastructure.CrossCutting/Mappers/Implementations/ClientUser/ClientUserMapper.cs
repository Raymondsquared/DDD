using System.Collections.Generic;
using DDD.Domain.Model;
using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Mappers.Abstractions;
using DDD.Infrastructure.CrossCutting.Mappers.Abstractions.DataSyncWorker.Mappers.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Mappers.Implementations.ClientUser
{
    public class ClientUserMapper : IClientUserMapper
    {
        private readonly IEnumerable<IMapperResolver<ClientDto, User>> _resolvers;

        public ClientUserMapper(IEnumerable<IMapperResolver<ClientDto, User>> resolvers)
        {
            _resolvers = resolvers;
        }
        
        public User Map(ClientDto input)
        {

            var result = new User();

            foreach (var resolver in _resolvers)
            {
                resolver.Resolve(input, ref result);
            }

            return result;
        }
    }
}