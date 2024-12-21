import "../styles/FrontOffice.css";
import { useState, useEffect, useContext } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UserContext } from "./UserContext.jsx";
import VehicleReview from "./VehicleReview.jsx";

function FrontOffice() {
    const { userRole } = useContext(UserContext);
    const [vehicles, setVehicles] = useState([]);

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
                    {/* TO-DO: Lijst van voertuigen die geregistreerd moeten worden */}

                    {sortedVehicles.length === 0 ? (<p>Geen voertuigen aanwezig</p>) :
                        sortedVehicles.map((vehicle) => {
                            return (
                                <VehicleReview
                                    key={vehicle.id}
                                    data={vehicle}
                                />
                            );
                        })
                    }
                </div>
            </div>
        </main>
    );
}

export default FrontOffice;
