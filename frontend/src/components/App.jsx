import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "../pages/LoginPage.jsx";
import RegisterPage from "../pages/RegisterPage.jsx";
import IndexPage from "../pages/IndexPage.jsx";
import RetrievePasswordPage from "../pages/RetrievePasswordPage.jsx";
import RentingPage from "../pages/RentingPage.jsx";
import ProfilePage from "../pages/ProfilePage.jsx";
import AccountSettings from "../pages/AccountSettings.jsx";
import SubscriptionRequestPage from "../pages/SubscriptionRequestPage.jsx";
import RentingSubmitPage from "../pages/RentingSubmitPage.jsx";
import RentHistory from "../pages/RentHistory.jsx";
import ReviewRentRequest from "../pages/ReviewRentRequest.jsx";
import NotificationsPage from "../pages/NotificationsPage.jsx";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<IndexPage />} />
                <Route path="/register" element={<RegisterPage/>} />
                <Route path="/login" element={<LoginPage/>} />
                <Route path="/retrievepassword" element={<RetrievePasswordPage/>} />
                <Route path="/renting" element={<RentingPage/>} />
                <Route path="/wachtwoord-vergeten" element={<RetrievePasswordPage/>}/>
                <Route path="/profile" element={<ProfilePage/>}/>
                <Route path="/account-settings" element={<AccountSettings/>}/>
                <Route path="/abonnement" element={<SubscriptionRequestPage/>}/>
                <Route path="/renting-submit" element={<RentingSubmitPage/>}/>
                <Route path="/huur-geschiedenis" element={<RentHistory/>}/>
                <Route path="/huuraanvraag-beoordelen" element={<ReviewRentRequest/>}/>
                <Route path="/notificaties" element={<NotificationsPage/>}/>
            </Routes>
        </Router>
    );
}

export default App;
