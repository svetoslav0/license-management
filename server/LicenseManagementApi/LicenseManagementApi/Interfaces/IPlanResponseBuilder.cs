namespace LicenseManagementApi.Interfaces
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Models.ResponseModels.Plan;

    public interface IPlanResponseBuilder
    {
        public PlansInfoResponse BuildGetCurrentPlanInfoResponse(
            Subscription subscriptionInfo,
            List<SubscriptionPlan> availablePlans,
            int licensesCount);
    }
}
