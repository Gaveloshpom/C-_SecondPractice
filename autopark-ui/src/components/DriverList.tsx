import React, { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route, Link, useNavigate, useParams } from 'react-router-dom';
import * as driverService from '../services/driverService';

export function DriverList() {
    const [drivers, setDrivers] = useState<any[]>([]);

    useEffect(() => {
        driverService.getDrivers().then(res => setDrivers(res.data));
    }, []);

    const handleDelete = async (id: number) => {
        await driverService.deleteDriver(id);
        setDrivers(prev => prev.filter(d => d.driverNumber !== id));
    };

    return (
        <div>
            <h2>Список водіїв</h2>
            <Link to="/drivers/new">Додати нового водія</Link>
            <ul>
                {drivers.map(driver => (
                    <li key={driver.driverNumber}>
                        {driver.lastName} {driver.firstName} ({driver.licenseCategory})
                        <button onClick={() => handleDelete(driver.driverNumber)}>🗑</button>
                        <Link to={`/drivers/edit/${driver.driverNumber}`}>✏️</Link>
                    </li>
                ))}
            </ul>
        </div>
    );
}