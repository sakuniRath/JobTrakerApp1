using JobTrackerApplication.DAL.Models;
using JobTrackerApplication.Entity.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.BLL.Helpers
{
    public static class UserTranformation
    {
        public static ApplicationUsers TransformAPIToDAL(this UserViewModel itemModel)
        {
            if (itemModel == null)
            {
                return null;
            }
            var item = new ApplicationUsers()
            {
                UserName = itemModel.UserName,
                UserRole = itemModel.UserRole

            };

            return item;
        }
    }
}
