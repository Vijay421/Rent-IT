import { useState, useRef, useEffect } from "react";
import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import RentHistoryItem from "../components/RentHistoryItem.jsx";
import "../styles/RentHistory.css";
import downloadFile from "../scripts/downloadFile.js";

export default function RentHistory() {
    const [vehicleType, setVehicleType] = useState("");
    const [retrieveDate, setRetrieveDate] = useState("");
    const [handInDate, setHandInDate] = useState("");
    const selectvehicleType = useRef(null);
    const [vehicles, setVehicles] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const vehicles = await getRentHistory();
            setVehicles(vehicles);
        };
        getData();
    }, []);

    const filteredVehicles = vehicles
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

    // The folloing code got inspired by: https://stackoverflow.com/questions/3665115/how-to-create-a-file-in-memory-for-user-to-download-but-not-through-server
    // The stackoverflow answer: An example for IE 10+, Firefox and Chrome (and without jQuery or any other library)
    /**
     * Allow the user to download a json export of the filtered vehicles.
     */
    function download() {
        if (filteredVehicles.length === 0) {
            window.alert("Geen voertuigen om te downloaden!");
            return;
        }

        const contents = JSON.stringify(filteredVehicles);
        downloadFile(contents, "voertuigen.json", "text/json");
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

        const shouldFilter = vehicleStartDate >= filterStart && vehicleEndDate <= filterEnd;
        return shouldFilter;
    }

    return true;
}

/**
 * Will attempt to get the rent history from the server.
 * 
 * @returns {Object}
 */
async function getRentHistory() {
    try {
        const response = await fetch('https://localhost:53085/api/User/rent-history', {
            method: 'GET',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
        });

        return await response.json();
    } catch (error) {
        console.error('error when requesting the rent history request, or parsing the response:', error);
        throw error;
    }
}
