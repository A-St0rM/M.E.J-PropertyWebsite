import { useEffect, useState } from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';
import FrontPage from './pages/FrontPage';
import About from './pages/About';
import Contact from './pages/Contact';
import AvailableRentals from './pages/AvailableRentals';
import Login from './pages/Login';
import RentalDetail from './pages/RentalDetail';


function App() {


    return (
        <div>
            <Routes>
                <Route path="/" element={<FrontPage />} />
                <Route path="/about" element={<About />} />
                <Route path="/contact" element={<Contact />} />
                <Route path="/rental/:id" element={<RentalDetail />} />
                <Route path="/availableRentals" element={<AvailableRentals />} />
                <Route path="/login" element={<Login />} />
            </Routes>
        </div>
    );
    
}

export default App;