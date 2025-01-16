import '../styles/SubscriptionRequest.css';
import { useEffect, useRef, useState } from "react";
import styles from "./Profile/ProfilePageBase.module.css";
import { Link, useLocation } from "react-router-dom";

function SubscriptionRequest() {
    const location = useLocation();
    const pageData = location.state?.pageData;
    console.log(location.state?.pageData);
    const mode = pageData ? "update" : "create";

    const [bedrijfsnaam, setBedrijfsnaam] = useState("");
    const [adress, setAdress] = useState("");
    const [kvkNumber, setKvkNumber] = useState("");
    const [maxSubs, setMaxSubs] = useState(pageData?.maxHuurders ? pageData?.maxHuurders : "");
    const [endDate, setEndDate] = useState(pageData?.einddatum ? pageData?.einddatum : "");
    const [subName, setSubName] = useState(pageData?.naam ? pageData?.naam : "");
    const [subscriptionType, setSubscriptionType] = useState(pageData?.soort ? pageData?.soort : "");
    const [confirmationMessage, setConfirmationMessage] = useState("");
    const form = useRef(null);

    useEffect(() => {
        const getData = async () => {
            try {
                const bedrijf = await getBedrijf();
                setAdress(bedrijf.adres);
                setBedrijfsnaam(bedrijf.bedrijfsnaam);
                setKvkNumber(bedrijf.kvk);
            } catch(e) {
                console.error(e);
            }
        };

        getData();
    }, []);

    function handleSubscriptionType(e) {
        const value = e.target.value;
        setSubscriptionType(value);

        if (value === "pay_as_you_go" && (maxSubs.length === 0 || maxSubs === 50)) {
            setMaxSubs(100);
        }
        if (value === "prepaid" && (maxSubs.length === 0 || maxSubs === 100)) {
            setMaxSubs(50);
        }
    }

    async function handleSubmit() {
        if (endDate !== "") {
            const today = new Date();
            today.setHours(0, 0, 0, 0); // Beginning of the day.
            const endDateObj = new Date(endDate);

            if (endDateObj < today) {
                window.alert("Einddatum kan niet eerder zijn dan vandaag");
                return;
            }
        }

        // Don't submit when the form is invalid.
        if (!form.current.checkValidity()) {
            return;
        }

        if (
            maxSubs &&
            endDate &&
            subName &&
            subscriptionType
        ) {
            const payload = {
                naam: subName,
                max_huurders: maxSubs,
                einddatum: endDate,
                soort: subscriptionType,
            };
    
            try {
                if (mode === "create") {
                    await sendSubRequest(payload);
                } else if (mode === "update") {
                    await updateSubRequest(payload, pageData?.id);
                }
                setConfirmationMessage("Uw abonnementhouders aanvraag is verzonden!");
            } catch {
                window.alert("Error tijdens het versturen van de aanvraag");
                setConfirmationMessage("Er is een fout opgetreden!");
            }
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
        }
    }


    return (
        <main className={styles.MainDiv}>
            <p className="MainDiv__Text">Vul hieronder de gegevens in om een abonnement aan te vragen.</p>

            <form
                ref={form}
                className="form-group"
                onSubmit={(e) => e.preventDefault()}
            >

                <div className="form-group">
                    <label htmlFor="abonnement__bedrijfsnaam" className="form__text">Bedrijfsnaam:</label>
                    <input
                        id="abonnement__bedrijfsnaam"
                        className="bedrijfsnaam__text"
                        type="text"
                        placeholder="Bedrijfsnaam"
                        value={bedrijfsnaam}
                        disabled
                        data-cy="company-name"
                    />
                    <label htmlFor="adress" className="form__text">Adres:</label>
                    <input
                        id="abonnement__adress"
                        className="adress__text"
                        type="text"
                        placeholder="Vul hier uw adres in voor het aanvragen van een abonnement."
                        value={adress}
                        minLength="2"
                        maxLength="50"
                        disabled
                        data-cy="address"
                    />
                    <label htmlFor="kvk-number" className="form__text">KVK-nummer:</label>
                    <input
                        id="abonnement__kvk-number"
                        className="kvk-number__text"
                        type="number"
                        placeholder="Kvk."
                        value={kvkNumber}
                        disabled
                        data-cy="company-number"
                    />

                    <label htmlFor="abonnement__max-number" className="form__text">Maximum huurder:</label>
                    <input
                        id="abonnement__max-number"
                        className="abonnement__max-number"
                        type="number"
                        placeholder="Vul hier het maximaal aantal huurder voor het abonnement."
                        value={maxSubs}
                        min="1"
                        max="1000"
                        required
                        onChange={(e) => {
                            const value = e.target.value;
                            if (/^\d*$/.test(value)) {
                                setMaxSubs(value);
                            }
                        }}
                        data-cy="max-renters"
                    />

                    <label htmlFor="abonnement__end-date" className="form__text">Einddatum:</label>
                    <input
                        id="abonnement__end-date"
                        className="abonnement__end-date"
                        type="date"
                        required
                        value={endDate}
                        onChange={(e) => {
                            setEndDate(e.target.value)
                        }}
                        data-cy="end-date"
                    />

                    <label htmlFor="abonnement__naam" className="form__text">Abonnementnaam:</label>
                    <input
                        id="abonnement__naam"
                        className="abonnement__naam"
                        type="text"
                        minLength="2"
                        maxLength="50"
                        placeholder="Vul hier de naam voor het  abonnement."
                        value={subName}
                        required
                        onChange={(e) => {
                            setSubName(e.target.value)
                        }}
                        data-cy="subscription-name"
                    />

                    <label htmlFor="subscription-type" className="form__text">Type Abonnement:</label>
                    <div className="radio-group" onChange={handleSubscriptionType}>
                        <label>
                            <input defaultChecked={pageData?.soort === "pay_as_you_go"} type="radio" id="PayAsYouGo" name="subscriptionType" value="pay_as_you_go" data-cy="pay-as-you-go" required/> Pay as you go
                        </label>
                        <label>
                            <input defaultChecked={pageData?.soort === "prepaid"} type="radio" id="Prepaid" name="subscriptionType" value="prepaid" data-cy="prepaid"/> Prepaid
                        </label>
                    </div>
                </div>
                {confirmationMessage && (
                    <p
                        className={`confirmation-message ${
                            confirmationMessage === "Uw abonnementhouders aanvraag is verzonden!"
                                ? "success"
                                : "error"
                        }`}
                    >
                        {confirmationMessage}
                    </p>
                )}

                <button onClick={handleSubmit} type="submit" className="submit-button__text submit-button__div" data-cy="submit">
                    Verstuur abonnement aanvraag
                </button>
            </form>
        </main>
    );
}

export default SubscriptionRequest;

/**
 * Will send the sub request to the backend.
 * 
 * @param {Object} payload 
 * @returns {Object}
 */
async function sendSubRequest(payload) {
    try {
        const response = await fetch('https://localhost:53085/api/Abonnement', {
            method: 'POST',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(payload),
        });

        return await response.json();
    } catch (error) {
        console.error('error when requesting the rent history request, or parsing the response:', error);
        throw error;
    }
}

/**
 * Will try to update the subscription with the given id.
 * 
 * @param {Object} payload 
 * @param {number} id 
 */
async function updateSubRequest(payload, id) {
    try {
        await fetch(`https://localhost:53085/api/Abonnement/${id}`, {
            method: 'PUT',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(payload),
        });
    } catch (error) {
        console.error('error when updating a subscription, or parsing the response:', error);
        throw error;
    }
}

/**
 * Returns data from the company of the current logged-in huurbeheerder.
 * 
 * @returns Object
 */
async function getBedrijf() {
    try {
        const response = await fetch('https://localhost:53085/api/HuurBeheerder/bedrijf', {
            method: 'GET',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
        });

        return await response.json();
    } catch (error) {
        console.error('error when requesting the company\'s name, or parsing the response:', error);
        throw error;
    }
}
