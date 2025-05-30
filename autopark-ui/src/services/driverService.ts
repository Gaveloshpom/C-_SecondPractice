import axios from 'axios';

const API_URL = 'https://localhost:7238/api/driver'; // або http://localhost:5000

export const getDrivers = () => axios.get(API_URL);
export const getDriver = (id: number) => axios.get(`${API_URL}/${id}`);
export const createDriver = (data: any) => axios.post(API_URL, data);
export const updateDriver = (id: number, data: any) => axios.put(`${API_URL}/${id}`, data);
export const deleteDriver = (id: number) => axios.delete(`${API_URL}/${id}`);
