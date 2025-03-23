using JobTrackerApplication.Entity.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.BLL.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserViewModel userModel);
    }
}
