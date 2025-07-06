import { IPlansInfoResponse } from '../api/ApiClientGenerated';

function SubscriptionPlanBasicInfo({
        plansInfo
    }: {
        plansInfo: IPlansInfoResponse;
    }) {

    return (
        plansInfo &&
        <div>
            <h1>Subscription Plan</h1>
            <div>
                Plan: {plansInfo.currentPlan.planName} ({plansInfo.currentPlan.currentLicensesCount}/{plansInfo.currentPlan.seatLimit} licenses used)
            </div>
        </div>
    );
}

export default SubscriptionPlanBasicInfo;