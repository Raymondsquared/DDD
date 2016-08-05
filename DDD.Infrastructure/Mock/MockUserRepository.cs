using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Model;
using DDD.Infrastructure.Abstractions;

namespace DDD.Infrastructure.Mock
{
    public class MockUserRepository : IUserRepository
    {
        private static IList<User> _collection = new List<User>();

        public MockUserRepository()
        {
            
        }

        public async Task<IEnumerable<User>> SelectAllAsync()
        {
            return _collection;
        }

        public async Task<User> SelectAsync()
        {
            return _collection.LastOrDefault();
        }

        public async Task InsertAsync(User input)
        {
            _collection.Add(input);
        }

        public async Task InsertManyAsync(IEnumerable<User> inputCollection)
        {
            // random event just to throw exception for the first time
            if (!_collection.Any())
            {
                _collection.Add(new User()
                {
                    Id = 0,
                    FirstName = "Test1",
                    LastName = "Test2",
                    ExternalId = 0
                });
                throw new Exception("Fake Exception");
            }

            foreach (var input in inputCollection)
            {
                _collection.Add(input);
            }
        }
    }
}
