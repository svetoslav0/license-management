import {IPlansInfoResponse} from "../api/ApiClientGenerated";

function SubscriptionPlanControlPanel({
        plansInfo
    }: {
        plansInfo: IPlansInfoResponse;
    }) {
    return (
        <div className='text-left'>
            <h2>Subscription Plan</h2>
            <div className='grid grid-cols-2 gap-4'>
                <div className='border p-4'>Current Plan</div>
                <div className='border p-4'>{plansInfo.currentPlan.planName}</div>
            </div>
            <div className='grid grid-cols-2 gap-4'>
                <div className='border p-4'>Max Licenses</div>
                <div className='border p-4'>{plansInfo.currentPlan.seatLimit}</div>
            </div>
            <div className='grid grid-cols-2 gap-4'>
                <div className='border p-4'>Upgrade/Downgrade plan</div>
                <div className='border p-4'>Column</div>
            </div>
        </div>
    );
}

export default SubscriptionPlanControlPanel;