using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Application.Services.Abstractions;
using DDD.Infrastructure.CrossCutting.Abstractions;
using DDD.Infrastructure.CrossCutting.Models;

namespace DDD.Application.Services.Implementations
{
    public class LogService : ILogService
    {
        private readonly IRepository<Log> _userRepository;

        public LogService(IRepository<Log> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Log>> GetAllAsync()
        {
            return await _userRepository.SelectAllAsync();
        }

        public async Task<Log> GetAsync(long id)
        {
            return await _userRepository.SelectAsync(id);
        }

        public async Task PostAsync(Log input)
        {
            await _userRepository.InsertAsync(input);
        }
    }
}
