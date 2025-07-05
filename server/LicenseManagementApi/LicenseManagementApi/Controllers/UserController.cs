namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ParameterModels;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class UserController : AbstractController
    {
        private readonly IUserUnitOfWork userUnitOfWork;

        public UserController(IUserUnitOfWork userUnitOfWork)
        {
            this.userUnitOfWork = userUnitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserParameters parameters)
        {
            parameters.Validate();

            await this.userUnitOfWork.SaveUserAsync(parameters);

            return this.BuildSuccessResponseMessage("User was successfully created!");
        }
    }
}
