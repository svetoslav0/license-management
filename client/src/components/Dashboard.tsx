import React, { useEffect, useState } from 'react';

import { IPlansInfoResponse } from '../api/ApiClientGenerated';
import { apiClient } from '../api/apiClient';

import SubscriptionPlanBasicInfo from './SubscriptionPlanBasicInfo';
import SubscriptionPlanControlPanel from './SubscriptionPlanControlPanel'

function Dashboard() {
    const [plansInfo, setPlansInfo] = useState<IPlansInfoResponse | null>(null);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        apiClient.getPlansInfo()
            .then((plans: IPlansInfoResponse) => {
                console.log(plans);
                setPlansInfo(plans);
                setIsLoading(false);
            })
            .catch(error => {
                console.log(error);
                setIsLoading(false);
            });
    }, []);

    if (isLoading) return <>Loading...</>;

    return (
        plansInfo &&
        plansInfo.currentPlan &&
        <div className='container sm:bg-white mx-auto'>
            <SubscriptionPlanBasicInfo plansInfo={plansInfo} />
            <SubscriptionPlanControlPanel plansInfo={plansInfo} />
        </div>
    );
}

export default Dashboard;