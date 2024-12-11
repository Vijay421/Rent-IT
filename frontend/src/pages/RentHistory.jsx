import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import RentHistoryItem from "../components/RentHistoryItem.jsx";
import "../styles/RentHistory.css";

export default function RentHistory() {
    const fakeVehicleData = getFakeVehicle();

    return (
        <>
            <Navbar/>

            <main className="rent-history__page">
                <div className="rent-history__filter">
                    <h1 className="rent-history__title">Huurgeschiedenis</h1>

                    <div className="rent-history__filter-vehicle rent-history__filter-item">
                        <label htmlFor="rent-history-vehicle-type" className="rent-history__filter-label">Voertuig</label>
                        <select id="rent-history-vehicle-type">
                            <option value="alles">Alle soorten voertuigen</option>
                            <option value="auto">Auto</option>
                            <option value="camper">Camper</option>
                            <option value="caravan">Caraven</option>
                        </select>
                    </div>

                    <div className="rent-history__filter-retrieve rent-history__filter-item">
                        <label htmlFor="rent-history-retrieve-date" className="rent-history__filter-label">Ophalen</label>
                        <input id="rent-history-retrieve-date" type="date" />
                    </div>

                    <div className="rent-history__filter-hand-in rent-history__filter-item">
                        <label htmlFor="rent-history-hand-in-data" className="rent-history__filter-label">Inleveren</label>
                        <input id="rent-history-hand-in-data" type="date" />
                    </div>
                </div>

                <div className="rent-history__items">
                    {
                        fakeVehicleData.map((data, key) => (
                            <RentHistoryItem data={data} key={key} />
                        ))
                    }
                </div>
            </main>

            <Footer/>
        </>
    );
}

// TODO: remove this function when the backend endpoints are finished.
/**
 * Return an array of fake vehicle objects with predefined attributes.
 *
 * @returns {Array<Object>}
 */
function getFakeVehicle() {
    return [
        {
            id: 1,
            merk: "Toyota",
            type: "Corolla",
            kenteken: "AB-123-CD",
            kleur: "Red",
            aanschafjaar: "2018",
            soort: "Auto",
            opmerking: "",
            status: "Verhuurbaar",
            prijs: 50,
            startdatum: "2012-02-24",
            einddatum: "2016-04-12",
        },
        {
            id: 1,
            merk: "Toyota",
            type: "Corolla",
            kenteken: "AB-123-CD",
            kleur: "Red",
            aanschafjaar: "2018",
            soort: "Auto",
            opmerking: "",
            status: "Verhuurbaar",
            prijs: 50,
            startdatum: "2012-02-24",
            einddatum: "2016-04-12",
        },
        {
            id: 1,
            merk: "Toyota",
            type: "Corolla",
            kenteken: "AB-123-CD",
            kleur: "Red",
            aanschafjaar: "2018",
            soort: "Auto",
            opmerking: "",
            status: "Verhuurbaar",
            prijs: 50,
            startdatum: "2012-02-24",
            einddatum: "2016-04-12",
        },
        {
            id: 1,
            merk: "Toyota",
            type: "Corolla",
            kenteken: "AB-123-CD",
            kleur: "Red",
            aanschafjaar: "2018",
            soort: "Auto",
            opmerking: "",
            status: "Verhuurbaar",
            prijs: 50,
            startdatum: "2012-02-24",
            einddatum: "2016-04-12",
        },
    ];
}
