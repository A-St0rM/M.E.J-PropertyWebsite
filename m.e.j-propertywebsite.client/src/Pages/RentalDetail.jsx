import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Menu from '../Componets/Menu';
import './Css/RentalDetail.css';

function RentalDetail() {
    const { id } = useParams();
    const [property, setProperty] = useState(null);

    useEffect(() => {
        fetch(`/api/rentalproperties/${id}`) //dummy endpoint virker ik btw
            .then(response => response.json())
            .then(data => setProperty(data));
    }, [id]);

    if (!property) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <Menu />
            <div className="rental-detail-container">
                <h1>{property.propertyName}</h1>
                <img src={property.imageUrl} alt={property.propertyName} className="rental-detail-image" />
                <p>{property.description}</p>
                <p>Address: {property.propertyAddress}</p>
                <p>Price: {property.rentalPrice} USD/month</p>
                <p>Square Footage: {property.propertySquareFootage} sq ft</p>
                <p>Room Size: {property.propertyRoomSize}</p>
                <p>Pets Allowed: {property.petsAllowed ? 'Yes' : 'No'}</p>
                <p>Date Available: {new Date(property.dateAvailable).toLocaleDateString()}</p>
            </div>
        </div>
    );
}

export default RentalDetail;
