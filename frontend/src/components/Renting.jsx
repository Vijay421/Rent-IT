import '../styles/Renting.css';
import {useState, useEffect, useContext} from "react";
import { RentalAutoBox, RentalCaravanBox, RentalCamperBox } from './RentalVehicleBox.jsx';
import {UserContext} from "./UserContext.jsx";

function Renting() {
    const { userRole } = useContext(UserContext);

    const [selectedVoertuigSoort, setSelectedVoertuigSoort] = useState("alles");
    const [selectedDateStartDatum, setSelectedDateStartDatum] = useState("");
    const [selectedDateEindDatum, setSelectedDateEindDatum] = useState("");
    const [selectedMerkSoort, setSelectedMerkSoort] = useState("alles");
    const [selectedPrijsSoort, setSelectedPrijsSoort] = useState("alles");
    const [selectedBeschikbaarheidSoort, setSelectedBeschikbaarheidSoort] = useState("Verhuurbaar");
    const [selectedSorterenSoort, setSelectedSorterenSoort] = useState("geen");
    const [vehicles, setVehicles] = useState([]);
    const [searchText, setSearchText] = useState("");

    useEffect(() => {
        fetchVehicles();
    }, []);

    const handleVoertuigChange = (event) => {
        setSelectedVoertuigSoort(event.target.value);
    };

    const handleDateChangeStartDatum = (event) => {
        const newStartDatum = event.target.value;
        if (selectedDateStartDatum !== "") {
            if (newStartDatum >= selectedDateEindDatum) {
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
            if (newEindDatum <= selectedDateStartDatum) {
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

    const handleSorterenChange = (event) => {
        setSelectedSorterenSoort(event.target.value);
    };

    function onResetFiltersButtonClick() {
        setSelectedVoertuigSoort("alles");
        setSelectedMerkSoort("alles");
        setSelectedPrijsSoort("alles");
        setSelectedBeschikbaarheidSoort("Verhuurbaar");
        setSelectedDateStartDatum("");
        setSelectedDateEindDatum("");
        setSelectedSorterenSoort("geen");
        setSearchText("");
    }

    const filteredVehicles = vehicles.filter((vehicle) => {
        if (selectedVoertuigSoort !== "alles" && vehicle.soort.toLowerCase() !== selectedVoertuigSoort) return false;
        if (selectedMerkSoort !== "alles" && vehicle.merk.toLowerCase() !== selectedMerkSoort) return false;
        if (selectedPrijsSoort !== "alles" && vehicle.prijs > 50 && selectedPrijsSoort === "low") return false;
        if (selectedPrijsSoort !== "alles" && (vehicle.prijs > 100 || vehicle.prijs < 51) && selectedPrijsSoort === "mid") return false;
        if (selectedPrijsSoort !== "alles" && vehicle.prijs < 101 && selectedPrijsSoort === "high") return false;
        if (selectedBeschikbaarheidSoort !== "alles" && vehicle.status !== selectedBeschikbaarheidSoort) return false;
        if (vehicle.status === "Geblokkeerd") return false;
        if (selectedDateStartDatum && selectedDateStartDatum < vehicle.startDatum) return false;
        if (selectedDateEindDatum && selectedDateEindDatum > vehicle.eindDatum) return false;
        if (
            !vehicle.merk.toLowerCase().includes(searchText.trim().toLowerCase()) &&
            !vehicle.type.toLowerCase().includes(searchText.trim().toLowerCase())
        )
            return false;
        return true;
    });

    const sortedVehicles = filteredVehicles.sort((a, b) => {
        if (selectedSorterenSoort === "oplopend") return a.prijs - b.prijs;
        if (selectedSorterenSoort === "aflopend") return b.prijs - a.prijs;
        return 0;
    });

    async function fetchVehicles() {
        try {
            const response = await fetch('https://localhost:53085/api/Voertuig', {
                method: 'GET',

                // TODO: change to 'same-origin' when in production.
                credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                headers: {
                    'content-type': 'application/json'
                },
            });
            const data = await response.json();
            setVehicles(data);
            console.log(userRole);
        }
        catch (e) {
            console.error(e);
        }
    }

    return (
        <div className="content">
            <div className="divTop">
                <h1 className="divTop-header-Text-Huren">Filters</h1>

                <div className="rowDivs">
                    <div className="divTop-divSelect-Voertuig">
                        <div className="divTop-divSelect-Voertuig-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Voertuig:</label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-voertuig-dropdown"
                                value={selectedVoertuigSoort} // Controlled component
                                onChange={handleVoertuigChange} // Event handler
                                data-cy="kind-filter"
                            >
                                {userRole !== "zakelijke_huurder" ? (
                                    <>
                                        <option value="alles">Alles</option>
                                        <option value="auto">Auto</option>
                                        <option value="caravan">Caravan</option>
                                        <option value="camper">Camper</option>
                                    </>
                                ) : (
                                    <>
                                        <option value="auto">Auto</option>
                                    </>
                                )}
                            </select>
                        </div>
                    </div>

                    <div className="divTop-divSelect-ophaalDatum">
                        <div className="divTop-divSelect-ophaalDatum-datePicker-container">
                            <label htmlFor="date-picker-start" className="date-label-ophaalDatum">Startdatum:</label>
                            <input
                            type="date"
                            id="date-picker-start"
                            className="date-input"
                            value={selectedDateStartDatum}
                            onChange={handleDateChangeStartDatum}
                        />
                        </div>
                    </div>

                    <div className="divTop-divSelect-inleverDatum">
                        <div className="divTop-divSelect-inleverDatum-datePicker-container">
                            <label htmlFor="date-picker-end" className="date-label-inleverDatum">Einddatum:</label>
                            <input
                                type="date"
                                id="date-picker-end"
                                className="date-input"
                                value={selectedDateEindDatum}
                                onChange={handleDateChangeEindDatum}
                            />
                        </div>
                    </div>

                    <div className="divTop-divSelect-Merk">
                        <div className="divTop-divSelect-Merk-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Merk:</label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-merk-dropdown"
                                value={selectedMerkSoort}
                                onChange={handleMerkChange}
                                data-cy="brand-filter"
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
                            <label htmlFor="options" className="dropdown-label">Prijs:</label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-prijs-dropdown"
                                value={selectedPrijsSoort}
                                onChange={handlePrijsChange}
                                data-cy="price-filter"
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
                            <label htmlFor="options" className="dropdown-label">Status:</label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-beschikbaarheid-dropdown"
                                value={selectedBeschikbaarheidSoort}
                                onChange={handleBeschikbaarheidChange}
                                data-cy="availability-filter"
                            >
                                <option value="Verhuurbaar">Beschikbaar</option>
                                <option value="alles">Alles</option>
                                <option value="Onverhuurbaar">Onbeschikbaar</option>
                            </select>
                        </div>
                    </div>
                    <div className="divTop-search-bar-container">
                        <input className="divTop-search-bar__input" type="search" value={searchText} onChange={handleSearchFieldChange} placeholder='Search bar' data-cy="search-bar" />

                        <div className="divTop-divSelect-Sorteren-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Sorteren:</label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-sorteren-dropdown"
                                value={selectedSorterenSoort}
                                onChange={handleSorterenChange}
                                data-cy="sort-filter"
                            >
                                <option value="geen">Geen</option>
                                <option value="oplopend">Oplopend</option>
                                <option value="aflopend">Aflopend</option>
                            </select>
                        </div>

                        <button className='divTop-reset-filters__button' data-cy="reset-button" onClick={onResetFiltersButtonClick}>Reset
                            filters
                        </button>
                </div>
                </div>
            </div>

            <div className="divMargin"></div>
            <div className="divMain">
                {sortedVehicles.length === 0 ? (
                    <span id="divMain-no-content__span" data-cy="no-vehicles-text">
                Selecteer hierboven een startdatum en einddatum. Als er een voertuig beschikbaar is, wordt dit hier weergegeven.
            </span>
                ) : userRole !== "zakelijke_huurder" ? (
                    sortedVehicles.map((vehicle) => {
                        if (vehicle.soort === "Auto") {
                            return (
                                <RentalAutoBox
                                    key={vehicle.id}
                                    data={vehicle}
                                    nieuwStartDatum={selectedDateStartDatum}
                                    nieuwEindDatum={selectedDateEindDatum}
                                />
                            );
                        } else if (vehicle.soort === "Caravan") {
                            return (
                                <RentalCaravanBox
                                    key={vehicle.id}
                                    data={vehicle}
                                    nieuwStartDatum={selectedDateStartDatum}
                                    nieuwEindDatum={selectedDateEindDatum}
                                />
                            );
                        } else if (vehicle.soort === "Camper") {
                            return (
                                <RentalCamperBox
                                    key={vehicle.id}
                                    data={vehicle}
                                    nieuwStartDatum={selectedDateStartDatum}
                                    nieuwEindDatum={selectedDateEindDatum}
                                />
                            );
                        }
                    })
                ) :
                    sortedVehicles.map((vehicle) => {
                        if (vehicle.soort === "Auto") {
                            return (
                                <RentalAutoBox
                                    key={vehicle.id}
                                    data={vehicle}
                                    nieuwStartDatum={selectedDateStartDatum}
                                    nieuwEindDatum={selectedDateEindDatum}
                                />
                            );
                        }
                    })}
            </div>
        </div>
    );
}

export default Renting;
