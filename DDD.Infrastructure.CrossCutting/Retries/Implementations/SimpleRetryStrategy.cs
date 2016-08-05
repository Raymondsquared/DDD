using System;
using System.Threading.Tasks;
using DDD.Infrastructure.CrossCutting.Delegates;
using DDD.Infrastructure.CrossCutting.Models.Configurations;
using DDD.Infrastructure.CrossCutting.Retries.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Retries.Implementations
{
    public class SimpleRetryStrategy : IRetryStrategy
    {
        private readonly RetryConfiguration _retryConfig;        

        public SimpleRetryStrategy(RetryConfiguration retryConfig)
        {
            _retryConfig = retryConfig;
        }

        public async Task RetryAsync(RetryDelegate retryDelegateAsync)
        {
            // Simple Retry
            for (var retry = 0; retry < _retryConfig.Maximum; retry++)
            {
                var result = await retryDelegateAsync();
                Console.WriteLine($"Try #{retry+1} : {result}");
                if (result) break;
                await Task.Delay(_retryConfig.DelayMillseconds);
            }
        }        
    }
}
