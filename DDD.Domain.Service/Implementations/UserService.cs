using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Domain.Model;
using DDD.Domain.Service.Abstractions;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Domain.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IIntegrationStrategy _integrationStrategy;
        private readonly IRepository<User> _userRepository;

        public UserService(
            IIntegrationStrategy integrationStrategy,
            IRepository<User> userRepository)
        {
            _integrationStrategy = integrationStrategy;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.SelectAllAsync();
        }

        public async Task<User> GetAsync(long id)
        {
            return await _userRepository.SelectAsync(id);
        }

        public async Task PostAsync(User input)
        {
            await _userRepository.InsertAsync(input);
        }

        public async Task PostManyAsync(IEnumerable<User> input)
        {
            await _userRepository.InsertManyAsync(input);
        }
        public async Task PutAsync(User input)
        {
            await _userRepository.InsertAsync(input);
        }

        public async Task CreateUserCqrs(User input)
        {
            await _integrationStrategy.Add(input);
            //await _userRepository.InsertAsync(input);
        }

        public async Task<bool> CheckIfUserExistCqrs(long id)
        {
            return await _userRepository.SelectAsync(id) != null;
        }
    }
}
