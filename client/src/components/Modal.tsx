// @ts-ignore
export default function Modal({ isOpen, onClose, children }) {
    if (!isOpen) return null;

    return (
        <div className='fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50'>
            <div className='bg-white p-6 rounded-2xl shadow-lg max-w-md w-full relative'>
                <button
                    onClick={onClose}
                    className='absolute top-2 right-2 text-gray-500 hover:text-gray-700'
                >
                    &times;
                </button>
                {children}
            </div>
        </div>
    );
}