import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import BookingList from './components/BookingList';
import SearchFilter from './components/SearchFilter';
import LoginForm from './components/LoginForm';
import RegisterForm from './components/RegisterForm';

const App = () => {
    const [authenticated, setAuthenticated] = useState(false);

    return (
        <Router>
            <div className="container">
                <nav className="navbar navbar-expand-lg navbar-light bg-light">
                    <Link className="navbar-brand" to="/">Booking Management</Link>
                    <div className="collapse navbar-collapse">
                        <ul className="navbar-nav mr-auto">
                            <li className="nav-item">
                                <Link className="nav-link" to="/bookings">Bookings</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/search">Search</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/login">Login</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/register">Register</Link>
                            </li>
                        </ul>
                    </div>
                </nav>
                <Routes>
                    <Route path="/login" element={<LoginForm setAuthenticated={setAuthenticated} />} />
                    <Route path="/register" element={<RegisterForm />} />
                    <Route path="/bookings" element={<BookingList />} />
                    <Route path="/search" element={<SearchFilter />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
