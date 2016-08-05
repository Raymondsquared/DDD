using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Domain.Model;
using DDD.Domain.Service.Abstractions;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Domain.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.SelectAllAsync();
        }

        public async Task<User> GetAsync()
        {
            return await _userRepository.SelectAsync();
        }

        public async Task PostAsync(User input)
        {
            await _userRepository.InsertAsync(input);
        }

        public async Task PostManyAsync(IEnumerable<User> input)
        {
            await _userRepository.InsertManyAsync(input);
        }
    }
}
