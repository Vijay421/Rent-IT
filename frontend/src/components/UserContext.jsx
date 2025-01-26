import { createContext, useState } from "react";
import PropTypes from "prop-types";

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
    const [userRole, setUserRole] = useState(null);
    const [userName, setUserName] = useState(null);
    const [userId, setUserId] = useState(null);

    // Get the user claims from the session if they weren't defined already (happens on page reload).
    if (userRole === null || userName === null) {
        const userClaimsString = sessionStorage.getItem("userClaims");
        if (userClaimsString !== null) {
            const userClaims = JSON.parse(userClaimsString); 
            setUserRole(userClaims.role);
            setUserName(userClaims.userName);
        }
    }

    return (
        <UserContext.Provider value={{ userRole, userName, userId, setUserRole, setUserName, setUserId}}>
            {children}
        </UserContext.Provider>
    );
};

UserProvider.propTypes = {
    children: PropTypes.node,
};