import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "../pages/LoginPage.jsx";
import RegisterPage from "../pages/RegisterPage.jsx";
import IndexPage from "../pages/IndexPage.jsx";
import RetrievePasswordPage from "../pages/RetrievePasswordPage.jsx";
import RentingPage from "../pages/RentingPage.jsx";
import ProfilePage from "../pages/ProfilePage.jsx";
import AccountSettings from "../pages/AccountSettings.jsx";

import SubscriptionRequestPage from "../pages/SubscriptionRequestPage.jsx";
import SubscriptionsManagePage from "../pages/SubscriptionsManagePage.jsx";

import RentingSubmitPage from "../pages/RentingSubmitPage.jsx";
import RentHistory from "../pages/RentHistory.jsx";
import ReviewRentRequest from "../pages/ReviewRentRequest.jsx";
import NotificationsPage from "../pages/NotificationsPage.jsx";

import ConfirmationPage from "../pages/ConfirmationPage.jsx";
import RentingPaymentPage from "../pages/RentingPaymentPage.jsx";
import ReserveringPage from "../pages/ReserveringPage.jsx";
import ReserveringWijzigingPage from "../pages/ReserveringWijzigingPage.jsx";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<IndexPage />} />
                <Route path="/registreren" element={<RegisterPage/>} />
                <Route path="/login" element={<LoginPage/>} />
                <Route path="/wachtwoord-vergeten" element={<RetrievePasswordPage/>} />
                <Route path="/huur-overzicht" element={<RentingPage/>} />

                <Route path="/profiel" element={<ProfilePage/>}/>
                <Route path="/account-instellingen" element={<AccountSettings/>}/>

                <Route path="/abonnement" element={<SubscriptionRequestPage/>}/>
                <Route path="/abonnementen" element={<SubscriptionsManagePage/>}/>

                <Route path="/huur-indienen" element={<RentingSubmitPage/>}/>
                <Route path="/huur-geschiedenis" element={<RentHistory/>}/>
                <Route path="/huuraanvraag-beoordelen" element={<ReviewRentRequest/>}/>
                <Route path="/notificaties" element={<NotificationsPage/>}/>
                <Route path="/bevestiging" element={<ConfirmationPage/>}/>
                <Route path="/huur-betaling" element={<RentingPaymentPage/>}/>
                <Route path="/reserveringen" element={<ReserveringPage/>}/>
                <Route path="/reservering-wijziging" element={<ReserveringWijzigingPage/>}/>
            </Routes>
        </Router>
    );
}

export default App;
