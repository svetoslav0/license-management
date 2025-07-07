function LicenseDowngradeWarning() {
    return (
        <div
            className='flex items-start gap-3 p-4 bg-yellow-100 border-l-4 border-yellow-500 text-yellow-800 rounded-md shadow-sm'>
            <div className='text-xl'>⚠️</div>
            <div>
                <p className='font-semibold'>Cannot downgrade</p>
                <p className='text-sm'>
                    You have too many active licenses.
                </p>
            </div>
        </div>
    );
}

export default LicenseDowngradeWarning;