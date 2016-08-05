using System.Threading.Tasks;

namespace DDD.Application.Abstractions
{
    public interface IConsoleApplicationService : IApplicationService
    {
        Task RunWithRetryAsync();
    }
}
