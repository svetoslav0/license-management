namespace LicenseManagementApi.ResponseBuilders
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ResponseModels.Plan;

    public class PlanResponseBuilder : IPlanResponseBuilder
    {
        public PlansInfoResponse BuildGetCurrentPlanInfoResponse(
            Subscription subscriptionInfo,
            List<SubscriptionPlan> availablePlans,
            int licensesCount)
        {
            PlansInfoResponse planResponse = new PlansInfoResponse
            {
                CurrentPlan = new CurrentPlanItem
                {
                    PlanName = subscriptionInfo.Plan.Name,
                    SwitchedAt = subscriptionInfo.SwitchedAt,
                    SeatLimit = subscriptionInfo.Plan.SeatLimit,
                    CurrentLicensesCount = licensesCount
                },
                Plans = availablePlans.Select(p =>
                {
                    return new PlanItem
                    {
                        Name = p.Name,
                        SeatLimit = p.SeatLimit
                    };
                })
                .ToList()
            };

            return planResponse;
        }
    }
}
