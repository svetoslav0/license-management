import { useState } from 'react';
import Select, { SingleValue } from 'react-select';

import { toast } from 'react-toastify';

import { IPlansInfoResponse } from '../api/ApiClientGenerated';
import { IValueLabelOption } from '../interfaces/IValueLabelOption';
import { apiClient } from '../api/apiClient';

function SubscriptionPlanControlPanel({
        plansInfo,
        refreshPlansInfo
    }: {
        plansInfo: IPlansInfoResponse;
        refreshPlansInfo: () => void;
    }) {

    const [isButtonDisabled, setIsButtonDisabled] = useState<boolean>(true);
    const [selectedPlanName, setSelectedPlanName] = useState<string>(plansInfo.currentPlan.planName);

    const options: IValueLabelOption[] = plansInfo.plans.map(item => ({
        value: item.name.toLowerCase(),
        label: item.name
    }));

    const handleOnSelectChange = (event: SingleValue<IValueLabelOption>) => {
        setSelectedPlanName(event?.label || '')
        setIsButtonDisabled(event?.label === plansInfo.currentPlan.planName);
    }

    const handleOnChangePlanButtonClick = () => {
        apiClient.switchPlan(selectedPlanName)
            .then((response) => {
                refreshPlansInfo();
                setIsButtonDisabled(true);
                toast.success('Plan was changed successfully.');
            })
            .catch((error) => {
                console.log(error);
                toast.error(error.message);
            });
    }

    return (
        <div className='text-left'>
            <div className='grid grid-cols-2'>
                <div className='border p-4'>Max Licenses</div>
                <div className='border p-4'>{plansInfo.currentPlan.seatLimit}</div>
            </div>
            <div className='grid grid-cols-2'>
                <div className='border p-4'>Upgrade/Downgrade plan</div>
                <div className='border p-4'>
                    <div className='flex items-center gap-2'>
                        {/* TODO: Disable or notify if too many licenses */}
                        <Select
                            className='basic-single'
                            classNamePrefix='select'
                            defaultValue={options.filter(i => i.label === plansInfo.currentPlan.planName)}
                            isLoading={false}
                            options={options}
                            onChange={(x: SingleValue<IValueLabelOption>) => handleOnSelectChange(x)}
                            styles={{container: (base) => ({...base, flex: 1})}}
                        />
                        <button
                            disabled={isButtonDisabled}
                            onClick={handleOnChangePlanButtonClick}
                            className='px-4 py-1.5 rounded text-white bg-blue-500 disabled:bg-gray-300 disabled:text-gray-500 disabled:cursor-not-allowed'>
                            Change Plan
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default SubscriptionPlanControlPanel;