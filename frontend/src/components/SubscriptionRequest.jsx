import '../styles/SubscriptionRequest.css';
import { useState } from "react";
import styles from "./Profile/ProfilePageBase.module.css";

function SubscriptionRequest() {
    const [bedrijfsnaam, setBedrijfsnaam] = useState("");
    const [adress, setAdress] = useState("");
    const [kvkNumber, setKvkNumber] = useState("");
    const [maxSubs, setMaxSubs] = useState("");
    const [endDate, setEndDate] = useState("");
    const [subName, setSubName] = useState("");
    const [subscriptionType, setSubscriptionType] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");

    function handleBedrijfsnaam(e) {
        setBedrijfsnaam(e.target.value);
    }

    function handleAdress(e) {
        setAdress(e.target.value);
    }

    function handleSubscriptionType(e) {
        setSubscriptionType(e.target.value);
    }

    async function handleSubmit() {
        if (endDate !== "") {
            const today = new Date();
            today.setHours(0, 0, 0, 0); // Beginning of the day.
            const endDateObj = new Date(endDate);

            if (endDateObj < today) {
                window.alert("Einddatum kan niet eerder zijn dag vandaag");
                return;
            }
        }

        if (
            bedrijfsnaam &&
            adress &&
            kvkNumber &&
            maxSubs &&
            endDate &&
            subName &&
            subscriptionType
        ) {
            const payload = {
                naam: subName,
                bedrijfsnaam,
                adres: adress,
                kvk_nummer: kvkNumber,
                max_huurders: maxSubs,
                einddatum: endDate,
                soort: subscriptionType,
            };
    
            try {
                await sendSubRequest(payload);
                setConfirmationMessage("Uw abonnementhouders aanvraag is verzonden!");
            } catch {
                window.alert("Error tijdens het versturen van de aanvraag");
            }
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
        }
    }


    return (
        <main className={styles.MainDiv}>
            <p className="MainDiv__Text">Vul hieronder de gegevens in om een abonnement aan te vragen.</p>

            <div className="form-group">
                <label htmlFor="abonnement__bedrijfsnaam" className="form__text">Bedrijfsnaam:</label>
                <input
                    id="abonnement__bedrijfsnaam"
                    className="bedrijfsnaam__text"
                    type="text"
                    placeholder="Vul hier uw bedrijfsnaam in voor het aanvragen van een abonnement."
                    value={bedrijfsnaam}
                    minLength="2"
                    maxLength="50"
                    onChange={handleBedrijfsnaam}
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
                    onChange={handleAdress}
                />
                <label htmlFor="kvk-number" className="form__text">KVK-nummer:</label>
                <input
                    id="abonnement__kvk-number"
                    className="kvk-number__text"
                    type="number"
                    placeholder="Vul hier uw KVK-nummer in voor het aanvragen van een abonnement."
                    value={kvkNumber}
                    minLength="2"
                    maxLength="50"
                    onChange={(e) => {
                        const value = e.target.value;
                        if (/^\d*$/.test(value)) {
                            setKvkNumber(value);
                        }
                    }}
                />

                <label htmlFor="abonnement__max-number" className="form__text">Maximum huurder:</label>
                <input
                    id="abonnement__max-number"
                    className="abonnement__max-number"
                    type="number"
                    placeholder="Vul hier het maximaal aantal huurder voor het abonnement."
                    value={maxSubs}
                    minLength="1"
                    maxLength="1000"
                    onChange={(e) => {
                        const value = e.target.value;
                        if (/^\d*$/.test(value)) {
                            setMaxSubs(value);
                        }
                    }}
                />

                <label htmlFor="abonnement__end-date" className="form__text">Einddatum:</label>
                <input
                    id="abonnement__end-date"
                    className="abonnement__end-date"
                    type="date"
                    required
                    onChange={(e) => {
                        setEndDate(e.target.value)
                    }}
                />

                <label htmlFor="abonnement__naam" className="form__text">Abonnementnaam:</label>
                <input
                    id="abonnement__naam"
                    className="abonnement__naam"
                    type="text"
                    minLength="2"
                    maxLength="50"
                    placeholder="Vul hier de naam voor het  abonnement."
                    required
                    onChange={(e) => {
                        setSubName(e.target.value)
                    }}
                />

                <label htmlFor="subscription-type" className="form__text">Type Abonnement:</label>
                <div className="radio-group" onChange={handleSubscriptionType}>
                    <label>
                        <input type="radio" id="PayAsYouGo" name="subscriptionType" value="pay_as_you_go" /> Pay as you go
                    </label>
                    <label>
                        <input type="radio" id="Prepaid" name="subscriptionType" value="prepaid" /> Prepaid
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
            <div onClick={handleSubmit} className="submit-button">
                <div className="submit-button__div">
                    <p className="submit-button__text">Verstuur abonnement aanvraag</p>
                </div>
            </div>
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
