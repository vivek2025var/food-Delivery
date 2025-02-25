using FoodDeliveryAPI.Models;
using FoodDeliveryAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDeliveryAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetUsers() => _userRepository.GetUsers();
        public Task<User> GetUserById(int id) => _userRepository.GetUserById(id);
        public Task<int> RegisterUser(User user) => _userRepository.RegisterUser(user);
        public Task<int> UpdateUser(User user) => _userRepository.UpdateUser(user);
        public Task<int> DeleteUser(int id) => _userRepository.DeleteUser(id);
    }
}
