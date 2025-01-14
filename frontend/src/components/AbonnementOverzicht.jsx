import '../styles/AbonnementOverzicht.css';
import {useEffect, useState} from "react";
import Abonnement from "./Abonnement.jsx";

export default function AbonnementOverzicht() {
    const [abonnementen, setAbonnementen] = useState([]);

    useEffect(() => {
        fetchAbonnementen();
    }, []);

    async function fetchAbonnementen() {
        const response = await fetch(`https://localhost:53085/api/Abonnement`, {
            method: "GET",
            credentials: 'include',
            headers: {
                'content-type': 'application/json'
            },
        });
        const data = await response.json();
        setAbonnementen(data);
        console.log(data);
    }

    // Check if an abonnement has already been accepted (or not) and dont display if so
    const filteredAbonnementen = abonnementen.filter((abonnement) => {
        return abonnement.geaccepteerd === null;
    });

    return (
        <main className='abonnement-overzicht__main'>
            <div className="abonnement-overzicht-content-box__div">
                <h1 className='abonnment-overzicht-title__h1'>Abonnementsoverzicht</h1>
                <span id='abonnement-keuren-status__span' style={{display: 'none'}}></span>
                {
                    filteredAbonnementen && filteredAbonnementen
                        .map((abonnement, key) => <Abonnement key={key} data={abonnement}/>)
                }
            </div>
        </main>
    );
}