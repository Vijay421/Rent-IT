import '../styles/Renting.css';
import { useState, useEffect } from "react";
import { RentalAutoBox, RentalCaravanBox, RentalCamperBox } from './RentalVehicleBox.jsx';

function Renting() {
    const [selectedOptionVoertuigSoort, setSelectedOptionVoertuigSoort] = useState("alles"); // Selecteer Voertuig soort
    const [selectedDateOphaalDatum, setSelectedDateOphaalDatum] = useState(""); // Selecteer OphaalDatum
    const [selectedDateInleverDatum, setSelectedDateInleverDatum] = useState(""); // Selecteer InleverDatum
    const [vehicles, setVehicles] = useState([]);

    useEffect(() => {
        async function fetchVehicles() {
            try {
                const response = await fetch('https://localhost:53085/api/Voertuig');
                const data = await response.json();
                setVehicles(data);
            }
            catch (e) {
                console.error(e);
            }
        }
        fetchVehicles();
    }, []);

    const handleSelectChange = (event) => {
        setSelectedOptionVoertuigSoort(event.target.value);
        console.log("Selected value:", event.target.value);
    };

    const handleDateChangeOphaalDatum = (event) => {
        setSelectedDateOphaalDatum(event.target.value);
        console.log("Selected date:", event.target.value);
    };

    const handleDateChangeInleverDatum = (event) => {
        setSelectedDateInleverDatum(event.target.value);
        console.log("Selected date:", event.target.value);
    };

    const renderVehicleBoxes = () => {
        return vehicles.map((vehicle) => {
            if (selectedOptionVoertuigSoort === "alles") {
                if (vehicle.soort === "Auto") {
                    return <RentalAutoBox key={vehicle.id} data={vehicle} />;
                }
                else if (vehicle.soort === "Caravan") {
                    return <RentalCaravanBox key={vehicle.id} data={vehicle} />;
                }
                else if (vehicle.soort === "Camper") {
                    return <RentalCamperBox key={vehicle.id} data={vehicle} />;
                }
            }

            else if (selectedOptionVoertuigSoort === "auto") {
                if (vehicle.soort === "Auto") {
                    return <RentalAutoBox key={vehicle.id} data={vehicle} />;
                }
            }

            else if (selectedOptionVoertuigSoort === "caravan") {
                if (vehicle.soort === "Caravan") {
                    return <RentalCaravanBox key={vehicle.id} data={vehicle} />;
                }
            }

            else if (selectedOptionVoertuigSoort === "camper") {
                if (vehicle.soort === "Camper") {
                    return <RentalCamperBox key={vehicle.id} data={vehicle} />;
                }
            }
        });
    };

    return (
        <div className="content">
            <div className="divTop">
                <div className="divTop-header">
                    <p className="divTop-header-Text-Huren">Auto huren</p>
                </div>

                <div className="rowDivs">
                    <div className="divTop-divSelect-Voertuig">
                        <div className="divTop-divSelect-Voertuig-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Voertuig: </label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-voertuig-dropdown"
                                value={selectedOptionVoertuigSoort} // Controlled component
                                onChange={handleSelectChange} // Event handler
                            >
                                <option value="alles">Alle soorten voertuigen</option>
                                <option value="auto">Auto</option>
                                <option value="camper">Camper</option>
                                <option value="caravan">Caravan</option>
                            </select>
                        </div>
                    </div>

                    <div className="divTop-divSelect-ophaalDatum">
                        <div className="divTop-divSelect-ophaalDatum-datePicker-container">
                            <label htmlFor="date-picker" className="date-label-ophaalDatum">Ophaal datum: </label>
                            <input
                                type="date"
                                id="date-picker"
                                className="date-input"
                                value={selectedDateOphaalDatum}
                                onChange={handleDateChangeOphaalDatum}
                            />
                        </div>
                    </div>

                    <div className="divTop-divSelect-inleverDatum">
                        <div className="divTop-divSelect-inleverDatum-datePicker-container">
                            <label htmlFor="date-picker" className="date-label-inleverDatum">Inlever datum: </label>
                            <input
                                type="date"
                                id="date-picker"
                                className="date-input"
                                value={selectedDateInleverDatum}
                                onChange={handleDateChangeInleverDatum}
                            />
                        </div>
                    </div>
                    <div     className="divTop-search-bar-container">
                        <input type="search" placeholder='Search bar'/>
                    </div>
                    <div className="divTop-search-button-container">
                        <button>sadsd</button>
                    </div>
                </div>
            </div>

            <div className="divMargin"></div>
            <div className="divMain">
                {renderVehicleBoxes()}
            </div>
        </div>
    );
}

export default Renting;