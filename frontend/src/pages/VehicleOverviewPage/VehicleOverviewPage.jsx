import { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import Navbar from "../../components/Navbar.jsx";
import Footer from "../../components/Footer.jsx";
import pageStyles from "./vehiclePage.module.css";
import temp from '../../assets/toyota-corolla.png';

export default function VehicleOverviewPage() {
    const navigate = useNavigate();
    const [vehicles, setVehicles] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const vehicles = await getVehicles();
            setVehicles(vehicles);
        };
        getData();
    }, []);

    return (
        <>
            <Navbar/>

            <main className={pageStyles.main}>
                <div className={pageStyles.content}>

                    <h1 className={pageStyles.title}>Voertuigoverzicht</h1>

                    <div className={pageStyles.addVehicle}>
                        <button
                            className={pageStyles.addVehicleButton}
                            onClick={() => navigate("/voertuig-aanpassen", { state: { mode: "create" } })}
                        >
                            Voertuig toevoegen
                        </button>
                    </div>

                    <div className={pageStyles.vehicles}>
                        {
                            vehicles.map((data, key) => (
                                <Vehicle key={key} data={data} />
                            ))
                        }

                    </div>

                </div>
            </main>

            <Footer/>
        </>
    );
}

function Vehicle({ data }) {
    const altImageName = `${data.merk} ${data.type}`;

    return (
        <div className={pageStyles.vehicle}>

        <div className={pageStyles.vehicleImageBox}>
            <img className={pageStyles.vehicleImage} src={temp} alt={altImageName} />
        </div>

        <h2 className={pageStyles.vehicleTitle}>{altImageName}</h2>

        <div className={pageStyles.vehicleDetails}>
            <p className={`${pageStyles.label} ${pageStyles.labelFirst}`}>Kenteken</p>
            <p>{data.kenteken}</p>

            <p className={`${pageStyles.label}`}>Kleur</p>
            <p>{data.kleur}</p>

            <p className={`${pageStyles.label}`}>Aanschafjaar</p>
            <p>{data.aanschafjaar}</p>

            <p className={`${pageStyles.label}`}>Soort</p>
            <p>{data.soort}</p>
        </div>

        <div className={pageStyles.vehicleComment}>
            <p className={`${pageStyles.label} ${pageStyles.labelFirst}`}>Opmerking</p>
            <p>{data.opmerking === null || data.opmerking.length === 0 ? "Geen." : data.opmerking}</p>
        </div>

        <div className={pageStyles.vehicleCosts}>
            <p className={`${pageStyles.vehicleCost} ${pageStyles.label} ${pageStyles.labelFirst}`}>Kosten</p>
            <p className="rent-history-item__vehicle-cost">€{data.prijs.toFixed(2)}</p>
        </div>

        <div className={pageStyles.controls}>
            <button className={pageStyles.controlUpdateButton}>Updaten</button>
            <button>Verwijderen</button>
        </div>
    </div>
    );
}

// TODO: handle server errors.
/**
 * Will attempt to get the rent history from the server.
 * 
 * @returns {Object}
 */
async function getVehicles() {
    try {
        const response = await fetch('https://localhost:53085/api/Voertuig', {
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
