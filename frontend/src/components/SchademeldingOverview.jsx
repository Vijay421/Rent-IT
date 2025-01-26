import "../styles/SchademeldingOverview.css";
import { useState, useEffect, useContext } from "react";
import { UserContext } from "./UserContext.jsx";
import SchademeldingReview from "./SchademeldingReview.jsx";

function SchademeldingOverview() {
    const { userRole } = useContext(UserContext);
    const {view, setView} = useState([]);
    
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

    const sortedVehicles = vehicles.sort((a, b) => {return a.prijs - b.prijs;});

    return (
        <main className="content">
            <div className="divMain">
                <h1 className="divMain__text__FrontOffice">Frontoffice inname</h1>
                <label className='label' htmlFor="select-input">Possible values:</label>
                <select id="select-input" onChange={(e) => setView(e.target?.value)}>
                    <option>Not defined</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                </select>
                <div>
                    {(() => {
                        switch(view){
                            case(0):
                                {sortedVehicles.length === 0 ? (<p>Geen voertuigen aanwezig</p>) :
                                        sortedVehicles.map((vehicle) => {
                                            return (
                                                <SchademeldingReview
                                                    key={vehicle.id}
                                                    data={vehicle}
                                                />
                                            );
                                        })
                                    }

                            case(1):
                        }
                    })}
                    
                </div>
            </div>
        </main>
    );
}


export default SchademeldingOverview;