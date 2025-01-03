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
                            data-cy="create-vehicle"
                        >
                            Voertuig toevoegen
                        </button>
                    </div>

                    <div className={pageStyles.vehicles}>
                        {
                            vehicles.map((data, key) => (
                                <Vehicle key={key} data={data} setVehicles={setVehicles} />
                            ))
                        }

                    </div>

                </div>
            </main>

            <Footer/>
        </>
    );
}

function Vehicle({ data, setVehicles }) {
    const navigate = useNavigate();
    const altImageName = `${data.merk} ${data.type}`;

    async function handleDeleteVehicle(id) {
        try {
            await deleteVehicle(data.id);

            setVehicles((old) => {
                const copy = [...old];
                return copy.filter(v => v.id !== id);
            });
        } catch (error) {
            window.alert(error);
        }
    }


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
            <p className="">€{data.prijs.toFixed(2)}</p>
        </div>

        <div className={pageStyles.controls}>
            <button
                className={pageStyles.controlUpdateButton}
                onClick={() => navigate("/voertuig-aanpassen", { state: { mode: "update", vehicle: data, } })}
                data-cy="update-vehicle"
            >
                Updaten
            </button>
            <button
                className={pageStyles.controlUpdateButton}
                onClick={() => handleDeleteVehicle(data.id)}
                data-cy="delete-vehicle"
            >
                Verwijderen
            </button>
        </div>
    </div>
    );
}

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

async function deleteVehicle(id) {
    const request = {
        method: 'DELETE',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
    };

    try {
        const response = await fetch(`https://localhost:53085/api/Voertuig/${id}`, request);

        if (!response.ok) {
            throw Error("Kon het voertuig niet verwijderen");
        }
    } catch (error) {
        console.error('error when updating deleting the vehicle, or parsing the response:', error);
        throw Error("Kon het voertuig niet verwijderen");
    }
}
