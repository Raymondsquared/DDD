using System;
using System.Threading.Tasks;
using DDD.Application.Abstractions;
using DDD.Domain.Model;
using DDD.Domain.Service.Abstractions;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Application.Implementation
{
    public class ConsoleIntegrationApplicationService : IConsoleApplicationService
    {
        private static long NewId;
        private readonly IIntegrationStrategy _integrationStrategy;

        private readonly IUserService _userService;

        public ConsoleIntegrationApplicationService (
            IIntegrationStrategy integrationStrategy,
            IUserService userService
        )
        {
            NewId = 100000;
            _integrationStrategy = integrationStrategy;
            _userService = userService;
        }

        public async Task RunWithRetryAsync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    var item = await _integrationStrategy.TakeAsync();
                    if (item != null)
                    {
                        await Process(item);
                    }
                }
            });                            
        }

        private async Task Process(object item)
        {
            if (item.GetType() == typeof(User))
            {
                var user = (User)item;
                user.Id = NewId++;

                //process
                Console.WriteLine($"integration processing {user.Id} - {user.NickName}");                
                await _userService.PostAsync(user);
            }
        }
    }
}
