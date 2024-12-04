import { createContext, useState, useEffect } from 'react';
import PropTypes from "prop-types";


export const AuthContext = createContext();

export function AuthProvider({ children }) {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    useEffect(() => {
        const token = localStorage.getItem('accessToken');
        setIsLoggedIn(!!token); // !! casts a variable to boolean https://shorturl.at/W8BMj
    }, []);

    const login = () => {
        setIsLoggedIn(true);
    };

    const logout = () => {
        // TODO: actually log out on the backend too.
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        localStorage.removeItem('userClaims');
        setIsLoggedIn(false);
    };

    return (
        <AuthContext.Provider value={{ isLoggedIn, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
}

// Ensures that the prop passed to AuthProvider is a prop
AuthProvider.propTypes = {
    children: PropTypes.node,
};