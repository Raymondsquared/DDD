using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.Abstractions;

namespace DDD.Infrastructure.Mock
{
    public class MockClientRepository : IClientRepository
    {
        private static IList<ClientDto> _collection = new List<ClientDto>()
        {
            new ClientDto() {Id = 1, FirstName = "Frank", Surname = "Lampard"},
            new ClientDto() {Id = 2, FirstName = "Raymond"},
            new ClientDto() {Id = 3, FirstName = "Steven", Surname = "Gerrard"}
        };

        public MockClientRepository()
        {
            
        }

        public async Task<IEnumerable<ClientDto>> SelectAllAsync()
        {
            return _collection;
        }

        public async Task<ClientDto> SelectAsync(long id)
        {
            return _collection.LastOrDefault();
        }

        public async Task InsertAsync(ClientDto input)
        {
            _collection.Add(input);
        }

        public async Task InsertManyAsync(IEnumerable<ClientDto> inputCollection)
        {
            foreach (var input in inputCollection)
            {
                _collection.Add(input);
            }
        }

        public async Task PutAsync(ClientDto input)
        {
            var client = _collection.First(c => c.Id == input.Id);

            if (client != null)
            {
                client.FirstName = input.FirstName;
                client.Surname = input.Surname;
            }
        }
    }
}

