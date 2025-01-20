import '../styles/ZbRentHistory.css';
import EmployeeBox from "./EmployeeBox.jsx";
import {useEffect, useState} from "react";

export default function ZbRentHistory() {
const [werknemer, setWerknemer] = useState();
const [startDatum, setStartDatum] = useState();
const [eindDatum, setEindDatum] = useState();
const [sorteren, setSorteren] = useState();


    useEffect(() => {
        fetchZakelijkeHuurders();
    }, []);

    async function fetchZakelijkeHuurders() {
        const response = await fetch(`https://localhost:53085/api/HuurBeheerder/zakelijke-huurders`, {
            method: 'GET',
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
        });

        const data = await response.json();
        console.log(data);
    }

    return (
        <main className='zb-rent-history__main'>
            <div className='zb-filter-bar__div'>
                <h1 className='zb-filter-bar-title__h1'>Werknemersgeschiedenissen</h1>

                <div className='zb-filter-bar-filter-box__div'>
                    <div className="zb-filter-bar-werkenemer-filter__div">
                        <label htmlFor="werknemer-select" className='filter-bar-dropdown__label'>Werknemer:</label>
                        <select
                            id='werknemer-select'
                            className='werknemer-selects'
                            value={werknemer}
                            onChange={(e) => setWerknemer(e.target.value)}
                        >
                            <option value="alles">Alles</option>
                            {
                                /*list of workers*/
                            }
                        </select>
                    </div>

                    <div className="filter-bar-start-datum__div">
                        <label htmlFor="filter-start-datum-input">
                            Startdatum:
                        </label>
                        <input
                            type="date"
                            className="filter-start-datum-field"
                            id="filter-start-datum-input"
                            value={startDatum}
                            onChange={(e) => setStartDatum(e.target.value)}
                        />
                    </div>

                    <div className="filter-bar-eind-datum__div">
                        <label htmlFor="filter-eind-datum-input">
                            Einddatum:
                        </label>
                        <input
                            type="date"
                            className="filter-eind-datum-field"
                            id="filter-eind-datum-input"
                            value={eindDatum}
                            onChange={(e) => setEindDatum(e.target.value)}
                        />
                    </div>

                    <div className="zb-filter-bar-sorteren-filter__div">
                        <label htmlFor="sorteren-select" className='filter-bar-dropdown__label'>Sorteren:</label>
                        <select
                            id='sorteren-select'
                            className='sorteren-selects'
                            value={sorteren}
                            onChange={(e) => setSorteren(e.target.value)}

                        >
                            <option value="geen">Geen</option>
                            <option value="oplopend">Oplopend</option>
                            <option value="aflopend">Aflopend</option>
                        </select>
                    </div>
                </div>
            </div>

            <div className="zb-rent-history-box__div">
                box
            </div>
        </main>
    );
}