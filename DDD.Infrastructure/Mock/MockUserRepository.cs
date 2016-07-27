using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Domain.Model;
using DDD.Infrastructure.Abstractions;

namespace DDD.Infrastructure.Mock
{
    public class MockUserRepository : IUserRepository
    {
        private static IList<User> _collection = new List<User>()
        {
            new User() {FirstName = "Frank", LastName = "Lampard"},
            new User() {FirstName = "Raymond"}
        };

        public MockUserRepository()
        {
            
        }

        public async Task<IEnumerable<User>> SelectAllAsync()
        {
            return _collection;
        }
    }
}
