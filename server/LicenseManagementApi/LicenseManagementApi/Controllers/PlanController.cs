namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Database.EF;
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ResponseModels;
    using LicenseManagementApi.Models.ResponseModels.Plan;

    using Microsoft.AspNetCore.Mvc;

    using Swashbuckle.AspNetCore.Annotations;

    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class PlanController : AbstractController
    {
        private readonly IPlanResponseBuilder responseBuilder;
        private readonly IPlanUnitOfWork planUnitOfWork;
        private readonly IUserUnitOfWork userUnitOfWork;
        private readonly IPlanValidator validator;

        public PlanController(
            IPlanResponseBuilder responseBuilder,
            IPlanUnitOfWork planUnitOfWork,
            IUserUnitOfWork userUnitOfWork,
            IPlanValidator validator)
        {
            this.responseBuilder = responseBuilder;
            this.planUnitOfWork = planUnitOfWork;
            this.userUnitOfWork = userUnitOfWork;
            this.validator = validator;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "getCurrentPlan")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get current plan response", typeof(PlanResponse))]
        public IActionResult GetCurrentPlan()
        {
            Subscription plan = this.planUnitOfWork.GetCurrentSubscription();
            int licensesCount = this.userUnitOfWork.GetUsersWithLicenseCount();

            PlanResponse response = this.responseBuilder.BuildGetCurrentPlanInfoResponse(plan, licensesCount);

            return this.Ok(response);
        }

        [HttpPost("switch")]
        [SwaggerOperation(OperationId = "switchPlan")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get current plan response", typeof(ResponseMessage))]
        public async Task<IActionResult> SwitchPlanAsync([FromForm(Name = "plan_name")] string planName)
        {
            // TODO: create a ToLower binder
            string loweredPlanName = planName.ToLowerInvariant();

            this.validator.ValidatePlanBy(loweredPlanName);
            await this.planUnitOfWork.SwitchPlanTo(loweredPlanName);

            return this.BuildSuccessResponseMessage($"Successfully switched to {loweredPlanName} plan");
        }
    }
}
