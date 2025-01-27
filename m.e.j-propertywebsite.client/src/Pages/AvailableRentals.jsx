import React, { useState, useEffect } from 'react';
import Menu from '../Componets/Menu';
import Rental from '../Componets/Cards/Rental';
import './Css/AvailableRentals.css';
import testImage from '../assets/test.jpg';

function AvailableRentals() {
    const [properties, setProperties] = useState([]);
    const [filteredProperties, setFilteredProperties] = useState([]);
    const [filters, setFilters] = useState({
        minPrice: '',
        maxPrice: '',
        minSquareFootage: '',
        maxSquareFootage: '',
    });

    useEffect(() => {
        const dummyData = [
            {
                rentalPropertyId: 1,
                propertyName: 'Hyggelig Lejlighed',
                propertyAddress: 'Hovedgade 123, Byen',
                rentalPrice: 8000,
                propertySquareFootage: 80,
                imageUrl: testImage,
            },
            {
                rentalPropertyId: 2,
                propertyName: 'Rummeligt Hus',
                propertyAddress: 'Elmegade 456, Landsbyen',
                rentalPrice: 15000,
                propertySquareFootage: 200,
                imageUrl: testImage,
            },
            {
                rentalPropertyId: 3,
                propertyName: 'Moderne Lejlighed',
                propertyAddress: 'Egevej 789, Storbyen',
                rentalPrice: 12000,
                propertySquareFootage: 120,
                imageUrl: testImage,
            },
        ];
        setProperties(dummyData);
        setFilteredProperties(dummyData);
    }, []);

    const handleFilterChange = (e) => {
        const { name, value } = e.target;
        setFilters({
            ...filters,
            [name]: value,
        });
    };

    const applyFilters = () => {
        let filtered = properties;

        if (filters.minPrice) {
            filtered = filtered.filter(property => property.rentalPrice >= parseInt(filters.minPrice));
        }
        if (filters.maxPrice) {
            filtered = filtered.filter(property => property.rentalPrice <= parseInt(filters.maxPrice));
        }
        if (filters.minSquareFootage) {
            filtered = filtered.filter(property => property.propertySquareFootage >= parseInt(filters.minSquareFootage));
        }
        if (filters.maxSquareFootage) {
            filtered = filtered.filter(property => property.propertySquareFootage <= parseInt(filters.maxSquareFootage));
        }

        setFilteredProperties(filtered);
    };

    return (
        <div>
            <Menu />
            <div className="available-rentals-container">
                <h1>Tilgængelige Lejemål</h1>
                <div className="filters">
                    <input
                        type="number"
                        name="minPrice"
                        placeholder="Min Pris"
                        value={filters.minPrice}
                        onChange={handleFilterChange}
                    />
                    <input
                        type="number"
                        name="maxPrice"
                        placeholder="Max Pris"
                        value={filters.maxPrice}
                        onChange={handleFilterChange}
                    />
                    <input
                        type="number"
                        name="minSquareFootage"
                        placeholder="Min Kvadratmeter"
                        value={filters.minSquareFootage}
                        onChange={handleFilterChange}
                    />
                    <input
                        type="number"
                        name="maxSquareFootage"
                        placeholder="Max Kvadratmeter"
                        value={filters.maxSquareFootage}
                        onChange={handleFilterChange}
                    />
                    <button onClick={applyFilters}>Anvend Filtre</button>
                </div>
                <div className="rental-cards-container">
                    {filteredProperties.map(property => (
                        <Rental key={property.rentalPropertyId} property={property} />
                    ))}
                </div>
            </div>
        </div>
    );
}

export default AvailableRentals;
