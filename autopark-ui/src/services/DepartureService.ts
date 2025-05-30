import axios from 'axios';

const API_URL = 'https://localhost:7238/api/departure';

export const getDepartures = () => axios.get(API_URL);
export const createDeparture = (data: any) => axios.post(API_URL, data);
export const deleteDeparture = (date: string, driverNumber: number, carNumber: string) =>
    axios.delete(`${API_URL}?date=${date}&driverId=${driverNumber}&carNumber=${carNumber}`);

