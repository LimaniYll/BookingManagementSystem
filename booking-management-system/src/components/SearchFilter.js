import React, { useState } from 'react';
import axios from 'axios';

const SearchFilter = () => {
    const [searchTerm, setSearchTerm] = useState('');
    const [results, setResults] = useState([]);

    const handleSearch = async () => {
        try {
            const response = await axios.get(`/api/bookings?search=${searchTerm}`);
            setResults(response.data);
        } catch (error) {
            console.error('Search failed:', error.message);
        }
    };

    return (
        <div className="mt-3">
            <div className="form-group">
                <label>Search Bookings</label>
                <input
                    type="text"
                    className="form-control"
                    placeholder="Enter search term"
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
            </div>
            <button onClick={handleSearch} className="btn btn-primary mt-3">Search</button>
            <ul className="list-group mt-3">
                {results.map((result) => (
                    <li key={result.id} className="list-group-item">
                        {result.customerName} - Room {result.roomNumber}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default SearchFilter;
