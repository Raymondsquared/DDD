using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.Integrations
{
    public class InMemoryQueue : IIntegrationStrategy
    {
        private static Queue<object> _queue = new Queue<object>();

        public async Task AddAsync(object input)
        {
            _queue.Enqueue(input);
        }

        public async Task<object> TakeAsync()
        { 
            if(_queue.Count == 0)
                return null;

            return _queue.Dequeue();
        }
    }
}
