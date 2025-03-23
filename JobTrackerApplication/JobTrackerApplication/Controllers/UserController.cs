using JobTrackerApplication.BLL.Services;
using JobTrackerApplication.Entity.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CrateUser(UserViewModel userViewModel)
        {
            await _userService.CreateUser(userViewModel);
            return Ok();
        }
    }
}
