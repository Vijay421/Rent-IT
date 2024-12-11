import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import RentHistoryItem from "../components/RentHistoryItem.jsx";
import "../styles/RentHistory.css";

export default function RentHistory() {
    return (
        <>
            <Navbar/>

            <main className="rent-history__page">
                <div className="rent-history__filter">
                    <h1 className="rent-history__title">Huurgeschiedenis</h1>
                </div>

                <div className="rent-history__items">
                    <RentHistoryItem />
                </div>
            </main>

            <Footer/>
        </>
    );
}
