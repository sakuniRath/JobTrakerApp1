using JobTrackerApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.DAL.Repository
{
    public interface IJobApplicationRepository
    {
        Task<PageResult<JobApplication>> GetAllItem(int pageNumber, int pageSize);
        Task<bool> CreateJobApplication(JobApplication jobApplication);
        Task<JobApplication> GetJobApplication(int jobApplicationId);

        Task<bool> UpdateJobApplicationSatus(JobApplication jobapplicationModel);
    }
}
