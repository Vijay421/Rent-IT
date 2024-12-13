import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import { useEffect, useState } from "react";
import "../styles/SubscriptionsManagePage.css";

export default function SubscriptionsManagePage() {
    const [subs, setSubs] = useState([]);
    const [renters, setRenters] = useState([]);
    const [selectedRenters, setSelectedRenters] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const userSubs = await getSubsFromCurrentUser();
            setSubs(userSubs);

            const userRenters = await getRentersFromCurrentUser();
            setRenters(userRenters);
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
                                <SubscriptionManage key={key} data={data} renters={renters} selectedRenters={selectedRenters} setSelectedRenters={setSelectedRenters} />
                            ))
                        }
                    </div>

                </main>

            <Footer/>
        </>
    );
}

function SubscriptionManage({ data, renters, selectedRenters, setSelectedRenters }) {
    function handleRentersSelect(e) {
        const id = e.target.value;
        if (id === null) {
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

    // TODO: show selectedRenters, and make it so they can be removed as well.
    return (
        <div className="subs__item">
            <p className="subs__item-label">Naam</p>
            <p>{data.naam}</p>

            <p className="subs__item-label">Prijs per maand</p>
            <p>{data.prijs_per_maand}</p>

            <p className="subs__item-label">Maximaal aantal huurder</p>
            <p>{data.max_huurders}</p>

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
