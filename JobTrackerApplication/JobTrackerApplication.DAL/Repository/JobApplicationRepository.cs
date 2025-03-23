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
    public class JobApplicationRepository : RepositoryBase<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(DatabaseContext dbContext) : base(dbContext) { }
        public async Task<PageResult<JobApplication>> GetAllItem(int pageNumber, int pageSize)
            
        {
            //var jobApplications = _dbContext.JobApplications.ToList();
            var totalItemsCount = await _dbContext.JobApplications.CountAsync();

            var jobs =await  _dbContext.JobApplications
                .OrderByDescending(j => j.DateApplied) // Sort by latest applied date
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageResult<JobApplication>
            {
                Data = jobs,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItemsCount = totalItemsCount
            };

            
        }
        public async Task<bool> CreateJobApplication(JobApplication jobApplication)
        {
            await AddAsync(jobApplication);
            return true;
        }

        public async Task<JobApplication> GetJobApplication(int jobApplicationId)
        { 
           return await _dbContext.JobApplications.Where(a=>a.Id == jobApplicationId).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateJobApplicationSatus(JobApplication jobapplicationModel)
        {
            JobApplication jobApplication = _dbContext.JobApplications.Where(a => a.Id == jobapplicationModel.Id).FirstOrDefault();
            if (jobApplication != null)
            {
                jobApplication.Status = jobapplicationModel.Status;
                await UpdateAsync(jobApplication);
                return true;
            }
            return false;
        }
    }
}
