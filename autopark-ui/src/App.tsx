import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { CarForm } from './components/CarForm';
import { CarList } from './components/CarList';
import { DriverList } from './components/DriverList';
import { DriverForm } from './components/DriverForm';
import { DepartureList } from './components/DepartureList';
import { DepartureForm } from './components/DepartureForm';

export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Navigate to="/cars" />} />
                <Route path="/cars" element={<CarList />} />
                <Route path="/cars/new" element={<CarForm />} />
                <Route path="/cars/edit/:id" element={<CarForm />} />
                <Route path="/drivers" element={<DriverList />} />
                <Route path="/drivers/new" element={<DriverForm />} />
                <Route path="/drivers/edit/:id" element={<DriverForm />} />
                <Route path="/departures" element={<DepartureList />} />
                <Route path="/departures/new" element={<DepartureForm />} />
            </Routes>
        </BrowserRouter>
    );
}

