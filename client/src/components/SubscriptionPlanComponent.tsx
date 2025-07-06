import React, {useEffect, useState} from 'react';

import '../App.css';

import { getCurrentPlan } from '../services/api';

function SubscriptionPlanComponent() {
    const [currentPlan, setCurrentPlan] = useState<any>({});
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        getCurrentPlan()
            .then(response => {
                setCurrentPlan(response.data);
                console.log(response.data);
                setIsLoading(false);
            })
            .catch(error => {
                console.log(error);
                setIsLoading(false);
            });
    }, []);

    if (isLoading) return <div>Loading . . .</div>;

    return (
        <div>
            <h1>Subscription Plan</h1>
            <div>
                Plan: {currentPlan.planName} ({currentPlan.currentLicensesCount}/{currentPlan.seatLimit} licenses used)
            </div>
        </div>
    );
}

export default SubscriptionPlanComponent;