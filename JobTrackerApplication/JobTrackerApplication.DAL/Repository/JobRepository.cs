using JobTrackerApplication.DAL.DataContext;
using JobTrackerApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.DAL.Repository
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(DatabaseContext dbContext) : base(dbContext) { }

        public async Task<Job> CreateJob(Job job)
        {
            Job jobCreated = await AddAsync(job);
            return jobCreated;
        }
        public async Task<List<Job>> GetAllJobs()

        {
            List<Job> jobList = await _dbContext.Jobs.ToListAsync();
            return jobList;
        }

        public async Task<List<Job>> GetJobPosition(string companyName)
        {
            List<Job> jobList = await _dbContext.Jobs.Where(a => a.CompanyName == companyName).ToListAsync();
            return jobList;
        }
        public async Task<int> GetJobId(string companyName, string possition)
        {

            var job = await _dbContext.Jobs.Where(a => a.CompanyName == companyName && a.Position == possition).FirstOrDefaultAsync();
            if (job != null)
            {
                return job.Id;

            }
            return 0;

        }
        public async Task<List<string>> GetAllComapnyList()
        {

            List<string> companyList = await _dbContext.Jobs.Select(a=>a.CompanyName).Distinct().ToListAsync();
            return companyList;
        }

        public async Task<Job> GetSpecificJob(int jobId)
        {
            Job job = await _dbContext.Jobs.Where(a => a.Id == jobId).FirstOrDefaultAsync();
            return job;
        }
    }
    }
