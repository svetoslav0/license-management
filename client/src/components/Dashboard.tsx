import React, { useEffect, useState } from 'react';

import {IPlansInfoResponse, IUserResponse, IUserResponseData} from '../api/ApiClientGenerated';
import { apiClient } from '../api/apiClient';

import SubscriptionPlanBasicInfo from './SubscriptionPlanBasicInfo';
import SubscriptionPlanControlPanel from './SubscriptionPlanControlPanel'
import UsersControlPanel from './UsersControlPanel';

function Dashboard() {
    const [plansInfo, setPlansInfo] = useState<IPlansInfoResponse | null>(null);
    const [usersList, setUsersList] = useState<IUserResponseData | null>(null);
    const [isLoading, setIsLoading] = useState(true);

    const fetchPlansInfo = () => {
        setIsLoading(true);

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
    }

    const fetchUsersList = () => {
        apiClient.getUsers()
            .then((users: IUserResponse) => {
                console.log(users);
                setUsersList(users.data);
            })
            .catch(error => {
                console.log(error);
            })
    }

    useEffect(() => {
        fetchPlansInfo();
        fetchUsersList();
    }, []);

    if (isLoading) return <>Loading...</>;

    return (
        plansInfo &&
        plansInfo.currentPlan &&
        usersList &&
        <div className='container sm:bg-white mx-auto'>
            <SubscriptionPlanBasicInfo plansInfo={plansInfo} />
            <SubscriptionPlanControlPanel plansInfo={plansInfo} refreshPlansInfo={fetchPlansInfo} />
            <UsersControlPanel usersList={usersList} />
        </div>
    );
}

export default Dashboard;