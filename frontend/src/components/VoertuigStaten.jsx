import '../styles/VoertuigStaten.css';
import { useEffect, useState } from "react";

export default function VoertuigStaten() {
    const [data, setData] = useState([]);
    const [staat, setStaat] = useState("Alles");
    const [ophaalDatum, setOphaalDatum] = useState("");
    const [inleverDatum, setInleverDatum] = useState("");

    async function fetchVehicles() {
        try {
            const response = await fetch('https://localhost:53085/api/Voertuig', {
                method: 'GET',
                credentials: 'include',
                headers: {
                    'content-type': 'application/json'
                },
            });

            return await response.json();
        } catch (error) {
            console.error('Error when requesting the vehicles or parsing the response:', error);
            throw error;
        }
    }

    useEffect(() => {
        const getData = async () => {
            const fetchData = await fetchVehicles();
            setData(fetchData);
        };
        getData();

        //Fetch interval - 5 seconds
        const intervalId = setInterval(() => {
            getData();
        }, 5000);

        return () => clearInterval(intervalId);
    }, []);

    const filteredData = data.filter(item => {
        if (staat !== "Alles" && item.status !== staat) return false;

        const startDate = ophaalDatum ? new Date(ophaalDatum) : null;
        const endDate = inleverDatum ? new Date(inleverDatum) : null;
        const rentalStartDate = new Date(item.startDatum);
        const rentalEndDate = new Date(item.eindDatum);

        if (startDate && startDate > rentalStartDate) return false;
        if (endDate && endDate < rentalEndDate) return false;
        return true;
    });

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

    function onResetFiltersButtonClick() {
        setOphaalDatum("");
        setInleverDatum("");
        setStaat("Alles");
    }

    return (
        <main className='voertuig-staten-page__main'>
            <h1 className='staten-pagina-title__h1'>Voertuig staten</h1>
            <div className='staten-filter-box__div'>
                <div className="staten-filter-ophaaldatum__div">
                    <label htmlFor="staten-ophaaldatum__input">Startperiode:</label>
                    <input
                        type='date'
                        id='staten-ophaaldatum__input'
                        className='verhuurde-dates-class'
                        onChange={handleOphaalDatumChange}
                    />
                </div>

                <div className="staten-filter-inleverdatum__div">
                    <label htmlFor="staten-inleverdatum__input">Eindperiode:</label>
                    <input
                        type='date'
                        id='staten-inleverdatum__input'
                        className='staten-dates-class'
                        onChange={handleInleverDatumChange}
                    />
                </div>

                <div className="staten-filter-voertuig-staat__div">
                    <label htmlFor="staten-voertuig-staat__select">Huurder:</label>
                    <select
                        id='staten-voertuig-staat__select'
                        className='staten-filters-class'
                        value={staat}
                        onChange={(e) => setStaat(e.target.value)}
                    >
                        <option value="Alles">Alles</option>
                        <option value="Verhuurbaar">Verhuurbaar</option>
                        <option value="Onverhuurbaar">Verhuurd</option>
                        <option value="Reparatie">In reparatie</option>
                        <option value="Geblokkeerd">Geblokkeerd</option>
                    </select>
                </div>

                <div className="staten-filter-reset-filters__div">
                    <button
                        id="staten-reset-filters__button"
                        onClick={onResetFiltersButtonClick}
                    >
                        Reset filters
                    </button>
                </div>
            </div>

            <div id="staten-voertuig-box__div">
                {filteredData.length > 0 ? (
                    filteredData.map((item, index) => (
                        <div key={index} className="staten-voertuig__div">
                            <div className="staten-voertuig-data">
                                <p className="staten-voertuig-info__p"><b>Voertuig:</b> {item.merk} {item.type}</p>
                                <p className="staten-voertuig-info__p"><b>Kleur:</b> {item.kleur}</p>
                                <p className="staten-voertuig-info__p"><b>Kenteken:</b> {item.kenteken}</p>
                                <p className="staten-voertuig-info__p"><b>Startdatum:</b> {item.startDatum}</p>
                                <p className="staten-voertuig-info__p"><b>Einddatum:</b> {item.eindDatum}</p>
                            </div>
                            <div className="staten-voertuig-status__div">
                                <p><b>{item.status}</b></p>
                            </div>
                        </div>
                    ))
                ) : (
                    <p>No matching vehicles found.</p>
                )}
            </div>
        </main>
    );
}
