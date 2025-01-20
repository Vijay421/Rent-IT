import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import { useEffect, useState } from "react";
import "../styles/SubscriptionsManagePage.css";

export default function SubscriptionsManagePage() {
    const [subs, setSubs] = useState([]);
    const [renters, setRenters] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const userSubs = await getSubsFromCurrentUser();
            console.log("getSubsFromCurrentUser ");
            console.log(userSubs);
            setSubs(userSubs);

            const userRenters = await getRentersFromCurrentUser();
            setRenters(userRenters);
            console.log("getRentersFromCurrentUser");
            console.log(userRenters);
        };

        getData();
    }, []);

    return (
        <>
            <Navbar/>

                <main className="subs__page">
                    <h1 className="subs__title">Abonnementen</h1>

                    <div className="subs__subs">
                        {
                            subs.map((data, key) => (
                                <Subscription key={key} data={data} renters={renters} subId={data.id} initialRenters={data.zakelijkeHuurders} />
                            ))
                        }
                    </div>

                </main>

            <Footer/>
        </>
    );
}

function Subscription({ data, renters, subId, initialRenters }) {
    const [selectedRenters, setSelectedRenters] = useState(initialRenters);

    function handleRentersSelect(e) {
        const id = e.target.value;
        if (id === "Geen") {
            return;
        }

        setSelectedRenters((oldRenters) => {
            const copy = [...oldRenters];

            if (!copy.includes(id)) {
                copy.push(id);
                return copy;
            } else {
                return copy;
            }
        });
    }

    function RemoveSelectedRenter(id) {
        setSelectedRenters((oldRenters) => {
            const copy = [...oldRenters];
            const filtered = copy.filter(renterId => renterId !== id);
            return filtered;
        });
    }

    async function handleSave() {
        const didSucceed = await updateRenters(selectedRenters, subId);
        if (didSucceed) {
            window.alert("De veranderingen zijn opgeslagen!");
        } else {
            setSelectedRenters(data.zakelijkeHuurders);
        }
    }

    return (
        <div className="subs__item">
            <p className="subs__item-label">Naam</p>
            <p>{data.naam}</p>

            <p className="subs__item-label">Prijs per maand</p>
            <p>{data.prijsPerMaand}</p>

            <p className="subs__item-label">Maximaal aantal huurder</p>
            <p>{data.maxHuurders}</p>

            <p className="subs__item-label">Einddatum</p>
            <p>{data.einddatum}</p>

            <p className="subs__item-label">Soort</p>
            <p>{data.soort}</p>

            <p className="subs__item-label">Zakelijke huurders</p>
            <select onChange={handleRentersSelect}>
                <option value={null}>Geen</option>
                {
                    renters.map((data, key) => (
                        <option key={key} value={data.id}>{data.userName}</option>
                    ))
                }
            </select>

            {
                selectedRenters.length === 0 ? <></> : (
                    <>
                        <p className="subs__item-label">Geselecteerd</p>
                        <ul>
                            {
                                renters
                                    .filter(renter => selectedRenters.includes(renter.id))
                                    .map((data, key) => (
                                        <li key={key} className="subs__item-renter">
                                            <p>{ data.userName }</p>
                                            <button onClick={() => RemoveSelectedRenter(data.id)}>Verwijder</button>
                                        </li>
                                    ))
                            }
                        </ul>
                    </>
                )
            }

            <button onClick={handleSave} >Opslaan</button>
        </div>
    );
}

/**
 * Gets the subscriptions from the current logged-in user.
 * 
 * @param {Object} payload 
 * @returns {Object}
 */
async function getSubsFromCurrentUser(payload) {
    try {
        const response = await fetch('https://localhost:53085/api/Abonnement/company', {
            method: 'GET',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(payload),
        });

        return await response.json();
    } catch (error) {
        console.error('error when requesting subs, or parsing the response:', error);
        throw error;
    }
}

/**
 * Gets the renters from the current logged-in user.
 * 
 * @returns {Object}
 */
async function getRentersFromCurrentUser() {
    try {
        const response = await fetch('https://localhost:53085/api/HuurBeheerder/zakelijke-huurders', {
            method: 'GET',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
        });

        return await response.json();
    } catch (error) {
        console.error('error when requesting renters, or parsing the response:', error);
        throw error;
    }
}

/**
 * Adds (or removes) renters to (or from) the subscription.
 * 
 * @param {Object} payload 
 * @param {number} subId
 * @returns {boolean}
 */
async function updateRenters(payload, subId) {
    try {
        const response = await fetch(`https://localhost:53085/api/Abonnement/renters/${subId}`, {
            method: 'PUT',
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(payload),
        });

        if (response.ok) {
            return true;
        } else {
            const errorMsg = await response.text();
            window.alert(`Error tijdens het opslaan: ${errorMsg}`);

            return false;
        }
    } catch (error) {
        console.error('error when saving renters, or parsing the response:', error);
        throw error;
    }
}
