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
    }
}
