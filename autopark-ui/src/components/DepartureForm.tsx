import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import * as departureService from '../services/departureService';
export function DepartureForm() {
    const navigate = useNavigate();
    const [departure, setDeparture] = useState({
        departureDate: '',
        driverNumber: 0,
        carNumber: '',
        distance: 0
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setDeparture({ ...departure, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await departureService.createDeparture(departure);
        navigate('/departures');
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Новий виїзд</h2>
            <input name="departureDate" type="date" value={departure.departureDate} onChange={handleChange} required />
            <input name="driverNumber" type="number" value={departure.driverNumber} onChange={handleChange} required />
            <input name="carNumber" value={departure.carNumber} onChange={handleChange} placeholder="Номер авто" required />
            <input name="distance" type="number" value={departure.distance} onChange={handleChange} required />
            <button type="submit">Зберегти</button>
        </form>
    );
}
