import axios from 'axios';

const API_BASE_URL = 'https://localhost:44379';

export const getPetDetails = () => {
    return axios.get(`${API_BASE_URL}/Pet`);
};

export const addPet = (petData) => {
    return axios.post(`${API_BASE_URL}/Pet`, petData, {
        headers: {
            'Content-Type': 'application/json'
        }
    });
};

export const updatePet = (petData) => {
    return axios.put(`${API_BASE_URL}/Pet`, petData, {
        headers: {
            'Content-Type': 'application/json'
        }
    });
};
