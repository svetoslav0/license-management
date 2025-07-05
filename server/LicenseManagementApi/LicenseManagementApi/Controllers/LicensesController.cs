namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Interfaces;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class LicensesController : AbstractController
    {
        private readonly IUserUnitOfWork userUnitOfWork;
        public LicensesController(IUserUnitOfWork userUnitOfWork)
        {
            this.userUnitOfWork = userUnitOfWork;
        }

        [HttpPost("assign")]
        public IActionResult Assign([FromForm] int userId)
        {
            // todo: validations

            this.userUnitOfWork.UpdateLicenseStatus(userId, shouldHaveLicense: true);

            return this.BuildSuccessResponseMessage("License successfully assigned.");
        }

        [HttpPost("unassign")]
        public IActionResult Unassign([FromForm] int userId)
        {
            // todo: validations

            this.userUnitOfWork.UpdateLicenseStatus(userId, shouldHaveLicense: false);

            return this.BuildSuccessResponseMessage("License successfully removed.");
        }
    }
}
