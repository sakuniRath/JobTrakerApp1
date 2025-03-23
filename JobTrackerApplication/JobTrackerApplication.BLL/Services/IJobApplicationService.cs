using JobTrackerApplication.DAL.Models;
using JobTrackerApplication.Entity.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.BLL.Services
{
    public interface IJobApplicationService
    {
        Task<JobApplicationPageResultViewModel<JobApplicationViewModel>> GetAllJobApplication(int pageNumber, int pageSize);
        Task<JobApplicationViewModel> GetJobApplication(int jobApplicationId);
        Task<bool> UpdateJobApplicationSatus(JobApplicationUpdateViewModel jobapplicationModel);
        Task<bool> ADDJobApplication(JobApplicationAddViewModel jobapplicationModel);
    }
}
