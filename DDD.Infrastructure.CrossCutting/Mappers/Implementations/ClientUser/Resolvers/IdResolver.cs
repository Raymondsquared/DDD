using System;
using DDD.Domain.Model;
using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Mappers.Abstractions.DataSyncWorker.Mappers.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Mappers.Implementations.ClientUser.Resolvers
{
    public class IdResolver : IMapperResolver<ClientDto, User>
    {
        public void Resolve(ClientDto input, ref User output)
        {
            try
            {
                if (input != null)
                {
                    output.Id = input.Id;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}