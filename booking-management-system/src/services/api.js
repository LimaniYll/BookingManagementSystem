// api.js
import axios from 'axios';

const API_BASE_URL = 'https://localhost:44371/api'; 

// Function to register a new user
export const registerUser = async (userData) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/user/register`, userData);
        return response.data;
    } catch (error) {
        console.error('User registration failed:', error.message);
        throw error;
    }
};

// Function to login a users
export const loginUser = async (credentials) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/user/login`, credentials);
        return response.data;
    } catch (error) {
        console.error('Login failed:', error.message);
        throw error;
    }
};

// Function to create a new booking
export const createBooking = async (bookingData) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/bookings`, bookingData);
        return response.data;
    } catch (error) {
        console.error('Booking creation failed:', error.message);
        throw error;
    }
};

// Function to get all bookings
export const getAllBookings = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}/bookings`);
        return response.data;
    } catch (error) {
        console.error('Fetching bookings failed:', error.message);
        throw error;
    }
};

// Function to search bookings with filters
export const searchBookings = async (searchParams) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/bookings/search`, { params: searchParams });
        return response.data;
    } catch (error) {
        console.error('Search failed:', error.message);
        throw error;
    }
};
