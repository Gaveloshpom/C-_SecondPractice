import React, { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route, Link, useNavigate, useParams } from 'react-router-dom';
import * as driverService from '../services/driverService';
export function DriverForm() {
    const navigate = useNavigate();
    const { id } = useParams();
    const [driver, setDriver] = useState({
        passportSeries: '',
        passportNumber: 0,
        lastName: '',
        firstName: '',
        middleName: '',
        licenseDate: '',
        licenseCategory: 'B'
    });

    useEffect(() => {
        if (id) {
            driverService.getDriver(Number(id)).then(res => setDriver(res.data));
        }
    }, [id]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        setDriver({ ...driver, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (id) await driverService.updateDriver(Number(id), driver);
        else await driverService.createDriver(driver);
        navigate('/drivers');
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>{id ? 'Редагувати' : 'Додати'} водія</h2>
            <input name="passportSeries" value={driver.passportSeries} onChange={handleChange} placeholder="Серія" required />
            <input name="passportNumber" type="number" value={driver.passportNumber} onChange={handleChange} required />
            <input name="lastName" value={driver.lastName} onChange={handleChange} placeholder="Прізвище" required />
            <input name="firstName" value={driver.firstName} onChange={handleChange} placeholder="Ім’я" required />
            <input name="middleName" value={driver.middleName} onChange={handleChange} placeholder="По батькові" required />
            <input name="licenseDate" type="date" value={driver.licenseDate} onChange={handleChange} required />
            <select name="licenseCategory" value={driver.licenseCategory} onChange={handleChange}>
                <option value="A">A</option>
                <option value="B">B</option>
                <option value="C">C</option>
            </select>
            <button type="submit">Зберегти</button>
        </form>
    );
}