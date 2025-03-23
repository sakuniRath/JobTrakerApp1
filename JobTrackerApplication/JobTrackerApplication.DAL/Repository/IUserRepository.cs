using JobTrackerApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.DAL.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(ApplicationUsers user);
    }
}
