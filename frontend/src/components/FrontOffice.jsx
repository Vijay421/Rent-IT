import "../styles/FrontOffice.css";
import { useState, useEffect, useContext } from "react";
import { UserContext } from "./UserContext.jsx";

function FrontOffice() {

    const { userRole } = useContext(UserContext);
    const [vehicles, setVehicles] = useState([]);

    useEffect(() => {
        async function fetchVehicles() {
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

    // TO-DO: sorteer bij meest recente aanvraag
    // const sortedVehicles = vehicles.sort((a, b) => {
    //     if (selectedSorterenSoort === "oplopend") return a.prijs - b.prijs;
    //     if (selectedSorterenSoort === "aflopend") return b.prijs - a.prijs;
    //     return 0;
    // });


    return (
        <main className="content">
            <div className="divMain">
                <h1>FrontOffice</h1>
                {/* TO-DO: Lijst van voertuigen die geregistreerd moeten worden */}

                {vehicles.length === 0 ? (<p>Geen voertuigen aanwezig</p>) :
                    vehicles.map((vehicle) => {
                        <h2>{vehicle.name}</h2>
                    })
                }
            </div>
        </main>
    );
}


export default FrontOffice;