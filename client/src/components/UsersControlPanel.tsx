import { IUserResponseData, UserResponseItem } from '../api/ApiClientGenerated';

function UsersControlPanel({
        usersList,
        assignLicense,
        unassignLicense,
        canAssignMoreLicenses,
    }: {
        usersList: IUserResponseData,
        assignLicense: (userId: number) => void,
        unassignLicense: (userId: number) => void,
        canAssignMoreLicenses: boolean,
    }) {

    return (
        <div className='text-left'>
            <h1>Users</h1>
            <div className='grid grid-cols-4 font-bold'>
                <div className='border p-4'>Name</div>
                <div className='border p-4'>Username</div>
                <div className='border p-4'>License Status</div>
                <div className='border p-4'>Actions</div>
            </div>
            {usersList.users.map((user: UserResponseItem, index: number) => (
                <div className='grid grid-cols-4' key={index}>
                    <div className='border p-4'>{user.name}</div>
                    <div className='border p-4'>{user.username}</div>
                    <div className='border p-4'>{user.hasLicense ? 'Assigned' : 'Not Assigned'}</div>
                    <div className='border p-4'>
                        {user.hasLicense
                            ? <button
                                onClick={() => unassignLicense(user.id)}
                                className='px-4 py-1.5 rounded bg-red-500 hover:bg-red-600 text-white'>
                                Remove License
                              </button>
                            : <button
                                disabled={!canAssignMoreLicenses}
                                onClick={() => assignLicense(user.id)}
                                className='px-4 py-1.5 rounded
                                    bg-green-500 hover:bg-green-600 text-white
                                    disabled:bg-green-300 disabled:text-white/70 disabled:cursor-not-allowed'>
                                Assign License
                              </button>
                        }
                    </div>
                </div>
            ))}
        </div>
    );
}

export default UsersControlPanel;