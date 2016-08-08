using System;
using System.Threading.Tasks;
using DDD.Application.Abstractions;
using DDD.Domain.Service.Abstractions;

namespace DDD.Application.Implementation
{
    public class ConsoleQueryApplicationService : IConsoleApplicationService
    {
        private static long QueryId;
        private readonly IUserService _userService;

        public ConsoleQueryApplicationService(
            IUserService userService
        )
        {
            QueryId = 100000;
            _userService = userService;
        }

        public async Task RunWithRetryAsync()
        {
            await Task.Run(async () =>
            {
                while (QueryId < 100003)
                {
                    await Process(QueryId);
                    Task.Delay(1000).Wait();
                }
            });
        }

        private async Task Process(long id)
        {
            var user = await _userService.QueryUser(id);

            if (user != null)
            {
                Console.WriteLine($"{QueryId} is found");
                QueryId++;
            }
            else
            {
                Console.WriteLine($"{QueryId} is not found");
            }
        }
    }
}
