import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Rental.css';

function Rental({ property }) {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(`/rental/${property.rentalPropertyId}`);
    };

    return (
        <div className="rental-card" onClick={handleClick}>
            <img src={property.imageUrl} alt={property.propertyName} className="rental-image" />
            <div className="rental-info">
                <h2>{property.propertyName}</h2>
                <p>{property.propertyAddress}</p>
                <p>{property.rentalPrice} Dkk/month</p>
                <p>{property.propertySquareFootage} m2</p>
            </div>
        </div>
    );
}

export default Rental;
