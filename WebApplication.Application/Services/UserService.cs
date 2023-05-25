using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Models;
using WebApplication.Infra.Interfaces.Repositories;

namespace WebApplication.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            var id = _userRepository.CreateUser(user);

            var response = _userRepository.GetUserById(id);

            return response;
        } 
    }
}
