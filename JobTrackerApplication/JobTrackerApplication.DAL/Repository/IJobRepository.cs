using JobTrackerApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.DAL.Repository
{
    public interface IJobRepository
    {
        Task<Job> CreateJob(Job job);
        Task<List<Job>> GetAllJobs();
        Task<List<Job>> GetJobPosition(string CompanyName);
        Task<int> GetJobId(string companyName, string possition);
        Task<List<string>> GetAllComapnyList();
        Task<Job> GetSpecificJob(int jobId);

    }
}
