using JobTrackerApplication.BLL.Services;
using JobTrackerApplication.Entity.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(JobViewModel jobModel)
        {
            await _jobService.CreateJob(jobModel);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            var jobApplicationList = await _jobService.GetAllCompanyList();

            return Ok(jobApplicationList);
        }
        [HttpGet("GetJobPosition/{CompanyName}")]
        public async Task<IActionResult> GetJobPosition(string CompanyName)
        {
            var jobApplication = await _jobService.GetJobPosition(CompanyName);
            return Ok(jobApplication);
        }
    }
}
