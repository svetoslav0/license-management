namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Database.EF;
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ResponseModels.Plan;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("[controller]")]
    public class PlanController : AbstractController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IPlanResponseBuilder responseBuilder;
        private readonly IUserUnitOfWork userUnitOfWork;

        public PlanController(
            DatabaseContext databaseContext,
            IPlanResponseBuilder responseBuilder,
            IUserUnitOfWork userUnitOfWork)
        {
            this.databaseContext = databaseContext;
            this.responseBuilder = responseBuilder;
            this.userUnitOfWork = userUnitOfWork;
        }

        [HttpGet]
        public ActionResult GetCurrentPlan()
        {
            Subscription plan = this.databaseContext
                .Subscription
                .Include(s => s.Plan)
                .FirstOrDefault();

            int licensesCount = this.userUnitOfWork.GetUsersWithLicenseCount();

            PlanResponse response = this.responseBuilder.BuildGetCurrentPlanInfoResponse(plan, licensesCount);

            return this.Ok(response);
        }
    }
}
