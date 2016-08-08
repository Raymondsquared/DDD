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

        public async Task<User> SelectAsync(long id)
        {
            try
            {
                return _collection.First( u => u.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task InsertAsync(User input)
        {
            if(_collection.All(u => u.Id != input.Id))
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
                await InsertAsync(input);
            }
        }

        public async Task PutAsync(User input)
        {
            var user = _collection.First(u => u.Id == input.Id);

            if (user != null)
            {
                user.FirstName = input.FirstName;
                user.LastName = input.LastName;
                user.ExternalId = input.ExternalId;
            }
        }
    }
}
