import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7217/api/',
});

// GET methods
export const getPictures = () => api.get('pictures');

// POST methods
export const addPicture = (formData) => api.post('pictures', formData);
