using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Infrastructure.CrossCutting.Models;

namespace DDD.Application.Services.Abstractions
{
    public interface ILogService
    {
        Task<IEnumerable<Log>> GetAllAsync();
        Task<Log> GetAsync(long id);
        Task PostAsync(Log input);
    }
}
