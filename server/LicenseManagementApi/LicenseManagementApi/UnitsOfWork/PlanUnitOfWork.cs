namespace LicenseManagementApi.UnitsOfWork
{
    using LicenseManagementApi.Database.EF;
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;

    public class PlanUnitOfWork : IPlanUnitOfWork
    {
        private readonly DatabaseContext databaseContext;
        private List<SubscriptionPlan> plansList = new List<SubscriptionPlan>();

        public PlanUnitOfWork(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Subscription GetCurrentSubscription()
        {
            Subscription plan = this.databaseContext
                .Subscription
                .Include(s => s.Plan)
                .FirstOrDefault();

            return plan;
        }

        public List<SubscriptionPlan> GetPlans()
        {
            if (!this.plansList.Any())
            {
                this.plansList = this.databaseContext
                    .SubscriptionPlans
                    .ToList();
            }

            return this.plansList;
        }

        public async Task SwitchPlanTo(string name)
        {
            SubscriptionPlan newPlan = this.plansList.First(x => x.Name == name);

            Subscription currentSubscription = this.databaseContext
                .Subscription
                .First();

            currentSubscription.PlanId = newPlan.Id;

            await this.databaseContext.SaveChangesAsync();
        }
    }
}
