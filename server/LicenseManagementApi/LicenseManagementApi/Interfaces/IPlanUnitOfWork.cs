namespace LicenseManagementApi.Interfaces
{
    using LicenseManagementApi.Database.EF.Models;

    public interface IPlanUnitOfWork
    {
        public Subscription GetCurrentSubscription();

        public List<SubscriptionPlan> GetPlans();

        public Task SwitchPlanTo(string name);
    }
}
