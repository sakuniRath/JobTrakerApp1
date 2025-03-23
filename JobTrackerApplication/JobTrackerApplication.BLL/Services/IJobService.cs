using JobTrackerApplication.DAL.Models;
using JobTrackerApplication.Entity.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.BLL.Services
{
    public interface IJobService
    {
        Task<bool> CreateJob(JobViewModel jobModel);
        //Task<List<JobViewModel>> GetAllJobApplication();
        Task<List<JobViewModel>> GetAllJobs();
        Task<List<JobPositionViewModel>> GetJobPosition(string CompanyName);
        Task<List<CompanyListViewModelcs>> GetAllCompanyList();
    }
}
