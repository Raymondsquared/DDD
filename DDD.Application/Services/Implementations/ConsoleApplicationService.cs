using System;
using System.Linq;
using System.Threading.Tasks;
using DDD.Application.Services.Abstractions;
using DDD.Domain.Model;
using DDD.Infrastructure.CrossCutting.Abstractions;
using DDD.Infrastructure.CrossCutting.Delegates;
using DDD.Infrastructure.CrossCutting.Extensions;
using DDD.Infrastructure.CrossCutting.Models;
using DDD.Infrastructure.CrossCutting.Retries.Abstractions;

namespace DDD.Application.Services.Implementations
{
    public class ConsoleApplicationService : IConsoleApplicationService
    {
        private readonly BatchConfig _batchConfig;

        private readonly IRetryStrategy _retryStrategy;

        private readonly IDomainService<User> _userService;
        
        public ConsoleApplicationService( 
            BatchConfig batchConfig,
            IRetryStrategy retryStrategy,
            IDomainService<User> userService
        )
        {
            _batchConfig = batchConfig;
            _retryStrategy = retryStrategy;
            _userService = userService;
        }        

        public async Task RunWithRetryAsync()
        {
            Console.WriteLine("Application is running");

            RetryDelegate toDo = DoBatchAsync;

            await _retryStrategy.RetryAsync(toDo);
        }

        public async Task<bool> DoBatchAsync()
        {
            var log = new Log
            {
                StartedUtc = DateTime.UtcNow
            };
            
            var collection = (await _userService.GetAllAsync()).ToList();

            try
            {
                await Task.Run(() =>
                    Parallel.ForEach(collection.Split(_batchConfig.Size),
                        cs => { 
                            Console.WriteLine("Do batch " + string.Join(", ", cs.Select(i => i.FirstName)));
                                log.Success = true;
                                //_billingService.Synchronise(ab, fromDateTime);
                    })
                );
            }
            catch (Exception ex)
            {
                log.Success = false;

                log.Message = ex.Message;

                var aex = ex as AggregateException;
                if (aex != null)
                {
                    log.Message = string.Join(", ", aex.InnerExceptions.Select(a => a.InnerException.Message));
                }

                Console.WriteLine("Error Do Batch" + log.Message);
            }

            //logs
            //await _applicationService.PostRequestLogAsync(result);

            return log.Success;
        }
    }
}
