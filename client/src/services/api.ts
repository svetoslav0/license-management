import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7012',
    headers: {
        'Content-Type': 'application/json'
    }
});

export const getCurrentPlan = () => api.get('/plan');