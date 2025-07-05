namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Interfaces;

    using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Assign([FromForm(Name = "user_id")] int userId)
        {
            this.planValidator.ValidateOnLicenseAssign(userId);
            
            this.userUnitOfWork.UpdateLicenseStatus(userId, shouldHaveLicense: true);

            return this.BuildSuccessResponseMessage("License successfully assigned.");
        }

        [HttpPost("unassign")]
        public IActionResult Unassign([FromForm(Name = "user_id")] int userId)
        {
            this.planValidator.ValidateOnLicenseUnassign(userId);
            
            this.userUnitOfWork.UpdateLicenseStatus(userId, shouldHaveLicense: false);

            return this.BuildSuccessResponseMessage("License successfully removed.");
        }
    }
}
