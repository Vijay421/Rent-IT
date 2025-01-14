import '../styles/VerhuurdeVoertuig.css';
import {useEffect, useState} from "react";
import {DisplayAutoBox, DisplayCamperBox, DisplayCaravanBox} from "./DisplayVehicleBox.jsx";

export default function VerhuurdeVoertuig() {
    const [vehicles, setVehicles] = useState([]);
    const [huurder, setHuurder] = useState("Alles");
    const [voertuigType, setVoertuigType] = useState("Alles");
    const [ophaalDatum, setOphaalDatum] = useState("");
    const [inleverDatum, setInleverDatum] = useState("");
    const renters = [...new Set(vehicles.map(vehicle => vehicle.wettelijke_naam))];

    const filteredVehicles = vehicles.filter((vehicle) => {
        if (vehicle.voertuig.status !== "Onverhuurbaar") return false;
        if (huurder !== "Alles" && vehicle.wettelijke_naam !== huurder) return false;

        if (voertuigType !== "Alles" && vehicle.voertuig.soort !== voertuigType) return false;

        const startDate = ophaalDatum ? new Date(ophaalDatum) : null;
        const endDate = inleverDatum ? new Date(inleverDatum) : null;
        const rentalStartDate = new Date(vehicle.voertuig.startDatum);
        const rentalEndDate = new Date(vehicle.voertuig.eindDatum);

        if (startDate && startDate > rentalStartDate) return false;
        if (endDate && endDate < rentalEndDate) return false;

        return true;
    });


    useEffect(() => {
        const getData = async () => {
            const fetchData = await fetchVehicles();
            setVehicles(fetchData);
        };
        getData();

        //Fetch interval - 5 seconds
        const intervalId = setInterval(() => {
            getData();
        }, 5000);

        return () => clearInterval(intervalId);
    }, []);

    async function fetchVehicles() {
        try {
            const response = await fetch('https://localhost:53085/api/Huur/all', {
                method: 'GET',

                // TODO: change to 'same-origin' when in production.
                credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                headers: {
                    'content-type': 'application/json'
                },
            });

            return await response.json();
        } catch (error) {
            console.error('error when requesting the vehicles, or parsing the response:', error);
            throw error;
        }
    }

    const downloadCSV = () => { //modified ChatGPT code
        const headers = ['Merk', 'Type', 'Kenteken', 'Kleur', 'Aanschafjaar', 'Soort', 'Status','Wettelijke_naam', 'Start Datum', 'Eind Datum'];
        const rows = filteredVehicles.map(vehicle => [
            vehicle.voertuig?.merk,
            vehicle.voertuig?.type,
            vehicle.voertuig?.kenteken,
            vehicle.voertuig?.kleur,
            vehicle.voertuig?.aanschafjaar,
            vehicle.voertuig?.soort,
            vehicle.voertuig?.status,
            vehicle.wettelijke_naam,
            vehicle.voertuig.startDatum,
            vehicle.voertuig.eindDatum,
        ]);

        const csvContent = [
            headers.join(','),
            ...rows.map(row => row.join(',')),
        ].join('\n');

        const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });

        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = 'verhuurde_voertuigen.csv';
        link.click();
    };

    const handleOphaalDatumChange = (e) => {
        const newStartDate = e.target.value;
        if (inleverDatum && new Date(newStartDate) > new Date(inleverDatum)) {
            alert("Startperiode kan niet groter zijn dan de eindperiode.");
            e.target.value = ophaalDatum;
        } else {
            setOphaalDatum(newStartDate);
        }
    };

    const handleInleverDatumChange = (e) => {
        const newEndDate = e.target.value;
        if (ophaalDatum && new Date(newEndDate) < new Date(ophaalDatum)) {
            alert("Eindperiode kan niet lager zijn dan de startperiode.");
            e.target.value = inleverDatum;
        } else {
            setInleverDatum(newEndDate);
        }
    };

    return (
        <main className='verhuurde-pagina__main'>
            <h1 className='verhuurde-pagina-title__h1'>Verhuurde voertuigen</h1>
            <div className='verhuurde-filter-box__div'>
                <div className="verhuurde-filter-ophaaldatum__div">
                    <label htmlFor="verhuurde-ophaaldatum__input">Startperiode:</label>
                    <input
                        type='date'
                        id='verhuurde-ophaaldatum__input'
                        className='verhuurde-dates-class'
                        onChange={handleOphaalDatumChange}
                    />
                </div>

                <div className="verhuurde-filter-inleverdatum__div">
                    <label htmlFor="verhuurde-inleverdatum__input">Eindperiode:</label>
                    <input
                        type='date'
                        id='verhuurde-inleverdatum__input'
                        className='verhuurde-dates-class'
                        onChange={handleInleverDatumChange}
                    />
                </div>

                <div className="verhuurde-filter-huurder__div">
                    <label htmlFor="verhuurde-huurder__select">Huurder:</label>
                    <select
                        id='verhuurde-huurder__select'
                        className='verhuurde-filters-class'
                        value={huurder}
                        onChange={(e) => setHuurder(e.target.value)}
                    >
                        <option value="Alles">Alles</option>
                        {renters.map(renter => (
                            <option key={renter} value={renter}>
                                {renter}
                            </option>
                        ))}
                    </select>
                </div>

                <div className="verhuurde-filter-voertuigtype__div">
                    <label htmlFor="verhuurde-voertuigtype__select">Voertuig type:</label>
                    <select
                        id='verhuurde-voertuigtype__select'
                        className='verhuurde-filters-class'
                        value={voertuigType}
                        onChange={(e) => setVoertuigType(e.target.value)}
                    >
                        <option value="Alles">Alles</option>
                        <option value="Auto">Auto</option>
                        <option value="Camper">Camper</option>
                        <option value="Caravan">Caravan</option>
                    </select>
                </div>

                <div className="verhuurde-filter-download-button__div">
                    <button id="verhuurde-download_button" onClick={downloadCSV}>Download gegevens</button>
                </div>

                <div className="verhuurde-filter-reset-filters__div">
                    <button
                        id="verhuurde-reset-filters__button"
                        onClick={() => {
                            setHuurder("Alles");
                            setVoertuigType("Alles");
                            setOphaalDatum("");
                            setInleverDatum("");
                        }}
                    >
                        Reset filters
                    </button>
                </div>
            </div>

            <div className="verhuurde-voertuig-box__div">
                {
                    filteredVehicles
                        .map((vehicle) => {
                            const voertuig = vehicle.voertuig;

                            if (voertuig.soort === "Auto") {
                                return (
                                    <div className="vehicleAutoBox" key={voertuig.id} data-cy="vehicle">
                                        <DisplayAutoBox data={voertuig} huurButtonStatus={false} onHuur={() => {
                                        }}/>
                                        <div className='verhuurde-voertuig-box-huurinformatie__div'>
                                            <p className="verhuurde-voertuig-box-huurperiode">
                                                <b>Huurperiode:</b> {voertuig.startDatum} - {voertuig.eindDatum}
                                            </p>
                                            <p className="verhuurde-voertuig-box-huurder">
                                                <b>Huurder:</b> {vehicle.wettelijke_naam}
                                            </p>
                                        </div>
                                    </div>
                                );
                            }

                            if (voertuig.soort === "Camper") {
                                return (
                                    <div className="vehicleCamperBox" key={voertuig.id} data-cy="vehicle">
                                        <DisplayCamperBox data={voertuig} huurButtonStatus={false} onHuur={() => {
                                        }}/>
                                        <div className='verhuurde-voertuig-box-huurinformatie__div'>
                                            <p className="verhuurde-voertuig-box-huurperiode">
                                                <b>Huurperiode:</b> {voertuig.startDatum} - {voertuig.eindDatum}
                                            </p>
                                            <p className="verhuurde-voertuig-box-huurder">
                                                <b>Huurder:</b> {vehicle.wettelijke_naam}
                                            </p>
                                        </div>
                                    </div>
                                );
                            }

                            if (voertuig.soort === "Caravan") {
                                return (
                                    <div className="vehicleCaravanBox" key={voertuig.id} data-cy="vehicle">
                                        <DisplayCaravanBox data={voertuig} huurButtonStatus={false} onHuur={() => {
                                        }}/>
                                        <div className='verhuurde-voertuig-box-huurinformatie__div'>
                                            <p className="verhuurde-voertuig-box-huurperiode">
                                                <b>Huurperiode:</b> {voertuig.startDatum} - {voertuig.eindDatum}
                                            </p>
                                            <p className="verhuurde-voertuig-box-huurder">
                                                <b>Huurder:</b> {vehicle.wettelijke_naam}
                                            </p>
                                        </div>
                                    </div>
                                );
                            }

                            return null;
                        })
                }
            </div>

        </main>
    );
}

