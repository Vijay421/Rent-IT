import ExpenditureReview from "./ExpenditureReview.jsx";
import '../styles/FrontofficeUitgave.css';
import { useState, useEffect } from "react";

function FrontofficeExpenditure() {

    const [uitgave, setUitgave] = useState([]);

    useEffect(() => {
        fetchGeaccepteerdeHuuraanvragen();
    }, []);

    async function fetchGeaccepteerdeHuuraanvragen() {
        try {
            const response = await fetch('https://localhost:53085/api/FrontOffice/voertuig_uitgave', {
                method: 'GET',

                // TODO: change to 'same-origin' when in production.
                credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                headers: {
                    'content-type': 'application/json'
                },
            });
            const data = await response.json();
            setUitgave(data);
            console.log(data);
        }
        catch (e) {
            console.error(e);
        }
    }

    return (
        <main className="content">
            <div className="divMain">
                <div>
                    <h1 className="divMain__text__FrontOffice">Voertuig uitgave</h1>
                    {uitgave.length === 0 ? (
                        <p className="voertuigTab__empty-text">Geen voertuigen aanwezig</p>
                    ) : (
                        uitgave.map((u) => {
                            return (
                                <ExpenditureReview
                                    key={u.id}
                                    uitgave={u}
                                    setUitgave={setUitgave}
                                />
                            );
                        })
                    )}
                </div>
            </div>
        </main>
    );
}

export default FrontofficeExpenditure;