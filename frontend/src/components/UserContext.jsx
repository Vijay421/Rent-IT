import React, { createContext, useState } from "react";

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
    const [userRole, setUserRole] = useState("admin");
    const [userName, setUserName] = useState(null);

    return (
        <UserContext.Provider value={{ userRole, userName, setUserRole, setUserName}}>
            {children}
        </UserContext.Provider>
    );
};