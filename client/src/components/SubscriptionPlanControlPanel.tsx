import { useState } from 'react';
import Select, { SingleValue } from 'react-select';

import { IPlansInfoResponse } from '../api/ApiClientGenerated';
import { IValueLabelOption } from '../interfaces/IValueLabelOption';

function SubscriptionPlanControlPanel({
        plansInfo
    }: {
        plansInfo: IPlansInfoResponse;
    }) {

    const [isBButtonDisabled, setIsBButtonDisabled] = useState(true);

    const options: IValueLabelOption[] = plansInfo.plans.map(item => ({
        value: item.name.toLowerCase(),
        label: item.name
    }));

    const handleOnSelect = (event: SingleValue<IValueLabelOption>) => {
        setIsBButtonDisabled(event?.label === plansInfo.currentPlan.planName);
    }

    return (
        <div className='text-left'>
            <div className='grid grid-cols-2 gap-4'>
                <div className='border p-4'>Max Licenses</div>
                <div className='border p-4'>{plansInfo.currentPlan.seatLimit}</div>
            </div>
            <div className='grid grid-cols-2 gap-4'>
                <div className='border p-4'>Upgrade/Downgrade plan</div>
                <div className='border p-4'>
                    <div className='flex items-center gap-2'>
                        <Select
                            className='basic-single'
                            classNamePrefix='select'
                            defaultValue={options.filter(i => i.label === plansInfo.currentPlan.planName)}
                            isLoading={false}
                            options={options}
                            onChange={(x: SingleValue<IValueLabelOption>) => handleOnSelect(x)}
                            styles={{container: (base) => ({...base, flex: 1})}}
                        />
                        <button
                            disabled={isBButtonDisabled}
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