namespace LicenseManagementApi.ResponseBuilders
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ResponseModels.Plan;

    public class PlanResponseBuilder : IPlanResponseBuilder
    {
        public PlanResponse BuildGetCurrentPlanInfoResponse(Subscription subscriptionInfo, int licensesCount)
        {
            PlanResponse planResponse = new PlanResponse
            {
                PlanName = subscriptionInfo.Plan.Name,
                SwitchedAt = subscriptionInfo.SwitchedAt,
                SeatLimit = subscriptionInfo.Plan.SeatLimit,
                CurrentLicensesCount = licensesCount
            };

            return planResponse;
        }
    }
}
