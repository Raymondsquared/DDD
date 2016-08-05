using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Domain.Model.DTOs;
using DDD.Domain.Service.Abstractions;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Domain.Service.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IRepository<ClientDto> _clientRepository;

        public ClientService(IRepository<ClientDto> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            return await _clientRepository.SelectAllAsync();
        }

        public async Task<ClientDto> GetAsync()
        {
            return await _clientRepository.SelectAsync();
        }

        public async Task PostAsync(ClientDto input)
        {
            await _clientRepository.InsertAsync(input);
        }

        public async Task PostManyAsync(IEnumerable<ClientDto> input)
        {
            await _clientRepository.InsertManyAsync(input);
        }
    }
}
