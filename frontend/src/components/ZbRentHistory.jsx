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

    const downloadCSV = () => { //modified ChatGPT code
        // const headers = ['Merk', 'Type', 'Kenteken', 'Kleur', 'Aanschafjaar', 'Soort', 'Status','Wettelijke_naam', 'Start Datum', 'Eind Datum'];
        // const rows = filteredVehicles.map(vehicle => [
        //     vehicle.voertuig?.merk,
        //     vehicle.voertuig?.type,
        //     vehicle.voertuig?.kenteken,
        //     vehicle.voertuig?.kleur,
        //     vehicle.voertuig?.aanschafjaar,
        //     vehicle.voertuig?.soort,
        //     vehicle.voertuig?.status,
        //     vehicle.wettelijke_naam,
        //     vehicle.voertuig.startDatum,
        //     vehicle.voertuig.eindDatum,
        // ]);

        // const csvContent = [
        //     headers.join(','),
        //     ...rows.map(row => row.join(',')),
        // ].join('\n');

        // const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
        //
        // const link = document.createElement('a');
        // link.href = URL.createObjectURL(blob);
        // link.download = 'verhuurde_voertuigen.csv';
        // link.click();
    };

    return (
        <main className='zb-rent-history__main'>
            <div className='zb-filter-bar__div'>
                <h1 className='zb-filter-bar-title__h1'>Werknemersgeschiedenis</h1>

                <div className='zb-filter-bar-filter-box__div'>
                    <div className="zb-filter-bar-werkenemer-filter__div">
                        <label htmlFor="werknemer-select" className='filter-bar-dropdown__label'>Werknemer: </label>
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

                    <div className="zb-filter-bar-sorteren-filter__div">
                        <label htmlFor="sorteren-select" className='filter-bar-dropdown__label'>Sorteren: </label>
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

                    <div className="filter-bar-start-datum__div">
                        <label htmlFor="filter-start-datum-input">Startdatum: </label>
                        <input
                            type="month"
                            className="filter-start-datum-field"
                            id="filter-start-datum-input"
                            placeholder='YYYY-MM'
                            maxLength={7}
                            onKeyDown={(e) => {
                                if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight' && e.key !== 'Tab' && e.key !== '-') {
                                    e.preventDefault();
                                }
                            }}
                            value={startDatum}
                            onChange={(e) => setStartDatum(e.target.value)}
                        />
                    </div>

                    <div className="filter-bar-eind-datum__div">
                        <label htmlFor="filter-eind-datum-input">Einddatum: </label>
                        <input
                            type="month"
                            className="filter-eind-datum-field"
                            id="filter-eind-datum-input"
                            placeholder='YYYY-MM'
                            maxLength={7}
                            onKeyDown={(e) => {
                                if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight' && e.key !== 'Tab' && e.key !== '-') {
                                    e.preventDefault();
                                }
                            }}
                            value={eindDatum}
                            onChange={(e) => setEindDatum(e.target.value)}
                        />
                    </div>

                    <div className="verhuurde-filter-download-button__div">
                        <button id="verhuurde-download_button" onClick={downloadCSV}>Download gegevens</button>
                    </div>

                </div>
            </div>

            <div className="zb-rent-history-box__div">
                <EmployeeBox/>
                <EmployeeBox/>
                <EmployeeBox/>
                <EmployeeBox/>
                <EmployeeBox/>
                <EmployeeBox/>
                <EmployeeBox/>
            </div>
        </main>
    );
}