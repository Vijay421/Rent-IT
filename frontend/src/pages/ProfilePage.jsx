import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import ProfilePageParticulier from "../components/Profile/ProfilePageParticulier.jsx";
import ProfilePageZakelijk from "../components/Profile/ProfilePageZakelijk.jsx";
import ProfilePageAdmin from "../components/Profile/ProfilePageAdmin.jsx";
import ProfilePageZakelijkeBeheerder from "../components/Profile/ProfilePageZakelijkeBeheerder.jsx";
import ProfilePageFrontOffice from "../components/Profile/ProfilePageFrontOffice.jsx";
import ProfilePageBackOffice from "../components/Profile/ProfilePageBackOffice.jsx";
import {useContext} from "react";
import { UserContext } from "../components/UserContext.jsx";

export default function ProfilePage() {
    const { userRole } = useContext(UserContext);
    console.log(userRole);

    if (userRole === null) {
        // TODO: redirect to index page, because user is not logged in.
    }

    return (
        <>
            <Navbar />
            {userRole === "particuliere_huurder" && (
                <ProfilePageParticulier role="Particuliere Huurder" />
            )}
            {userRole === "zakelijke_huurder" && (
                <ProfilePageZakelijk role="Zakelijke Huurder" />
            )}
            {userRole === "zakelijke_beheerder" && (
                <ProfilePageZakelijkeBeheerder role="Zakelijke Beheerder" />
            )}
            {userRole === "admin" && (
                <ProfilePageAdmin role="Admin" />
            )}
            {userRole === "frontoffice_medewerker" && (
                <ProfilePageFrontOffice role="Frontoffice Medewerker" />
            )}
            {userRole === "backoffice_medewerker" && (
                <ProfilePageBackOffice role="Backoffice Medewerker" />
            )}
            {!userRole && <p>Loading user role...</p>}
            <Footer />
        </>
    );
}