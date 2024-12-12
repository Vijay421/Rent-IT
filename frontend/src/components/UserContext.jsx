import { createContext, useState } from "react";
import PropTypes from "prop-types";

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
    // TODO: change this back to: particuliere_huurder
    const [userRole, setUserRole] = useState("backoffice_medewerker");
    // const [userRole, setUserRole] = useState(null);
    const [userName, setUserName] = useState(null);

    return (
        <UserContext.Provider value={{ userRole, userName, setUserRole, setUserName}}>
            {children}
        </UserContext.Provider>
    );
};

UserProvider.propTypes = {
    children: PropTypes.node,
};