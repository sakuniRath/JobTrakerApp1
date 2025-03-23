using JobTrackerApplication.BLL.Helpers;
using JobTrackerApplication.DAL.Repository;
using JobTrackerApplication.Entity.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)

        {
            _userRepository = userRepository;
        }
        public Task<bool> CreateUser(UserViewModel userModel)
        {
            _userRepository.CreateUser(userModel.TransformAPIToDAL());
            return Task.FromResult(true);
        }
    }
}
