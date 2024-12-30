import { createContext, useState } from "react";
import PropTypes from "prop-types";

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
    const [userRole, setUserRole] = useState(null);
    const [userName, setUserName] = useState(null);
    const [userId, setUserId] = useState(null);

    return (
        <UserContext.Provider value={{ userRole, userName, userId, setUserRole, setUserName, setUserId}}>
            {children}
        </UserContext.Provider>
    );
};

UserProvider.propTypes = {
    children: PropTypes.node,
};