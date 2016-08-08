using System.Threading.Tasks;

namespace DDD.Infrastructure.CrossCutting.Abstractions
{
    public interface IIntegrationStrategy
    {
        Task AddAsync(object input);
        Task<object> TakeAsync();
    }
}
