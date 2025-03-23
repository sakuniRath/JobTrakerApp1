using JobTrackerApplication.BLL.Services;
using JobTrackerApplication.DAL.DataContext;
using JobTrackerApplication.DAL.Models;
using JobTrackerApplication.Entity.Jobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JobTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;
     
        public JobApplicationController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
           
        }
        [HttpGet(Name = "GetAllJobApplication")]
        public async Task<IActionResult> GetAllJobApplication(int pageNumber, int pageSize)
        {
            var jobApplicationList = await _jobApplicationService.GetAllJobApplication(pageNumber, pageSize);

            return Ok(jobApplicationList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateJobApplication(JobApplicationAddViewModel jobapplicationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _jobApplicationService.ADDJobApplication(jobapplicationModel);
            return Ok();
        }
        [HttpGet("GetJobApplication/{jobApplicationId}")]
        public async Task<IActionResult> GetJobApplication(int jobApplicationId)
        {
            if (jobApplicationId == null || jobApplicationId == 0)
            {
                return BadRequest();
            }
            var jobApplication = await _jobApplicationService.GetJobApplication(jobApplicationId);
            return Ok(jobApplication);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateJobApplication(JobApplicationUpdateViewModel jobapplicationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _jobApplicationService.UpdateJobApplicationSatus(jobapplicationModel);
            return Ok();
        }
    }
}
