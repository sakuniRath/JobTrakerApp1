using JobTrackerApplication.DAL.DataContext;
using JobTrackerApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.DAL.Repository
{
    public class UserRepository : RepositoryBase<ApplicationUsers>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext) : base(dbContext) { }

        public async Task<bool> CreateUser(ApplicationUsers user)
        {
            await AddAsync(user);
            return true;
        }
    }
}
