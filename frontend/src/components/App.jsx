import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "../pages/LoginPage.jsx";
import RegisterPage from "../pages/RegisterPage.jsx";
import EmployeeOverviewPage from "../pages/EmployeeOverviewPage";
import IndexPage from "../pages/IndexPage.jsx";
import RetrievePasswordPage from "../pages/RetrievePasswordPage.jsx";
import RentingPage from "../pages/RentingPage.jsx";
import ProfilePage from "../pages/ProfilePage.jsx";
import AccountSettings from "../pages/AccountSettings.jsx";

import VehicleOverviewPage from "../pages/VehicleOverviewPage";
import VehicleCreateAndUpdate from "../pages/VehicleCreateAndUpdate";

import SubscriptionRequestPage from "../pages/SubscriptionRequestPage.jsx";
import SubscriptionsManagePage from "../pages/SubscriptionsManagePage.jsx";
import SubscriptionOverviewPage from "../pages/SubscriptionOverviewPage.jsx";

import RentingSubmitPage from "../pages/RentingSubmitPage.jsx";
import RentHistory from "../pages/RentHistory.jsx";
import ReviewRentRequest from "../pages/ReviewRentRequest.jsx";
import NotificationsPage from "../pages/NotificationsPage.jsx";

import ConfirmationPage from "../pages/ConfirmationPage.jsx";
import RentingPaymentPage from "../pages/RentingPaymentPage.jsx";
import ReserveringPage from "../pages/ReserveringPage.jsx";
import ReserveringWijzigingPage from "../pages/ReserveringWijzigingPage.jsx";

import FrontofficeIntakePage from "../pages/FrontofficeIntakePage.jsx";
import FrontofficeExpenditurePage from "../pages/FrontofficeExpenditurePage.jsx";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<IndexPage />} />
                <Route path="/registreren" element={<RegisterPage/>} />
                <Route path="/medewerker-aanmaken" element={<RegisterPage/>} />
                <Route path="/medewerkersoverzicht" element={<EmployeeOverviewPage/>} />
                <Route path="/login" element={<LoginPage/>} />
                <Route path="/wachtwoord-vergeten" element={<RetrievePasswordPage/>} />
                <Route path="/huur-overzicht" element={<RentingPage/>} />

                <Route path="/voertuigoverzicht" element={<VehicleOverviewPage/>} />
                <Route path="/voertuig-aanpassen" element={<VehicleCreateAndUpdate/>} />

                <Route path="/profiel" element={<ProfilePage/>}/>
                <Route path="/account-instellingen" element={<AccountSettings/>}/>

                <Route path="/abonnement" element={<SubscriptionRequestPage/>}/>
                <Route path="/abonnementen" element={<SubscriptionsManagePage/>}/>
                <Route path="/abonnementen-overzicht" element={<SubscriptionOverviewPage/>}/>

                <Route path="/huur-indienen" element={<RentingSubmitPage/>}/>
                <Route path="/huur-geschiedenis" element={<RentHistory/>}/>
                <Route path="/huuraanvraag-beoordelen" element={<ReviewRentRequest/>}/>
                <Route path="/notificaties" element={<NotificationsPage/>}/>
                <Route path="/bevestiging" element={<ConfirmationPage/>}/>
                <Route path="/huur-betaling" element={<RentingPaymentPage/>}/>

                <Route path="/frontoffice/inname" element={<FrontofficeIntakePage/>}/>
                <Route path="/frontoffice/uitgave" element={<FrontofficeExpenditurePage/>}/>
                <Route path="/reserveringen" element={<ReserveringPage/>}/>
                <Route path="/reservering-wijziging" element={<ReserveringWijzigingPage/>}/>
            </Routes>
        </Router>
    );
}

export default App;
