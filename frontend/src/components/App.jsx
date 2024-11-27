import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import LoginPage from "../pages/LoginPage.jsx";
import RegisterPage from "../pages/RegisterPage.jsx";
import IndexPage from "../pages/IndexPage.jsx";
import RetrievePasswordPage from "../pages/RetrievePasswordPage.jsx";
import RentingPage from "../pages/RentingPage.jsx";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<IndexPage />} />
                <Route path="/register" element={<RegisterPage/>} />
                <Route path="/login" element={<LoginPage/>} />
            </Routes>
        </Router>
    );
}

export default App;
