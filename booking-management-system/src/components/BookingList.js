// BookingList.js
import React, { useState, useEffect } from 'react';
import { getAllBookings, searchBookings } from '../services/api';
import BookingForm from './BookingForm';
import SearchFilter from './SearchFilter';

const BookingList = () => {
    const [bookings, setBookings] = useState([]);
    const [searchParams, setSearchParams] = useState({ customerName: '', roomNumber: '' });

    useEffect(() => {
        fetchBookings();
    }, []);

    const fetchBookings = async () => {
        try {
            const data = await getAllBookings();
            setBookings(data);
        } catch (error) {
            console.error('Error fetching bookings:', error.message);
        }
    };

    const handleSearch = async (params) => {
        try {
            const data = await searchBookings(params);
            setBookings(data);
        } catch (error) {
            console.error('Error searching bookings:', error.message);
        }
    };

    return (
        <div>
            <h1>Bookings</h1>
            <SearchFilter onSearch={handleSearch} />
            <BookingForm fetchBookings={fetchBookings} />
            <ul>
                {bookings.map(booking => (
                    <li key={booking.id}>
                        {booking.customerName} - Room {booking.roomNumber} - Date: {new Date(booking.bookingDate).toLocaleString()}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default BookingList;
