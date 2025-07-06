import React, {useEffect, useState} from 'react';

import { PlanResponse } from '../api/ApiClientGenerated';
import { apiClient } from '../api/apiClient';

import SubscriptionPlanComponent from './SubscriptionPlanComponent';

function Dashboard() {
    const [currentPlan, setCurrentPlan] = useState<PlanResponse | null>(null);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        apiClient.getCurrentPlan()
            .then((plan: PlanResponse) => {
                setCurrentPlan(plan);
                setIsLoading(false);
            })
            .catch(error => {
                console.log(error);
                setIsLoading(false);
            });
    }, []);
    
    if (isLoading) return <>Loading...</>;

    return (
        currentPlan &&
        <div className='container sm:bg-white mx-auto'>
            <SubscriptionPlanComponent currentPlan={currentPlan} />
        </div>
    );
}

export default Dashboard;