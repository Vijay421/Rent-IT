import '../styles/Renting.css';
import { useState, useEffect } from "react";
import { RentalAutoBox, RentalCaravanBox, RentalCamperBox } from './RentalVehicleBox.jsx';

function Renting() {
    const [selectedVoertuigSoort, setSelectedVoertuigSoort] = useState("alles");
    const [selectedDateStartDatum, setSelectedDateStartDatum] = useState("");
    const [selectedDateEindDatum, setSelectedDateEindDatum] = useState("");
    const [selectedMerkSoort, setSelectedMerkSoort] = useState("alles");
    const [selectedPrijsSoort, setSelectedPrijsSoort] = useState("alles");
    const [selectedBeschikbaarheidSoort, setSelectedBeschikbaarheidSoort] = useState("alles");
    const [vehicles, setVehicles] = useState([]);
    const [searchText, setSearchText] = useState("");

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

    const handleVoertuigChange = (event) => {
        setSelectedVoertuigSoort(event.target.value);
    };

    const handleDateChangeStartDatum = (event) => {
        const newStartDatum = event.target.value;
        if (selectedDateStartDatum !== "") {
            if (newStartDatum > selectedDateEindDatum) {
                alert("De startdatum kan niet later zijn dan uw einddatum.");
            } else {
                setSelectedDateStartDatum(newStartDatum);
            }
        }
        else {
            setSelectedDateStartDatum(newStartDatum);
        }
    };

    const handleDateChangeEindDatum = (event) => {
        const newEindDatum = event.target.value;
        if (selectedDateStartDatum !== "") {
            if (newEindDatum < selectedDateStartDatum) {
                alert("De einddatum kan niet eerder zijn dan uw startdatum.");
            } else {
                setSelectedDateEindDatum(newEindDatum);
            }
        }
        else {
            setSelectedDateEindDatum(newEindDatum);
        }
    };

    const handleMerkChange = (event) => {
        setSelectedMerkSoort(event.target.value);
    };

    const handlePrijsChange = (event) => {
        setSelectedPrijsSoort(event.target.value);
    };

    const handleBeschikbaarheidChange = (event) => {
        setSelectedBeschikbaarheidSoort(event.target.value);
    };

    const handleSearchFieldChange = (event) => {
        setSearchText(event.target.value);
    };

    function onResetFiltersButtonClick() {
        setSelectedVoertuigSoort("alles");
        setSelectedMerkSoort("alles");
        setSelectedPrijsSoort("alles");
        setSelectedBeschikbaarheidSoort("alles");
        setSelectedDateStartDatum("");
        setSelectedDateEindDatum("");
    }

    const renderVehicleBoxes = () => {
        return vehicles
            .filter((vehicle) => {
                if (selectedVoertuigSoort !== "alles" && vehicle.soort.toLowerCase() !== selectedVoertuigSoort) return false;

                if (selectedMerkSoort !== "alles" && vehicle.merk.toLowerCase() !== selectedMerkSoort) return false;

                if (selectedPrijsSoort !== "alles" && vehicle.prijs > 50 && selectedPrijsSoort === "low") return false;

                if (selectedPrijsSoort !== "alles" && (vehicle.prijs > 100 || vehicle.prijs < 51) && selectedPrijsSoort === "mid") return false;

                if (selectedPrijsSoort !== "alles" && vehicle.prijs < 101 && selectedPrijsSoort === "high") return false;

                if (selectedBeschikbaarheidSoort !== "alles" && vehicle.status !== selectedBeschikbaarheidSoort) return false;

                if (selectedDateStartDatum < vehicle.startDatum || selectedDateEindDatum > vehicle.eindDatum) return false;

                if ( (!vehicle.merk.toLowerCase().includes(searchText.trim().toLowerCase()) &&
                    !vehicle.type.toLowerCase().includes(searchText.trim().toLowerCase()))) return false;

                return true;
            })

            .map((vehicle) => {
                if (vehicle.soort === "Auto") {
                    return <RentalAutoBox key={vehicle.id} data={vehicle} nieuwStartDatum={selectedDateStartDatum} nieuwEindDatum={selectedDateEindDatum}/>;
                }
                else if (vehicle.soort === "Caravan") {
                    return <RentalCaravanBox key={vehicle.id} data={vehicle} nieuwStartDatum={selectedDateStartDatum} nieuwEindDatum={selectedDateEindDatum}/>;
                }
                else if (vehicle.soort === "Camper") {
                    return <RentalCamperBox key={vehicle.id} data={vehicle} nieuwStartDatum={selectedDateStartDatum} nieuwEindDatum={selectedDateEindDatum}/>;
                }
            });
    };

    return (
        <div className="content">
            <div className="divTop">
                <p className="divTop-header-Text-Huren">Filters</p>

                <div className="rowDivs">
                    <div className="divTop-divSelect-Voertuig">
                        <div className="divTop-divSelect-Voertuig-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Voertuig: </label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-voertuig-dropdown"
                                value={selectedVoertuigSoort} // Controlled component
                                onChange={handleVoertuigChange} // Event handler
                            >
                                <option value="alles">Alles</option>
                                <option value="auto">Auto</option>
                                <option value="camper">Camper</option>
                                <option value="caravan">Caravan</option>
                            </select>
                        </div>
                    </div>

                    <div className="divTop-divSelect-ophaalDatum">
                        <div className="divTop-divSelect-ophaalDatum-datePicker-container">
                            <label htmlFor="date-picker" className="date-label-ophaalDatum">Startdatum: </label>
                            <input
                                type="date"
                                id="date-picker"
                                className="date-input"
                                value={selectedDateStartDatum}
                                onChange={handleDateChangeStartDatum}
                            />
                        </div>
                    </div>

                    <div className="divTop-divSelect-inleverDatum">
                        <div className="divTop-divSelect-inleverDatum-datePicker-container">
                            <label htmlFor="date-picker" className="date-label-inleverDatum">Einddatum: </label>
                            <input
                                type="date"
                                id="date-picker"
                                className="date-input"
                                value={selectedDateEindDatum}
                                onChange={handleDateChangeEindDatum}
                            />
                        </div>
                    </div>
                </div>

                <div className="rowDivs2">
                    <div className="divTop-divSelect-Merk">
                        <div className="divTop-divSelect-Merk-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Merk: </label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-merk-dropdown"
                                value={selectedMerkSoort}
                                onChange={handleMerkChange}
                            >
                                <option value="alles">Alles</option>
                                <option value="toyota">Toyota</option>
                                <option value="ford">Ford</option>
                                <option value="volkswagen">Volkswagen</option>
                                <option value="honda">Honda</option>
                                <option value="bmw">BMW</option>
                                <option value="audi">Audi</option>
                                <option value="mercedes">Mercedes</option>
                                <option value="nissan">Nissan</option>
                                <option value="peugeot">Peugeot</option>
                                <option value="renault">Renault</option>
                            </select>
                        </div>
                    </div>

                    <div className="divTop-divSelect-Prijs">
                        <div className="divTop-divSelect-Prijs-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Prijs: </label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-prijs-dropdown"
                                value={selectedPrijsSoort}
                                onChange={handlePrijsChange}
                            >
                                <option value="alles">Alles</option>
                                <option value="low">0-50</option>
                                <option value="mid">51-100</option>
                                <option value="high">101+</option>
                            </select>
                        </div>
                    </div>

                    <div className="divTop-divSelect-Beschikbaarheid">
                        <div className="divTop-divSelect-Beschikbaarheid-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Beschikbaarheid: </label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-beschikbaarheid-dropdown"
                                value={selectedBeschikbaarheidSoort}
                                onChange={handleBeschikbaarheidChange}
                            >
                                <option value="alles">Alles</option>
                                <option value="Verhuurbaar">Beschikbaar</option>
                                <option value="Onverhuurbaar">Onbeschikbaar</option>
                            </select>
                        </div>
                    </div>
                </div>

                <div className="rowDivs3">
                    <div className="divTop-search-bar-container">
                        <input className="divTop-search-bar__input" type="search" value={searchText} onChange={handleSearchFieldChange} placeholder='Search bar'/>
                        <button className='divTop-reset-filters__button' onClick={onResetFiltersButtonClick}>Reset filters</button>
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
