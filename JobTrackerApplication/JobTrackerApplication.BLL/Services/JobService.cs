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
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)

        {
            _jobRepository = jobRepository;
        }
        public Task<bool> CreateJob(JobViewModel jobModel)
        {
            _jobRepository.CreateJob(jobModel.TransformAPIToDAL());
            return Task.FromResult(true);
        }

        public async Task<List<JobViewModel>> GetAllJobs()
        {
            List<Job> jobList = await _jobRepository.GetAllJobs();
            List<JobViewModel> result = new List<JobViewModel>();
            foreach (var item in jobList)
            {
                result.Add(item.TransformDALToAPI());
            }
            return result;
        }
        public async Task<List<JobPositionViewModel>> GetJobPosition(string CompanyName)
        {
            List<Job> jobList= await _jobRepository.GetJobPosition(CompanyName);
            List<JobPositionViewModel> result = new List<JobPositionViewModel>();
            foreach (var item in jobList)
            {
                result.Add(item.TransformDALToAPIPosition());
            }
            return result;
        }
        public async Task<List<CompanyListViewModelcs>> GetAllCompanyList()
        {
           List<String> companyList = await _jobRepository.GetAllComapnyList();
            List<CompanyListViewModelcs> companyListView = new List<CompanyListViewModelcs>();
            foreach (var company in companyList)
            {
                CompanyListViewModelcs companyName = new CompanyListViewModelcs();
                companyName.Company = company;
                companyListView.Add(companyName);
            }
            return companyListView;


        }

    }
}
