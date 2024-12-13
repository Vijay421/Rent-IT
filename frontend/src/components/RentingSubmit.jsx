import styles from "./profile/ProfilePageBase.module.css";
import { useState } from "react";
import "../styles/RentingSubmit.css";
import { useNavigate, useLocation } from "react-router-dom";
import { RentalAutoBox } from "./RentalVehicleBox.jsx";

function RentingSubmit() {
    const location = useLocation();
    const navigate = useNavigate();
    const vehicleData = location.state?.vehicleData;

    const [wettelijkenaam, setWettelijkenaam] = useState("");
    const [adresgegevens, setAdresgegevens] = useState("");
    const [rijbewijsnummer, setRijbewijsnummer] = useState("");
    const [reisaard, setReisaard] = useState("");
    const [verwachteKm, setVerwachteKm] = useState("");
    const [verstePunt, setVerstePunt] = useState("");
    const [startPunt, setStartPunt] = useState("");
    const [eindPunt, setEindPunt] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");

    const userData = {
        wettelijkenaam,
        adresgegevens,
        rijbewijsnummer,
        reisaard,
        verwachteKm,
        verstePunt,
        startPunt,
        eindPunt,
    };

    function handleSubmit() {
        if (
            wettelijkenaam &&
            adresgegevens &&
            rijbewijsnummer &&
            reisaard &&
            verwachteKm &&
            verstePunt &&
            startPunt &&
            eindPunt
        ) {
            setConfirmationMessage("");

            navigate('/confirmation', { state: { vehicleData, userData } });
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
        }
    }

    return (
        <main>
            <div className={styles.TopDiv} id='top-div__div'>
                {vehicleData.soort === "Auto" && <RentalAutoBox data={vehicleData} />}
                {vehicleData.soort === "Caravan" && <RentalAutoBox data={vehicleData} />}
                {vehicleData.soort === "Camper" && <RentalAutoBox data={vehicleData} />}
            </div>

            <div className={styles.MainDiv}>
                <h1 className="main-div-form__text">
                    Vul hieronder de gegevens in om een abonnement aan te vragen.
                </h1>
                <div className="FormWrapper">
                    <label htmlFor="form__wettelijke-naam" className="label">
                        Wettelijke naam
                    </label>
                    <input
                        id="form__wettelijke-naam"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier uw volledige naam in voor het huren van dit voertuig."
                        value={wettelijkenaam}
                        onChange={(e) => setWettelijkenaam(e.target.value)}
                    />
                    <label htmlFor="form__adres-gegevens" className="label">
                        Adres gegevens
                    </label>
                    <input
                        id="form__adres-gegevens"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier uw adres gegevens in voor het huren van dit voertuig."
                        value={adresgegevens}
                        onChange={(e) => setAdresgegevens(e.target.value)}
                    />
                    <label htmlFor="form__rijbewijs-nummer" className="label">
                        Rijbewijs nummer
                    </label>
                    <input
                        id="form__rijbewijs-nummer"
                        className="renting-submit-form"
                        type="number"
                        placeholder="Vul hier uw rijbewijs nummer in voor het huren van dit voertuig."
                        value={rijbewijsnummer}
                        onChange={(e) => setRijbewijsnummer(e.target.value)}
                    />
                    <label htmlFor="form__reisaard" className="label">
                        Soort reis
                    </label>
                    <input
                        id="form__reisaard"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier uw reis aard in voor het huren van dit voertuig."
                        value={reisaard}
                        onChange={(e) => setReisaard(e.target.value)}
                    />
                    <label htmlFor="form__verwachte-km" className="label">
                        Verwachte gereden kilometers
                    </label>
                    <input
                        id="form__verwachte-km"
                        className="renting-submit-form"
                        type="number"
                        placeholder="Vul hier in hoeveel kilometer afstand u verwacht af te leggen."
                        value={verwachteKm}
                        onChange={(e) => setVerwachteKm(e.target.value)}
                    />
                    <label htmlFor="form__verste-punt" className="label">
                        Verwachte verste punt van de reis
                    </label>
                    <input
                        id="form__verste-punt"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier het verste punt in wat u verwacht af te leggen."
                        value={verstePunt}
                        onChange={(e) => setVerstePunt(e.target.value)}
                    />
                    <label htmlFor="form__start-punt" className="label">
                        Start punt van de reis
                    </label>
                    <input
                        id="form__start-punt"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier het start punt in van uw reis."
                        value={startPunt}
                        onChange={(e) => setStartPunt(e.target.value)}
                    />
                    <label htmlFor="form__eind-punt" className="label">
                        Eind punt van de reis
                    </label>
                    <input
                        id="form__eind-punt"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier het eind punt in van uw reis."
                        value={eindPunt}
                        onChange={(e) => setEindPunt(e.target.value)}
                    />
                </div>
                {confirmationMessage && (
                    <p className={`confirmation-message ${confirmationMessage === "Uw huuraanvraag is verzonden!" ? "success" : "error"}`}>
                        {confirmationMessage}
                    </p>
                )}

                <div className="submit-button">
                    <button onClick={handleSubmit} className="submit-button__button">Volgend pagina</button>
                </div>
            </div>
        </main>
    );
}

export default RentingSubmit;
