using JobTrackerApplication.BLL.Helpers;
using JobTrackerApplication.DAL.Models;
using JobTrackerApplication.DAL.Repository;
using JobTrackerApplication.Entity.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApplication.BLL.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IJobRepository _jobRepository;

        public JobApplicationService(IJobApplicationRepository jobApplicationRepository, IJobRepository jobRepository)

        {
            _jobApplicationRepository = jobApplicationRepository;
            _jobRepository = jobRepository;
        }
        public async Task<JobApplicationPageResultViewModel<JobApplicationViewModel>> GetAllJobApplication(int pageNumber, int pageSize)
        {
            PageResult<JobApplication> JobapplicationList = await _jobApplicationRepository.GetAllItem(pageNumber, pageSize);
            JobApplicationPageResultViewModel<JobApplicationViewModel> JobApplicationViewModelList = new JobApplicationPageResultViewModel<JobApplicationViewModel>();
            JobApplicationViewModelList.TotalItemsCount = JobapplicationList.TotalItemsCount;
            JobApplicationViewModelList.PageNumber = pageNumber;
            JobApplicationViewModelList.PageSize = pageSize;
            List<JobApplicationViewModel> jobApplicationViewModelList = new List<JobApplicationViewModel>();
            
            foreach (var itemdetails in JobapplicationList.Data)
            {
                JobApplicationViewModel jobApplicationView =itemdetails.TransformDALToAPI();
                Job job = await _jobRepository.GetSpecificJob(itemdetails.Id);
                jobApplicationView.CompanyName = job.CompanyName;
                jobApplicationView.Position = job.Position;
                jobApplicationViewModelList.Add(jobApplicationView);
                
            }
            JobApplicationViewModelList.Data =jobApplicationViewModelList;
            return JobApplicationViewModelList;
        }
        
        public async Task<bool> ADDJobApplication(JobApplicationAddViewModel jobapplicationModel)
        {
            int jobId = await _jobRepository.GetJobId(jobapplicationModel.CompanyName, jobapplicationModel.Position);
            jobapplicationModel.JobId = jobId;
            await _jobApplicationRepository.CreateJobApplication(jobapplicationModel.TransformAPIToDAL());
            return true;
        }

        public async Task<JobApplicationViewModel> GetJobApplication(int jobApplicationId)
        {
            List<Job> jobs = await _jobRepository.GetAllJobs();
            JobApplication jobApplication =await _jobApplicationRepository.GetJobApplication(jobApplicationId);
           JobApplicationViewModel jobApplicationView =jobApplication.TransformDALToAPI();
            Job job = await _jobRepository.GetSpecificJob(jobApplicationView.JobId);
            jobApplicationView.CompanyName = job.CompanyName;
            jobApplicationView.Position = job.Position;
           
            return jobApplicationView;
        }
        public async Task<bool> UpdateJobApplicationSatus(JobApplicationUpdateViewModel jobapplicationModel)
        {

            await _jobApplicationRepository.UpdateJobApplicationSatus(jobapplicationModel.TransformAPIToDAL());
            return true;
        }
    }
}
