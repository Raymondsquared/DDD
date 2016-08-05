using System.Threading.Tasks;
using DDD.Infrastructure.CrossCutting.Delegates;

namespace DDD.Infrastructure.CrossCutting.Retries.Abstractions
{
    public interface IRetryStrategy
    {
        Task RetryAsync(RetryDelegate delegateAsync);
    }
}
