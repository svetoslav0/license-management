import { Client } from './ApiClientGenerated';

const BASE_URL = 'https://localhost:7012'; // TODO: put in config

export const apiClient = new Client(BASE_URL);