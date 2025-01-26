import { createContext, useState, useEffect } from 'react';
import PropTypes from "prop-types";


export const AuthContext = createContext();

export function AuthProvider({ children }) {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    useEffect(() => {
        const hasClaims = sessionStorage.getItem('userClaims') !== null;
        setIsLoggedIn(hasClaims);
    }, []);

    const login = () => {
        setIsLoggedIn(true);
    };

    const logout = () => {
        sessionStorage.removeItem('userClaims');
        setIsLoggedIn(false);

        callLogoutEndpoint();
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

/**
 * Call the server to preform a logout.
 * @returns {Object}
 */
async function callLogoutEndpoint() {
    const request = {
        method: 'POST',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
    };

    try {
        const response = await fetch('https://localhost:53085/api/User/logout', request);

        if (!response.ok) {
            console.error('server error when logging out');
            const serverError = await response.text();
            console.error(serverError);
        }
    } catch (error) {
        console.error('error when logging out, or parsing the response:', error);
        throw error;
    }
}