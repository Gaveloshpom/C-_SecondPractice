import axios from 'axios';

const API_URL = 'https://localhost:7238/api/car'; // אבמ http://localhost:5000 ÿךשמ בוח HTTPS

export const getCars = () => axios.get(API_URL);
export const getCar = (id: string) => axios.get(`${API_URL}/${id}`);
export const createCar = (data: any) => axios.post(API_URL, data);
export const updateCar = (id: string, data: any) => axios.put(`${API_URL}/${id}`, data);
export const deleteCar = (id: string) => axios.delete(`${API_URL}/${id}`);
