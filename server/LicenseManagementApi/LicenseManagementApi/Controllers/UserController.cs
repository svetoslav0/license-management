namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Models.ParameterModels;
    using LicenseManagementApi.Services;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserUnitOfWork userUnitOfWork;

        public UserController(UserUnitOfWork userUnitOfWork)
        {
            this.userUnitOfWork = userUnitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserParameters parameters)
        {
            parameters.Validate();

            await this.userUnitOfWork.SaveUserAsync(parameters);

            return Ok("okay");
        }
    }
}
