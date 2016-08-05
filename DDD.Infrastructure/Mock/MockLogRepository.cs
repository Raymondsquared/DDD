using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Infrastructure.Abstractions;
using DDD.Infrastructure.CrossCutting.Models;

namespace DDD.Infrastructure.Mock
{
    public class MockLogRepository : ILogRepository
    {
        private static IList<Log> _collection = new List<Log>();

        public MockLogRepository()
        {
            
        }

        public async Task<IEnumerable<Log>> SelectAllAsync()
        {
            return _collection;
        }

        public async Task<Log> SelectAsync()
        {
            return _collection.LastOrDefault();
        }

        public async Task InsertAsync(Log input)
        {
            _collection.Add(input);
        }

        public async Task InsertManyAsync(IEnumerable<Log> inputCollection)
        {
            throw new System.NotImplementedException();
        }
    }
}
