import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "../pages/LoginPage.jsx";
import RegisterPage from "../pages/RegisterPage.jsx";
import IndexPage from "../pages/IndexPage.jsx";
import RetrievePasswordPage from "../pages/RetrievePasswordPage.jsx";
import RentingPage from "../pages/RentingPage.jsx";
import ProfilePage from "../pages/ProfilePage.jsx";
import {UserProvider} from "./UserContext.jsx";

function App() {
    return (
        <UserProvider>
            <Router>
                <Routes>
                    <Route path="/" element={<IndexPage />} />
                    <Route path="/register" element={<RegisterPage/>} />
                    <Route path="/login" element={<LoginPage/>} />
                    <Route path="/retrievepassword" element={<RetrievePasswordPage/>} />
                    <Route path="/renting" element={<RentingPage/>} />
                    <Route path="/wachtwoord-vergeten" element={<RetrievePasswordPage/>}/>
                    <Route path="/profile" element={<ProfilePage/>}/>
                </Routes>
            </Router>
        </UserProvider>
    );
}

export default App;