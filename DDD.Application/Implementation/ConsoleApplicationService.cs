using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Application.Abstractions;
using DDD.Application.Services.Abstractions;
using DDD.Domain.Model;
using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Abstractions;
using DDD.Infrastructure.CrossCutting.Delegates;
using DDD.Infrastructure.CrossCutting.Extensions;
using DDD.Infrastructure.CrossCutting.Models;
using DDD.Infrastructure.CrossCutting.Models.Configurations;

namespace DDD.Application.Implementation
{
    public class ConsoleApplicationService : IConsoleApplicationService
    {
        private readonly BatchConfiguration _batchConfig;

        private readonly IRetryStrategy _retryStrategy;

        private readonly ILogService _logService;
        private readonly IDomainService<ClientDto> _clientService;
        private readonly IDomainService<User> _userService;

        private readonly IValidator<ClientDto> _clientValidator;
        private readonly IMapper<ClientDto, User> _userMapper;
        

        public ConsoleApplicationService (
            BatchConfiguration batchConfig,
            IRetryStrategy retryStrategy,
            IValidator<ClientDto> clientValidator,
            IMapper<ClientDto, User> userMapper,
            ILogService logService,
            IDomainService<ClientDto> clientService,
            IDomainService<User> userService
        )
        {
            _batchConfig = batchConfig;
            _retryStrategy = retryStrategy;
            _clientValidator = clientValidator;
            _userMapper = userMapper;

            _logService = logService;
            _clientService = clientService;
            _userService = userService;
        }

        public async Task RunWithRetryAsync()
        {
            Console.WriteLine("Application is running");

            RetryDelegate toDo = DoBatchAsync;

            await _retryStrategy.RetryAsync(toDo);

            // Test
            var userTest = _userService.GetAllAsync();
            var logTest = _logService.GetAllAsync();
        }

        public async Task<bool> DoBatchAsync()
        {
            var log = new Log
            {
                StartedUtc = DateTime.UtcNow
            };

            try
            {
                // Use ConcurrentQueue to enable safe enqueueing from multiple threads.
                var exceptions = new ConcurrentQueue<Exception>();

                var clients = (await _clientService.GetAllAsync()).ToList();

                await Task.Run(() =>
                    Parallel.ForEach(clients.Split(_batchConfig.Size), 
                        async groupedClients => {
                            try
                            {
                                Console.WriteLine("Do batch " + string.Join(", ", groupedClients.Select(i => i.FirstName)));

                                await Process(groupedClients);

                                log.Success = true;
                            }
                            catch (Exception e)
                            {
                                // Store the exception and continue with the loop.  
                                exceptions.Enqueue(e);
                            }
                    })
                );

                // Throw the exceptions here after the loop completes.
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
            catch (AggregateException ae)
            {
                log.Success = false;
                log.Message = string.Join(", ", ae.InnerExceptions.Select(ie => ie.Message));
                Console.WriteLine("Many Errors While Doing Batch Processing" + log.Message);
            }
            catch (Exception e)
            {
                log.Success = false;
                log.Message = e.Message;
                Console.WriteLine("Error With Batch" + log.Message);
            }

            await _logService.PostAsync(log);

            return log.Success;
        }

        public async Task Process(IEnumerable<ClientDto> clients)
        {
            var users = (
                from client
                    in clients
                where _clientValidator.IsValid(client)
                select _userMapper.Map(client)
            ).ToList();
                
            if (users.Any())
            {
                await _userService.PostManyAsync(users);
            }            
        }
    }
}
