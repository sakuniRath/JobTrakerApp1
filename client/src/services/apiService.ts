import axios from 'axios';

export const apiService = axios.create({
  baseURL: import.meta.env.VITE_BASE_URL,
});
