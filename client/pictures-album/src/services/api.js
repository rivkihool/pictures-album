import axios from 'axios';

// Create a reusable Axios instance with a base API URL
const api = axios.create({
    baseURL: 'https://localhost:7217/api/',// Backend base URL (adjust if needed)
});

// GET: Retrieve the list of pictures from the server
export const getPictures = () => api.get('pictures');

// POST: Upload a new picture to the server
// formData should include the image file, name, and optional description/date
export const addPicture = (formData) => api.post('pictures', formData);
