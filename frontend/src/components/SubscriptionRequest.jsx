import '../styles/SubscriptionRequest.css';
import { useState } from "react";
import styles from "./Profile/ProfilePageBase.module.css";

function SubscriptionRequest() {
    const [bedrijfsnaam, setBedrijfsnaam] = useState("");
    const [adress, setAdress] = useState("");
    const [kvkNumber, setKvkNumber] = useState("");
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

    function handleSubmit() {
        if (
            bedrijfsnaam &&
            adress &&
            kvkNumber &&
            subscriptionType
        ) {
            setConfirmationMessage("Uw abonnementhouders aanvraag is verzonden!");
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
                <label htmlFor="subscription-type" className="form__text">Type Abonnement:</label>
                <div className="radio-group" onChange={handleSubscriptionType}>
                    <label>
                        <input type="radio" id="PayAsYouGo" name="subscriptionType" value="PayAsYouGo" /> Pay as you go
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
