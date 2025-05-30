import React, { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route, Link, useNavigate, useParams } from 'react-router-dom';
import * as carService from '../services/carService';
export function CarForm() {
    const navigate = useNavigate();
    const { id } = useParams();
    const [car, setCar] = useState({
        carNumber: '',
        brand: '',
        carType: 'легковий',
        releaseYearMonth: '',
        enginePower: 100,
        fuelConsumption: 5.5
    });

    useEffect(() => {
        if (id) {
            carService.getCar(id).then(res => setCar(res.data));
        }
    }, [id]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        setCar({ ...car, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (id) await carService.updateCar(id, car);
        else await carService.createCar(car);
        navigate('/cars');
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>{id ? 'Редагувати' : 'Додати'} машину</h2>
            <input name="carNumber" value={car.carNumber} onChange={handleChange} placeholder="Номер" required disabled={!!id} />
            <input name="brand" value={car.brand} onChange={handleChange} placeholder="Марка" required />
            <select name="carType" value={car.carType} onChange={handleChange}>
                <option value="легковий">Легковий</option>
                <option value="автобус">Автобус</option>
                <option value="вантажний">Вантажний</option>
            </select>
            <input name="releaseYearMonth" type="date" value={car.releaseYearMonth} onChange={handleChange} required />
            <input name="enginePower" type="number" value={car.enginePower} onChange={handleChange} min={10} max={1000} required />
            <input name="fuelConsumption" type="number" step="0.1" value={car.fuelConsumption} onChange={handleChange} required />
            <button type="submit">Зберегти</button>
        </form>
    );
}