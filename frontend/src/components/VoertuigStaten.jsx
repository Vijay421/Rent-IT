import '../styles/VoertuigStaten.css';
import { useEffect, useState } from "react";

export default function VoertuigStaten() {
    const [data, setData] = useState([]);
    const [staat, setStaat] = useState("Alles");
    const [ophaalDatum, setOphaalDatum] = useState("");
    const [inleverDatum, setInleverDatum] = useState("");
    const [optimisticStatuses, setOptimisticStatuses] = useState({});
    const [comments, setComments] = useState({});
    const [unsavedStatuses, setUnsavedStatuses] = useState({});

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

        //Fetch interval - 3 seconds
        const intervalId = setInterval(() => {
            getData();
        }, 3000);

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

    const handleCommentChange = (e, id) => {
        const value = e.target.value;
        setComments((prevComments) => ({
            ...prevComments,
            [id]: value,
        }));
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

    function onResetFiltersButtonClick() {
        setOphaalDatum("");
        setInleverDatum("");
        setStaat("Alles");
    }

    const handleStatusChange = (e, item) => {
        const newStatus = e.target.value;

        setUnsavedStatuses((prevStatuses) => ({
            ...prevStatuses,
            [item.id]: newStatus,
        }));

        if (newStatus !== "Reparatie" && newStatus !== "Geblokkeerd") {
            saveStatus(item, newStatus, "");
        }
    };

    async function saveStatus(item, status, comment) {
        const payload = {
            ...item,
            status: status,
            opmerking: comment || "",
        };

        try {
            const request = {
                method: 'PUT',
                credentials: 'include',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(payload),
            };

            const response = await fetch(`https://localhost:53085/api/Voertuig/${payload.id}`, request);

            if (!response.ok) {
                throw new Error("Kon het voertuig niet updaten");
            }

            console.log("Status updated");
            setOptimisticStatuses((prevStatuses) => ({
                ...prevStatuses,
                [item.id]: status,
            }));
            setUnsavedStatuses((prevStatuses) => {
                const updated = { ...prevStatuses };
                delete updated[item.id];
                return updated;
            });
        } catch (error) {
            console.error('Error when updating vehicle, or parsing the response:', error);
            alert("Kon het voertuig niet updaten");
        }
    }

    const uniqueStatuses = ["Verhuurbaar", "Onverhuurbaar", "Reparatie", "Geblokkeerd"];

    return (
        <main className='voertuig-staten-page__main'>
            <h1 className='staten-pagina-title__h1'>Voertuig staten</h1>
            <div className='staten-filter-box__div'>
                <div className="staten-filter-ophaaldatum__div">
                    <label htmlFor="staten-ophaaldatum__input">Startperiode:</label>
                    <input
                        data-cy='staten-start-datum-input'
                        type='date'
                        id='staten-ophaaldatum__input'
                        className='verhuurde-dates-class'
                        onChange={handleOphaalDatumChange}
                    />
                </div>

                <div className="staten-filter-inleverdatum__div">
                    <label htmlFor="staten-inleverdatum__input">Eindperiode:</label>
                    <input
                        data-cy='staten-eind-datum-input'
                        type='date'
                        id='staten-inleverdatum__input'
                        className='staten-dates-class'
                        onChange={handleInleverDatumChange}
                    />
                </div>

                <div className="staten-filter-voertuig-staat__div">
                    <label htmlFor="staten-voertuig-staat__select">Staat:</label>
                    <select
                        data-cy='staat-filter-select'
                        id='staten-voertuig-staat__select'
                        className='staten-filters-class'
                        value={staat}
                        onChange={(e) => setStaat(e.target.value)}
                    >
                        <option value="Alles">Alles</option>
                        <option value="Verhuurbaar">Beschikbaar</option>
                        <option value="Onverhuurbaar">Verhuurd</option>
                        <option value="Reparatie">In reparatie</option>
                        <option value="Geblokkeerd">Geblokkeerd</option>
                    </select>
                </div>

                <div className="staten-filter-reset-filters__div">
                    <button
                        data-cy='staten-reset-filter-button'
                        id="staten-reset-filters__button"
                        onClick={onResetFiltersButtonClick}
                    >
                        Reset filters
                    </button>
                </div>
            </div>

            <div data-cy="staten-voertuig-box" id="staten-voertuig-box__div">
                {filteredData.length > 0 ? (
                    filteredData.map((item, index) => (
                        <div key={index} className="staten-voertuig__div" data-cy="vehicle" data-start-date={item.startDatum} data-end-date={item.eindDatum}>
                            <div className="staten-voertuig-data">
                                <p className="staten-voertuig-info__p"><b>Voertuig:</b> {item.merk} {item.type}</p>
                                <p className="staten-voertuig-info__p"><b>Kenteken:</b> {item.kenteken}</p>
                                <p className="staten-voertuig-info__p">
                                    <b>Huurperiode:</b> {item.startDatum} - {item.eindDatum}</p>
                            </div>
                            <div className="staten-voertuig-status__div">
                                <select
                                    data-cy='voertuig-status-select'
                                    id="staten-voertuig-status__select"
                                    value={unsavedStatuses[item.id] || item.status}
                                    onChange={(e) => handleStatusChange(e, item)}
                                >
                                    {uniqueStatuses.map((status, index) => (
                                        <option key={index} value={status}>{status}</option>
                                    ))}
                                </select>

                                {(unsavedStatuses[item.id] === "Reparatie" || unsavedStatuses[item.id] === "Geblokkeerd") && (
                                    <>
                                        <textarea
                                            data-cy='voertuig-comment-textarea'
                                            placeholder="Voer een opmerking in..."
                                            value={comments[item.id] || ""}
                                            onChange={(e) => handleCommentChange(e, item.id)}
                                            className="voertuig-opmerking-textarea"
                                        />
                                        <button
                                            data-cy='voertuig-save-button'
                                            onClick={() => saveStatus(item, unsavedStatuses[item.id], comments[item.id])}
                                            className="voertuig-save-button"
                                        >
                                            Opslaan
                                        </button>
                                    </>
                                )}
                            </div>
                        </div>
                    ))
                ) : (
                    <p className='no-voertuigen-text'>Geen voertuigen gevonden.</p>
                )}
            </div>
        </main>
    );
}
