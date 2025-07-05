namespace LicenseManagementApi.Validators
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;

    public class PlanValidator : IPlanValidator
    {
        private readonly IPlanUnitOfWork planUnitOfWork;
        private readonly IUserUnitOfWork userUnitOfWork;

        public PlanValidator(
            IPlanUnitOfWork planUnitOfWork,
            IUserUnitOfWork userUnitOfWork)
        {
            this.planUnitOfWork = planUnitOfWork;
            this.userUnitOfWork = userUnitOfWork;
        }

        public void ValidatePlanBy(string name)
        {
            List<SubscriptionPlan> plans = this.planUnitOfWork.GetPlans();

            if (!plans.Any(x => x.Name == name))
            {
                throw new BadHttpRequestException($"Plan with name {name} does not exist");
            }

            SubscriptionPlan desiredPlan = plans.FirstOrDefault(x => x.Name == name);
            Subscription subscription = this.planUnitOfWork.GetCurrentSubscription();
            int currenctLicensesCount = this.userUnitOfWork.GetUsersWithLicenseCount();

            if (currenctLicensesCount > desiredPlan.SeatLimit)
            {
                throw new BadHttpRequestException(
                    $"Cannot switch to plan {desiredPlan.Name} since it allows {desiredPlan.SeatLimit} while {currenctLicensesCount} users have licenses at the moment.");
            }

            if (desiredPlan.Id == subscription.PlanId)
            {
                throw new BadHttpRequestException($"Already subscribed to {desiredPlan.Name} plan.");
            }
        }
    }
}
