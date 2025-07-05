namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ParameterModels;
    using LicenseManagementApi.Models.ResponseModels.User;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class UserController : AbstractController
    {
        private readonly IUserUnitOfWork unitOfWork;
        private readonly IUserResponseBuilder responseBuilder;
        private readonly IUserValidator validator;

        public UserController(
            IUserUnitOfWork unitOfWork,
            IUserResponseBuilder responseBuilder,
            IUserValidator validator)
        {
            this.unitOfWork = unitOfWork;
            this.responseBuilder = responseBuilder;
            this.validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserParameters parameters)
        {
            this.validator.ValidateCreateUserParameters(parameters);

            await this.unitOfWork.SaveUserAsync(parameters);

            return this.BuildSuccessResponseMessage("User was successfully created!");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            List<User> usersList = this.unitOfWork.ListUsers();

            UserResponse response = this.responseBuilder.BuildGetUsersListResponse(usersList);

            return this.Ok(response);
        }
    }
}
