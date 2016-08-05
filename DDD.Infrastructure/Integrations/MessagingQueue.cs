using System.Messaging;
using System.Threading.Tasks;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.Integrations
{
    public class MessagingQueue : IIntegrationStrategy
    {
        private static MessageQueue _queue = new MessageQueue();

        public async Task Add(object input)
        {
            _queue.Send(input);
        }

        public async Task<object> Take()
        {
            return _queue.Receive();            
        }
    }
}
