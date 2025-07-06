import { PlanResponse } from '../api/ApiClientGenerated';

function SubscriptionPlanComponent({
        currentPlan
    }: {
        currentPlan: PlanResponse;
    }) {

    return (
        currentPlan &&
        <div>
            <h1>Subscription Plan</h1>
            <div>
                Plan: {currentPlan.planName} ({currentPlan.currentLicensesCount}/{currentPlan.seatLimit} licenses used)
            </div>
        </div>
    );
}

export default SubscriptionPlanComponent;