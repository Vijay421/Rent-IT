import Navbar from "../components/Navbar.jsx";
import Profile from "../components/Profile.jsx";
import Footer from "../components/Footer.jsx";
import { UserContext } from "../components/UserContext.jsx";
import {useContext} from "react";

export default function ProfilePage() {
    const { userRole } = useContext(UserContext);

    return (
        <>
            <Navbar />
            {/* Conditional rendering based on userRole */}
            {userRole === "particuliere_huurder" && (
                <Profile role="Particuliere Huurder" />
            )}
            {userRole === "zakelijke_huurder" && (
                <Profile role="Zakelijke Huurder" />
            )}
            {userRole === "admin" && <Profile role="Admin" />}
            {userRole === "frontoffice_medewerker" && (
                <Profile role="Frontoffice Medewerker" />
            )}
            {userRole === "backoffice_medewerker" && (
                <Profile role="Backoffice Medewerker" />
            )}
            {/* Fallback for undefined role */}
            {!userRole && <p>Loading user role...</p>}
            <Footer />
        </>
    );
}
