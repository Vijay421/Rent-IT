import '../styles/ZbRentHistory.css';
import EmployeeBox from "./EmployeeBox.jsx";
import { useEffect, useState } from "react";

export default function ZbRentHistory() {
    const [data, setData] = useState([]);
    const [werknemer, setWerknemer] = useState("alles");
    const [startDatum, setStartDatum] = useState("");
    const [eindDatum, setEindDatum] = useState("");

    useEffect(() => {
        fetchZakelijkeHuurders();
    }, []);

    async function fetchZakelijkeHuurders() {
        try {
            const response = await fetch(`https://localhost:53085/api/HuurBeheerder/werknemer_geschiedenis`, {
                method: 'GET',
                credentials: 'include',
                headers: {
                    'content-type': 'application/json',
                },
            });

            const jsonify = await response.json();
            setData(jsonify);
        } catch (error) {
            console.error("Failed to fetch data:", error);
        }
    }

    const calculateCosts = (record) => {
        const amountOfDays = Math.floor(
            (new Date(record.einddatum) - new Date(record.startdatum)) / (1000 * 60 * 60 * 24)
        );

        const carPrice = record.voertuig?.prijs * amountOfDays || 0;
        const insurance = record.voertuig?.soort === "Auto" ?
            15.50 * amountOfDays
            :
            record.voertuig?.soort === "Caravan" ?
                22 * amountOfDays
                :
                0;
        const fuel = record.voertuig?.soort === "Auto" ?
            50
            :
            record.voertuig?.soort === "Caravan" ?
                0
                :
                100;
        const kmCharge = 0.23 * record.verwachte_km || 0;
        const deposit = record.voertuig?.soort === "Auto" ?
            400
            :
            record.voertuig?.soort === "Caravan" ?
                750
                :
                1500;
        const tax = (carPrice + insurance + kmCharge) * 0.21 || 0;
        const korting = 0; // TODO: Add business logic for korting if required.
        const totalCost = carPrice + insurance + fuel + kmCharge + deposit + tax - korting;

        return {
            carPrice,
            insurance,
            fuel,
            kmCharge,
            deposit,
            tax,
            korting,
            totalCost,
        };
    };

    const downloadCSV = () => {
        const headers = [
            'Medewerker',
            'Voertuig',
            'Kenteken',
            'Kleur',
            'Aanschafjaar',
            'Soort',
            'Startdatum',
            'Einddatum',
            'Kosten p/m',
            'Totale kosten',
        ];

        const rows = filteredHuuraanvragen.map((record) => {
            const costs = calculateCosts(record);
            return [
                record.wettelijkeNaam,
                record.voertuig?.naam,
                record.voertuig?.kenteken,
                record.voertuig?.kleur,
                record.voertuig?.aanschafjaar,
                record.voertuig?.soort,
                record.startdatum,
                record.einddatum,
                record.voertuig?.prijs.toFixed(2),
                costs.totalCost.toFixed(2),
            ];
        });

        const csvContent = [
            headers.join(','),
            ...rows.map(row => row.join(',')),
        ].join('\n');

        const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = 'werknemer_huurgeschiedenis.csv';
        link.click();
    };

    const filteredHuuraanvragen = data.filter((emp) => {
        if (werknemer !== 'alles' && emp.wettelijkeNaam !== werknemer) {
            return false;
        }
        if (startDatum && emp.startdatum < startDatum) {
            return false;
        }
        if (eindDatum && emp.einddatum > eindDatum) {
            return false;
        }
        return true;
    });

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
                                [...new Set(data.map((emp) => emp.wettelijkeNaam))].map((uniqueName, key) => (
                                    <option key={key} value={uniqueName}>{uniqueName}</option>
                                ))
                            }
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
                {
                    filteredHuuraanvragen.map((emp, key) => (
                        <EmployeeBox key={key} data={emp}/>
                    ))
                }
            </div>
        </main>
    );
}