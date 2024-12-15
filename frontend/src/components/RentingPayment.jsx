import styles from "./profile/ProfilePageBase.module.css";
import { useState } from "react";
import "../styles/RentingPayment.css";

function RentingSubmit() {

    const [subscriptionType, setSubscriptionType] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");

    function handleSubscriptionType(e) {
        setSubscriptionType(e.target.value);
    }

    function handleSubmit() {
        if (
            subscriptionType
        ) {
            setConfirmationMessage("Uw confirmatie e-mail met het betalingsoverzicht wordt binnen enkele minuten verzonden!");
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
        }
    }

    return (
        <main>
            <div className={styles.MainDiv}>
                <p className="main-div-form__text">Kies uw betaalmiddel.</p>
                <div className="FormWrapper">
                    <label htmlFor="subscription-type" className="form__text">Type Abonnement:</label>
                    <div className="radio-group" onChange={handleSubscriptionType}>
                        <label>
                            <input type="radio" id="PayAsYouGo" name="subscriptionType" value="PayAsYouGo"/> Pay as you
                            go
                        </label>
                        <label>
                            <input type="radio" id="Prepaid" name="subscriptionType" value="prepaid"/> Prepaid
                        </label>
                    </div>
                </div>
                {confirmationMessage && (
                    <p
                        className={`confirmation-message ${
                            confirmationMessage === "Uw confirmatie e-mail met het betalingsoverzicht wordt binnen enkele minuten verzonden!"
                                ? "success"
                                : "error"
                        }`}
                    >
                        {confirmationMessage}
                    </p>
                )}
                <div onClick={handleSubmit} className="submit-button">
                    <div className="submit-button__div">
                        <p className="submit-button__text">Rond uw betaling af</p>
                    </div>
                </div>
            </div>
        </main>
    );
}

export default RentingSubmit;