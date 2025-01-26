import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";

export default function NotFoundPage() {
    return (
        <>
        <Navbar/>
        <h1 style={{display: "flex", justifyContent: "center", alignItems: "center", height: "50vh", fontSize: "100px"}}>404 - Not found</h1>
        <Footer/>
        </>
    );
}