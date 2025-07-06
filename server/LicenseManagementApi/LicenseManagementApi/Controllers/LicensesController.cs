namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ResponseModels;

    using Microsoft.AspNetCore.Mvc;

    using Swashbuckle.AspNetCore.Annotations;

    using System.ComponentModel.DataAnnotations;

    [ApiController]
    [Route("[controller]")]
    public class LicensesController : AbstractController
    {
        private readonly IUserUnitOfWork userUnitOfWork;
        private readonly IPlanValidator planValidator;

        public LicensesController(
            IUserUnitOfWork userUnitOfWork,
            IPlanValidator validator)
        {
            this.userUnitOfWork = userUnitOfWork;
            this.planValidator = validator;
        }

        [HttpPost("assign")]
        [SwaggerOperation(OperationId = "assignLicense")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get current plan response", typeof(ResponseMessage))]
        public IActionResult Assign([FromForm(Name = "user_id"), Required] int userId)
        {
            this.planValidator.ValidateOnLicenseAssign(userId);
            
            this.userUnitOfWork.UpdateLicenseStatus(userId, shouldHaveLicense: true);

            return this.BuildSuccessResponseMessage("License successfully assigned.");
        }

        [HttpPost("unassign")]
        [SwaggerOperation(OperationId = "unassignLicense")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get current plan response", typeof(ResponseMessage))]
        public IActionResult Unassign([FromForm(Name = "user_id"), Required] int userId)
        {
            this.planValidator.ValidateOnLicenseUnassign(userId);
            
            this.userUnitOfWork.UpdateLicenseStatus(userId, shouldHaveLicense: false);

            return this.BuildSuccessResponseMessage("License successfully removed.");
        }
    }
}
