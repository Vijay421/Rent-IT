import "../styles/FrontofficeIntake.css";
import { useState, useEffect, useContext } from "react";
import { UserContext } from "./UserContext.jsx";
import VehicleReview from "./VehicleReview.jsx";

function FrontofficeIntake() {
    const { userRole } = useContext(UserContext);
    const [view, setView] = useState([]);
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
                console.log(userRole);
            }
            catch (e) {
                console.error(e);
            }
        }
        fetchVehicles();
    }, []);

    const sortedVehicles = vehicles.sort((a, b) => {return a.prijs - b.prijs;});

    return (
        <main className="content">
            <div className="divMain">
                <h1 className="divMain__text__FrontOffice">Frontoffice Intake</h1>
                <label className='divMain__text__subText' htmlFor="select-input">Possible values:</label>
                <select id="select-input" onChange={(e) => setView(e.target?.value)}>
                    <option value="0">Openstaand</option>
                    <option value="1">Geschiedenis</option>
                </select>
                <div>
                    {(() => {
                        switch(view){
                            case(0):
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
                            case(1):
                                return(<h1>test test</h1>)
                        }
                    })}

                </div>
            </div>
        </main>
    );
}


export default FrontofficeIntake;