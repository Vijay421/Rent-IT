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
    }

    const updateAbonnement = (updatedAbonnement) => {
        setAbonnementen((prevAbonnementen) =>
            prevAbonnementen.map((abonnement) =>
                abonnement.id === updatedAbonnement.id ? updatedAbonnement : abonnement
            )
        );
    };

    const filteredAbonnementen = abonnementen.filter((abonnement) => {
        return abonnement.geaccepteerd === null;
    });

    return (
        <main className='abonnement-overzicht__main'>
            <div className="abonnement-overzicht-content-box__div" data-cy='abonnement-overzicht-content-box'>
                <h1 className='abonnment-overzicht-title__h1'>Abonnementsoverzicht / Abonnement beoordeling</h1>
                <span id='abonnement-keuren-status__span' style={{display: 'none'}}></span>
                {
                    filteredAbonnementen && abonnementen
                        .map((abonnement, key) => <Abonnement onUpdate={updateAbonnement} key={key} data={abonnement}/>)
                }
            </div>
        </main>
    );
}