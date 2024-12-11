import { useState, useRef } from "react";
import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import RentHistoryItem from "../components/RentHistoryItem.jsx";
import "../styles/RentHistory.css";

export default function RentHistory() {
    const vehicleData = getFakeVehicle();
    const [vehicleType, setVehicleType] = useState("");
    const [retrieveDate, setRetrieveDate] = useState("");
    const [handInDate, setHandInDate] = useState("");
    const selectvehicleType = useRef(null);

    const filteredVehicles = vehicleData
        .filter((data) => filterVehicle(data, vehicleType, retrieveDate, handInDate));

    function handleVehicleType(e) {
        setVehicleType(e.target.value);
    }

    function handleRetrieveDate(e) {
        const filterStart = new Date(e.target.value);
        const filterEnd = new Date(handInDate);

        if (filterStart > filterEnd) {
            window.alert("De ophaaldatum moet eerder zijn dan de inleverdatum");
        } else {
            setRetrieveDate(e.target.value);
        }
    }

    function handleHandInDate(e) {
        const filterStart = new Date(retrieveDate);
        const filterEnd = new Date(e.target.value);

        if (filterStart > filterEnd) {
            window.alert("De ophaaldatum moet eerder zijn dan de inleverdatum");
        } else {
            setHandInDate(e.target.value);
        }
    }

    function resetFilters() {
        setVehicleType("alles");
        setRetrieveDate("");
        setHandInDate("");
        selectvehicleType.current.selectedIndex = 0;
    }

    // TODO: put this in the arch-doc.
    // The folloing code got inspired by: https://stackoverflow.com/questions/3665115/how-to-create-a-file-in-memory-for-user-to-download-but-not-through-server
    // The stackoverflow anwser: An example for IE 10+, Firefox and Chrome (and without jQuery or any other library)
    /**
     * Allow the user to download a json export of the filtered vehicles.
     */
    function download() {
        if (filteredVehicles.length === 0) {
            window.alert("Geen voertuigen om te downloaden!");
            return;
        }

        const contents = JSON.stringify(filteredVehicles);
        const blob = new Blob([contents], { type: "text/json" });
        const link = document.createElement("a");

        link.href = URL.createObjectURL(blob);
        link.download = "voertuigen.json";
        link.click();
    }

    return (
        <>
            <Navbar/>

            <main className="rent-history__page">

                <div className="rent-history__filter">
                    <h1 className="rent-history__title">Huurgeschiedenis</h1>

                    <div className="rent-history__filter-vehicle rent-history__filter-item">
                        <label htmlFor="rent-history-vehicle-type" className="rent-history__filter-label">Voertuig</label>
                        <select ref={selectvehicleType} id="rent-history-vehicle-type" onChange={handleVehicleType}>
                            <option value="alles">Alle soorten voertuigen</option>
                            <option value="auto">Auto</option>
                            <option value="camper">Camper</option>
                            <option value="caravan">Caraven</option>
                        </select>
                    </div>

                    <div className="rent-history__filter-retrieve rent-history__filter-item">
                        <label htmlFor="rent-history-retrieve-date" className="rent-history__filter-label">Ophalen</label>
                        <input id="rent-history-retrieve-date" type="date" onChange={handleRetrieveDate} value={retrieveDate}/>
                    </div>

                    <div className="rent-history__filter-hand-in rent-history__filter-item">
                        <label htmlFor="rent-history-hand-in-data" className="rent-history__filter-label">Inleveren</label>
                        <input id="rent-history-hand-in-data" type="date" onChange={handleHandInDate} value={handInDate}/>
                    </div>


                    <button className="rent-history__filter-reset" onClick={resetFilters}>Reset</button>
                    <button className="rent-history__filter-download" onClick={download}>Download</button>
                </div>

                <div className="rent-history__items">
                    { filteredVehicles.length === 0 ? <p className="rent-history__empty">Geen voertuigen</p> : (
                        filteredVehicles.map((data, key) => (
                            <RentHistoryItem data={data} key={key} />
                        ))
                    ) }
                </div>

            </main>

            <Footer/>
        </>
    );
}

/**
 * Filters vehicles based on the given parameters.
 * 
 * @param {Object} vehicle 
 * @param {string} vehicleType 
 * @param {string} retrieveDate 
 * @param {string} handInDate 
 * @returns {boolean}
 */
function filterVehicle(vehicle, vehicleType, retrieveDate, handInDate) {
    if (vehicleType !== "") {
        if (vehicle.soort.toLowerCase() !== vehicleType && vehicleType !== "alles") {
            return false;
        }
    }

    if (retrieveDate !== "" && handInDate !== "") {
        const vehicleStartDate = new Date(vehicle.startdatum);
        const vehicleEndDate = new Date(vehicle.einddatum);

        const filterStart = new Date(retrieveDate);
        const filterEnd = new Date(handInDate);

        return filterStart <= vehicleStartDate && filterEnd >= vehicleEndDate;
    }

    return true;
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
            id: 2,
            merk: "Toyota",
            type: "Corolla",
            kenteken: "AB-123-CD",
            kleur: "Red",
            aanschafjaar: "2018",
            soort: "Camper",
            opmerking: "",
            status: "Verhuurbaar",
            prijs: 50,
            startdatum: "2011-01-01",
            einddatum: "2016-01-01",
        },
        {
            id: 3,
            merk: "Toyota",
            type: "Corolla",
            kenteken: "AB-123-CD",
            kleur: "Red",
            aanschafjaar: "2018",
            soort: "Caravan",
            opmerking: "",
            status: "Verhuurbaar",
            prijs: 50,
            startdatum: "2012-02-24",
            einddatum: "2016-04-12",
        },
        {
            id: 4,
            merk: "Toyota",
            type: "Corolla",
            kenteken: "AB-123-CD",
            kleur: "Red",
            aanschafjaar: "2018",
            soort: "Auto",
            opmerking: "",
            status: "Verhuurbaar",
            prijs: 50,
            startdatum: "2022-01-01",
            einddatum: "2024-01-01",
        },
    ];
}
