using System.Threading.Tasks;

namespace DDD.Infrastructure.CrossCutting.Abstractions
{
    public interface IIntegrationStrategy
    {
        Task Add(object input);
        Task<object> Take();
    }
}
