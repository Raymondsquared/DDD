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
            var item = await _integrationStrategy.TakeAsync();            
            while (item != null)
            {
                await Process(item);
                item = await _integrationStrategy.TakeAsync();
            }
            
            // Test
            var userTest = _userService.GetAllAsync();
        }

        private async Task Process(object item)
        {
            if (item.GetType() == typeof(User))
            {
                var user = (User)item;
                user.Id = NewId++;

                //process
                Console.WriteLine($"integration processing {user.Id} - {user.NickName}");

                //Purposely delay 5 sec for every add
                Task.Delay(5000).Wait();
                await _userService.PostAsync(user);
            }
        }
    }
}
