// BookingForm.js
import React, { useState } from 'react';
import axios from 'axios';

const BookingForm = () => {
    const [customerName, setCustomerName] = useState('');
    const [roomNumber, setRoomNumber] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('/api/bookings', { customerName, roomNumber });
            alert('Booking created successfully');
            setCustomerName('');
            setRoomNumber('');
        } catch (error) {
            console.error('Booking creation failed:', error.message);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="mt-3">
            <div className="form-group">
                <label>Customer Name</label>
                <input
                    type="text"
                    className="form-control"
                    placeholder="Enter customer name"
                    value={customerName}
                    onChange={(e) => setCustomerName(e.target.value)}
                />
            </div>
            <div className="form-group">
                <label>Room Number</label>
                <input
                    type="text"
                    className="form-control"
                    placeholder="Enter room number"
                    value={roomNumber}
                    onChange={(e) => setRoomNumber(e.target.value)}
                />
            </div>
            <button type="submit" className="btn btn-primary mt-3">Create Booking</button>
        </form>
    );
};

export default BookingForm;
