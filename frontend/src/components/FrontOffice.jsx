import "../styles/FrontOffice.css";
import { useState, useEffect, useContext } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UserContext } from "./UserContext.jsx";

function FrontOffice() {
    const location = useLocation();
    const navigate = useNavigate();
    const { userRole } = useContext(UserContext);
    const [vehicles, setVehicles] = useState([]);
    const [error, setError] = useState(null);

    function bekijk(vehicle) {
        navigate(`/frontoffice/inname/${vehicle.id}`, {
            state: { vehicleData: vehicle, startDatum: vehicle.startDatum, eindDatum: vehicle.eindDatum }
        });
    }

    useEffect(() => {
        async function fetchVehicles() {
            try {
                const response = await fetch('https://localhost:53085/api/Voertuig', {
                    method: 'GET',
                    credentials: 'include',
                    headers: {
                        'content-type': 'application/json'
                    },
                });
                if (!response.ok) {
                    throw new Error('Failed to fetch vehicles');
                }
                const data = await response.json();
                setVehicles(data);
                console.log(userRole);
            }
            catch (e) {
                console.error(e);
                setError(e.message);
            }
        }
        fetchVehicles();
    }, []);

    const sortedVehicles = (vehicles || []).sort((a, b) => a.prijs - b.prijs);

    return (
        <main className="content">
            <div className="divMain">
                <div>
                    <h1>FrontOffice</h1>
                    {error && <p>Error: {error}</p>}
                    {sortedVehicles.length === 0 ? (
                        <p>Geen voertuigen aanwezig</p>
                    ) : (
                        sortedVehicles.map((vehicle) => (
                            <div className="voertuigTab" key={vehicle.kenteken}>
                                <span>{vehicle.kenteken}</span>
                                <span>{vehicle.merk} {vehicle.type}</span>
                                <button onClick={() => bekijk(vehicle)}>Bekijk</button>
                            </div>
                        ))
                    )}
                </div>
            </div>
        </main>
    );
}

export default FrontOffice;
