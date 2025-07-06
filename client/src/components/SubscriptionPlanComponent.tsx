import React, {useEffect, useState} from 'react';

import { PlanResponse } from '../api/ApiClientGenerated';
import { apiClient } from '../api/apiClient';

function SubscriptionPlanComponent() {
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

    if (isLoading) return <div>Loading . . .</div>;

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