import "../styles/FrontofficeIntake.css";
import { useState, useEffect, useContext } from "react";
import { UserContext } from "./UserContext.jsx";
import VehicleReview from "./VehicleReview.jsx";

function FrontofficeIntake() {
    const { userRole } = useContext(UserContext);
    const [isGeschiedenis, setView] = useState("nee");
    const [vehicles, setVehicles] = useState([]);
    
    if (userRole === null) {
        return <Navigate to='/'/>
    }
    useEffect(() => {
        async function fetchVehicles() {
            // TO:DO Voertuigen ophalen die geregistreerd zijn met inname id (Tabel VoertuigRegistratie)
            try {
                const response = await fetch('https://localhost:53085/api/Voertuig', {
                    method: 'GET',

                    // TODO: change to 'same-origin' when in production.
                    credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                    headers: {
                        'content-type': 'application/json'
                    },
                });
                const data = await response.json();
                setVehicles(data);
                
            }
            catch (e) {
                console.error(e);
            }
        }
        fetchVehicles();
    }, []);
    const filteredVehicles = vehicles.filter((vehicle) => {
        if (isGeschiedenis !== "ja" && vehicle.status.toLowerCase() !== "verhuurbaar") return false;
        return true;
    });
    const sortedVehicles = filteredVehicles.sort((a, b) => {return a.prijs - b.prijs;});

    return (
        <main className="content">
            <div className="divMain">
                <h1 className="divMain__text__FrontOffice">Voertuig intake</h1>

                <div className="intake-filter-box__div">
                    {/*<label className='divMain__text__subText' htmlFor="select-input">Possible values:</label>*/}
                    <select id="select-input" onChange={(e) => setView(e.target?.value)}>
                        <option value="nee">Openstaand</option>
                        <option value="ja">Geschiedenis</option>
                    </select>
                </div>

                <div className='intake-content-box__div'>
                    {sortedVehicles.length === 0 ? (<p>Geen voertuigen aanwezig</p>) :
                        sortedVehicles.map((vehicle) => {
                            return (
                                <VehicleReview
                                    key={vehicle.id}
                                    data={vehicle}
                                    setVehicles={setVehicles}
                                />
                            );
                        }
                    )}
                </div>
            </div>
        </main>
    );
}


export default FrontofficeIntake;
