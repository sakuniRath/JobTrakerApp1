using JobTrackerApplication.BLL.Services;
using JobTrackerApplication.Entity.Jobs;
using JobTrackerApplication.RandomData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IUserService _userService;
        private readonly IJobApplicationService _jobApplicationService;
        public SeedController(IJobService jobService, IUserService userService, IJobApplicationService jobApplicationService)
        {
            _jobService = jobService;
            _userService = userService;
            _jobApplicationService = jobApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> DataSeed()
        {
            List<JobViewModel> jobViewModel = RandomDataforJobscs.SeedJobs();
            List<UserViewModel> users = RandomDataforJobscs.SeedUser();
            List<JobApplicationAddViewModel> jobApplications = RandomDataforJobscs.SeedJobApplication();

            foreach (var jobs in jobViewModel)
            {
                await _jobService.CreateJob(jobs);
            }
            foreach(var user in users)
            {

                await _userService.CreateUser(user);
            }
            foreach (var jobApplication in jobApplications)
            { 
                await _jobApplicationService.ADDJobApplication(jobApplication);
            }
            return Ok();
        }
    }
}
