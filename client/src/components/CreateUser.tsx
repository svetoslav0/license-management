import { useState } from 'react';

// @ts-ignore
export default function CreateUserForm({ onSubmit }) {
    const [name, setName] = useState('');
    const [username, setUsername] = useState('');

    // @ts-ignore
    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(username, name);
        setName('');
        setUsername('');
    };

    return (
        <form
            onSubmit={handleSubmit}
            className="bg-white p-6 rounded-2xl shadow-md max-w-md mx-auto space-y-4"
        >
            <h2 className="text-xl font-semibold">Create User</h2>

            <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Name</label>
                <input
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    required
                />
            </div>

            <div>
                <label className="block text-sm font-medium text-gray-700 mb-1">Username</label>
                <input
                    type="text"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    className="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    required
                />
            </div>

            <button
                type="submit"
                className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700"
            >
                Create
            </button>
        </form>
    );
}
