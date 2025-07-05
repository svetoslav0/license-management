namespace LicenseManagementApi.Interfaces
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Models.ResponseModels.Plan;

    public interface IPlanResponseBuilder
    {
        public PlanResponse BuildGetCurrentPlanInfoResponse(Subscription subscriptionInfo, int licensesCount);
    }
}
