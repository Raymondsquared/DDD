using System;
using System.Threading.Tasks;
using DDD.Infrastructure.CrossCutting.Delegates;
using DDD.Infrastructure.CrossCutting.Models;
using DDD.Infrastructure.CrossCutting.Retries.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Retries.Implementations
{
    public class SimpleRetryStrategy : IRetryStrategy
    {
        private readonly RetryConfig _retryConfig;        

        public SimpleRetryStrategy(RetryConfig retryConfig)
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
