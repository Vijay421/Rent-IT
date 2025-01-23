import { useState } from "react";
import "../styles/RentingPayment.css";
import {useLocation} from "react-router-dom";

function RentingSubmit() {
    const location = useLocation();
    const { vehicleData, userData, startDatum, eindDatum } = location.state;
    const [checkboxCheck, setCheckboxCheck] = useState(false);
    const [confirmationMessage, setConfirmationMessage] = useState("");

    const amountOfDays = Math.floor((new Date(eindDatum) - new Date(startDatum)) / (1000 * 60 * 60 * 24));

    const carPrice = vehicleData.prijs * amountOfDays;
    const insurance = vehicleData.soort === "Auto" ? 15.50 * amountOfDays : vehicleData.soort === "Caravan" ? 22 * amountOfDays : 0;
    const fuel = vehicleData.soort === "Auto" ? 50 : vehicleData.soort === "Caravan" ? 0 : 100;
    const kmCharge = 0.23 * userData.verwachtekm;
    const deposit = vehicleData.soort === "Auto" ? 400 : vehicleData.soort === "Caravan" ? 750 : 1500;
    const tax = (carPrice + insurance + kmCharge) * 0.21;
    const korting = 0; /*utilize later after adding korting column*/
    const totalCost = carPrice + insurance + fuel + kmCharge + deposit + tax - korting;

    function handleCheckboxChange(e) {
        setCheckboxCheck(e.target.checked);
    }

    function handleSubmit() {
        if (checkboxCheck) {
            alert("payment SaaS");
            setConfirmationMessage("Uw confirmatie e-mail met het betalingsoverzicht wordt binnen enkele minuten verzonden!");
        } else {
            setConfirmationMessage("U moet akkoord gaan met de kosten voordat u kunt betalen.");
        }
    }

    return (
        <main>
            <div className='MainDiv'>
                <h1 className="main-div-form__text">Betalen</h1>

                <div className='betalen-pagina-data-containers__div'>
                    <div className="betalen-pagina-data-container__div">
                        <p>Huurprijs:</p>
                        <p>€ {amountOfDays * vehicleData.prijs} ({amountOfDays} x € {vehicleData.prijs})</p>
                    </div>

                    <div className="betalen-pagina-data-container__div">
                        <p>Verzekering:</p>
                        {vehicleData.soort === "Auto" &&
                            <p>€ {amountOfDays * 15.50} ({amountOfDays} x € 15.50)</p>}
                        {vehicleData.soort === "Caravan" &&
                            <p>€ {amountOfDays * 22} ({amountOfDays} x € 22)</p>}
                        {vehicleData.soort === "Camper" && <p>€ 0 (Eigen verzekering)</p>}
                    </div>

                    <div className="betalen-pagina-data-container__div">
                        <p>Belasting:</p>
                        <p>€ {tax.toFixed(2)} (21%)</p>
                    </div>

                    <div className="betalen-pagina-data-container__div">
                        <p>Km vergoeding:</p>
                        <p>€ {(0.23 * userData.verwachtekm).toFixed(2)} (€ 0.23 / {userData.verwachtekm} km)</p>
                    </div>

                    <div className="betalen-pagina-data-container__div">
                        <p>Borg:</p>
                        {vehicleData.soort === "Auto" && <p>€ 400*</p>}
                        {vehicleData.soort === "Caravan" && <p>€ 750*</p>}
                        {vehicleData.soort === "Camper" && <p>€ 1500*</p>}
                    </div>

                    <div className="betalen-pagina-data-container__div">
                        <p>Benzine:</p>
                        {vehicleData.soort === "Auto" && <p>€ 50**</p>}
                        {vehicleData.soort === "Caravan" && <p>€ 0</p>}
                        {vehicleData.soort === "Camper" && <p>€ 100**</p>}
                    </div>

                    <div className="betalen-pagina-data-container__div">
                        <p>Korting:</p>
                        <p>€ 0</p>
                    </div>
                </div>

                <div className="betalen-periode-en-kosten__div">
                    <div className="betalen-huurperiode__div">
                        <p>Huurperiode:</p>
                        <p>{startDatum} - {eindDatum}</p>
                    </div>

                    <div className="betalen-totale-kosten__div">
                        <p>Totaal:</p>
                        <p>€ {totalCost.toFixed(2)}</p>
                    </div>
                </div>

                <div className="payment-akkord-container__div">
                    <input id='akkord-input' type="checkbox" checked={checkboxCheck} onChange={handleCheckboxChange}></input>

                    <label htmlFor="akkord-input" id='akkord-label'>Ik ga akkoord met de bovenstaande kosten en ga akkoord dat ik word doorgestuurd naar een betaalservice om de kosten te betalen.</label>
                </div>

                <button onClick={handleSubmit} className="payment-submit-button">
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