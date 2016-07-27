using System.Threading.Tasks;

namespace DDD.Application.Services.Abstractions
{
    public interface IConsoleApplicationService : IApplicationService
    {
        Task RunWithRetryAsync();
    }
}
