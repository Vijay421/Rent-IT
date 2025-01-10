import "../styles/SchademeldingOverview.css";
import { useState, useEffect, useContext } from "react";
import { UserContext } from "./UserContext.jsx";
import SchademeldingReview from "./SchademeldingOverview.jsx";

function SchademeldingOverview() {
    const { userRole } = useContext(UserContext);
    const [schadeclaims, setSchadeclaims] = useState([]);

    useEffect(() => {
        async function fetchVehicles() {
            // TO:DO Voertuigen ophalen die geregistreerd zijn met inname id (Tabel VoertuigRegistratie & Schadeclaims)
            try {
                const response = await fetch('https://localhost:53085/api/Schadeclaim', {
                    method: 'GET',

                    // TODO: change to 'same-origin' when in production.
                    credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                    headers: {
                        'content-type': 'application/json'
                    },
                });
                const data = await response.json();
                setSchadeclaims(data);
                console.log(userRole);
            }
            catch (e) {
                console.error(e);
            }
        }
        fetchVehicles();
    }, []);

    const sortedSchadeclaims = schadeclaims.sort((a, b) => {return a.prijs - b.prijs;});

    return (
        <main className="content">
            <div className="divMain">
                <div>
                    <h1 className="divMain__text__FrontOffice">Schadeclaims</h1>
                    <button>Voeg nieuwe schadeclaim toe</button>
                    {sortedSchadeclaims.length === 0 ? (<p>Geen schadeclaims aanwezig</p>) :
                        sortedSchadeclaims.map((schadeclaim) => {
                            return (
                                <SchademeldingReview
                                    key={schadeclaim.id}
                                    data={schadeclaim}
                                />
                            );
                        })
                    }
                </div>
            </div>
        </main>
    );
}


export default SchademeldingOverview;