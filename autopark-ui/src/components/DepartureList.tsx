import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import * as departureService from '../services/departureService';

export function DepartureList() {
    const [departures, setDepartures] = useState<any[]>([]);

    useEffect(() => {
        departureService.getDepartures().then(res => setDepartures(res.data));
    }, []);

    const handleDelete = async (dep: any) => {
        await departureService.deleteDeparture(dep.departureDate, dep.driverNumber, dep.carNumber);
        setDepartures(prev => prev.filter(d =>
            !(d.departureDate === dep.departureDate && d.driverNumber === dep.driverNumber && d.carNumber === dep.carNumber)
        ));
    };

    return (
        <div>
            <h2>Список виїздів</h2>
            <Link to="/departures/new">Додати виїзд</Link>
            <ul>
                {departures.map((dep, i) => (
                    <li key={i}>
                        {dep.departureDate} - Водій #{dep.driverNumber} - Машина {dep.carNumber} - {dep.distance} км
                        <button onClick={() => handleDelete(dep)}>🗑</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}