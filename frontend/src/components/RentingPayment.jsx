import styles from "./profile/ProfilePageBase.module.css";
import { useState } from "react";
import "../styles/RentingPayment.css";
import {useLocation} from "react-router-dom";

function RentingSubmit() {
    const location = useLocation();
    const vehicle = location.state.vehicle;
    const user = location.state.user;
    const [subscriptionType, setSubscriptionType] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");

    function handleSubscriptionType(e) {
        setSubscriptionType(e.target.value);
    }

    function handleSubmit() {
        if (
            subscriptionType
        ) {
            alert("payment SaaS");
            setConfirmationMessage("Uw confirmatie e-mail met het betalingsoverzicht wordt binnen enkele minuten verzonden!");
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
        }
    }

    return (
        <main>
            <div className='MainDiv'>
                <h1 className="main-div-form__text">Kies uw betaalmiddel.</h1>
                <div className="FormWrapper">
                    <label htmlFor="subscription-type" className="form__text">Type Abonnement:</label>
                    <div className="radio-group" onChange={handleSubscriptionType}>
                        <label>
                            <input type="radio" id="PayAsYouGo" name="subscriptionType" value="PayAsYouGo"/> Pay-as-you-go
                        </label>
                        <label>
                            <input type="radio" id="Prepaid" name="subscriptionType" value="prepaid"/> Prepaid
                        </label>
                    </div>
                </div>

                <button onClick={handleSubmit} className="submit-button">
                    Rond uw betaling af
                </button>

                {confirmationMessage && (
                    <p
                        className={`payment-confirmation-message ${
                            confirmationMessage === "Uw confirmatie e-mail met het betalingsoverzicht wordt binnen enkele minuten verzonden!"
                                ? "success"
                                : "error"
                        }`}
                    >
                        {confirmationMessage}
                    </p>
                )}
            </div>
        </main>
    );
}

export default RentingSubmit;