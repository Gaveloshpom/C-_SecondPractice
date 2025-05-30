import React, { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route, Link, useNavigate, useParams } from 'react-router-dom';
import * as carService from '../services/carService';

export function CarList() {
    const [cars, setCars] = useState<any[]>([]);

    useEffect(() => {
        carService.getCars().then(res => setCars(res.data));
    }, []);

    const handleDelete = async (carNumber: string) => {
        await carService.deleteCar(carNumber);
        setCars(prev => prev.filter(c => c.carNumber !== carNumber));
    };

    return (
        <div>
            <h2>Список машин</h2>
            <Link to="/cars/new">Додати нову машину</Link>
            <ul>
                {cars.map(car => (
                    <li key={car.carNumber}>
                        {car.carNumber} — {car.brand} ({car.carType})
                        <button onClick={() => handleDelete(car.carNumber)}>🗑</button>
                        <Link to={`/cars/edit/${car.carNumber}`}>✏️</Link>
                    </li>
                ))}
            </ul>
        </div>
    );
}