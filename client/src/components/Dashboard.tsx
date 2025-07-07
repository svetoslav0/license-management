import React, { useEffect, useState } from 'react';

import { toast } from 'react-toastify';

import {
    IPlansInfoResponse,
    IResponseMessage,
    IUserResponse,
    IUserResponseData
} from '../api/ApiClientGenerated';
import { apiClient } from '../api/apiClient';

import SubscriptionPlanBasicInfo from './SubscriptionPlanBasicInfo';
import SubscriptionPlanControlPanel from './SubscriptionPlanControlPanel'
import UsersControlPanel from './UsersControlPanel';
import CreateUser from './CreateUser';
import Modal from './Modal';

function Dashboard() {
    const [plansInfo, setPlansInfo] = useState<IPlansInfoResponse | null>(null);
    const [usersList, setUsersList] = useState<IUserResponseData | null>(null);
    const [isLoading, setIsLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);

    useEffect(() => {
        fetchPlansInfo();
        fetchUsersList();
    }, []);

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

    const assignLicense = (userId: number) => {
        apiClient.assignLicense(userId)
            .then((response: IResponseMessage) => {
                toast.success(response.message);
                fetchPlansInfo();
                fetchUsersList();
            })
            .catch(error => {
                console.log(error);
            });
    };

    const unassignLicense = (userId: number) => {
        apiClient.unassignLicense(userId)
            .then((response: IResponseMessage) => {
                toast.success(response.message);
                fetchPlansInfo();
                fetchUsersList();
            })
            .catch(error => {
                console.log(error);
            });
    };

    const createUser = (email: string, name: string) => {
        apiClient.createUser(email, name)
            .then((response: IResponseMessage) => {
                toast.success(response.message);
                setIsModalOpen(false);
                fetchUsersList();
            })
            .catch(error => {
                toast.error('Could not create user');
                console.log(error);
            })
    }

    if (isLoading) return <>Loading...</>;

    return (
        plansInfo &&
        plansInfo.currentPlan &&
        usersList &&
        <div className='container sm:bg-white mx-auto'>
            <SubscriptionPlanBasicInfo plansInfo={plansInfo}/>
            <SubscriptionPlanControlPanel
                plansInfo={plansInfo}
                refreshPlansInfo={fetchPlansInfo}/>
            <UsersControlPanel
                usersList={usersList}
                assignLicense={assignLicense}
                unassignLicense={unassignLicense}
                canAssignMoreLicenses={plansInfo.currentPlan.seatLimit > plansInfo.currentPlan.currentLicensesCount}
            />

            <button
                onClick={() => setIsModalOpen(true)}
                className='bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700'
            >
                Create New User
            </button>
            <div className='min-h-screen flex items-center justify-center bg-gray-100'>
                <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)}>
                    <CreateUser onSubmit={createUser} />
                </Modal>
            </div>
        </div>
    );
}

export default Dashboard;