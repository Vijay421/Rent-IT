import styles from "./profile/ProfilePageBase.module.css";
import {useState} from "react";
import "../styles/RentingSubmit.css"

function RentingSubmit() {

    const [wettelijkenaam, setWettelijkenaam] = useState("");
    const [adresgegevens, setAdresgegevens] = useState("");
    const [rijbewijsnummer, setRijbewijsnummer] = useState("");
    const [reisaard, setReisaard] = useState("");
    const [verwachteKm, setVerwachteKm] = useState("");
    const [verstePunt, setVerstePunt] = useState("");
    const [startPunt, setStartPunt] = useState("");
    const [eindPunt, setEindPunt] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");

    function handleWettelijkenaam(e) {
        setWettelijkenaam(e.target.value);
    }

    function handleAdresgegevens(e) {
        setAdresgegevens(e.target.value);
    }

    function handleRijbewijsnummer(e) {
        setRijbewijsnummer(e.target.value);
    }

    function handleReisaard(e) {
        setReisaard(e.target.value);
    }

    function handleVerwachteKm(e) {
        setVerwachteKm(e.target.value);
    }

    function handleVerstePunt(e) {
        setVerstePunt(e.target.value);
    }

    function handleStartPunt(e) {
        setStartPunt(e.target.value);
    }

    function handleEindPunt(e) {
        setEindPunt(e.target.value);
    }

    function handleSubmit() {
        if (wettelijkenaam && adresgegevens && rijbewijsnummer && reisaard && verwachteKm && verstePunt && startPunt && eindPunt) {
            setConfirmationMessage("Uw huur aanvraag is verzonden!");
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
        }
    }

    return (
        <main>
            <div className={styles.MainDiv}>
                <p className="main-div-car">Hier komt de auto.</p>
            </div>

            <div className={styles.MainDiv}>
                <p className="main-div-form__text">Vul hieronder de gegevens in om een abonnement aan te vragen.</p>
                <div className="FormWrapper">
                    <label htmlFor="form__wettelijke-naam" className='label'>Wettelijke naam:</label>
                    <input
                        id="form__wettelijke-naam"
                        className='form'
                        type="text"
                        placeholder="Vul hier uw volledige naam in voor het huren van dit voertuig."
                        value={wettelijkenaam}
                        minLength='2'
                        maxLength='50'
                        onChange={handleWettelijkenaam}
                    />
                    <label htmlFor="form__adres-gegevens" className='label'>Adres gegevens:</label>
                    <input
                        id="form__adres-gegevens"
                        className='form'
                        type="text"
                        placeholder="Vul hier uw adres gegevens in voor het huren van dit voertuig."
                        value={adresgegevens}
                        minLength='2'
                        maxLength='50'
                        onChange={handleAdresgegevens}
                    />
                    <label htmlFor="form__rijbewijs-nummer" className='label'>Rijbewijs nummer:</label>
                    <input
                        id="form__rijbewijs-nummer"
                        className='form'
                        type="text"
                        placeholder="Vul hier uw rijbewijs nummer in voor het huren van dit voertuig."
                        value={rijbewijsnummer}
                        minLength='2'
                        maxLength='50'
                        onChange={handleRijbewijsnummer}
                    />
                    <label htmlFor="form__reisaard" className='label'>Soort reis (??):</label>
                    <input
                        id="form__reisaard"
                        className='form'
                        type="text"
                        placeholder="Vul hier uw reis aard in voor het huren van dit voertuig."
                        value={reisaard}
                        minLength='2'
                        maxLength='50'
                        onChange={handleReisaard}
                    />
                    <label htmlFor="form__verwachte-km" className='label'>Verwachte gereden kilometers:</label>
                    <input
                        id="form__verwachte-km"
                        className='form'
                        type="text"
                        placeholder="Vul hier in hoeveel kilometer afstand u veracht af te leggen."
                        value={verwachteKm}
                        minLength='2'
                        maxLength='50'
                        onChange={handleVerwachteKm}
                    />
                    <label htmlFor="form__verste-punt" className='label'>Verwachte verste punt van de reis:</label>
                    <input
                        id="form__verste-punt"
                        className='form'
                        type="text"
                        placeholder="Vul hier het verste punt in wat u veracht af te leggen."
                        value={verstePunt}
                        minLength='2'
                        maxLength='50'
                        onChange={handleVerstePunt}
                    />
                    <label htmlFor="form__start-punt" className='label'>Start punt van de reis:</label>
                    <input
                        id="form__start-punt"
                        className='form'
                        type="text"
                        placeholder="Vul hier het start punt in van uw reis."
                        value={startPunt}
                        minLength='2'
                        maxLength='50'
                        onChange={handleStartPunt}
                    />
                    <label htmlFor="form__eind-punt" className='label'>Eind punt van de reis:</label>
                    <input
                        id="form__eind-punt"
                        className='form'
                        type="text"
                        placeholder="Vul hier het eind punt in van uw reis."
                        value={eindPunt}
                        minLength='2'
                        maxLength='50'
                        onChange={handleEindPunt}
                    />
                    <p className="price__text">prijs: (??)</p>
                </div>
                {confirmationMessage && (
                    <p className="confirmation-message">{confirmationMessage}</p>
                )}

                <div onClick={handleSubmit} className="submit-button">
                    <div className="submit-button__div">
                        <p className="submit-button__text">Verstuur abonnement aanvraag</p>
                    </div>
                </div>
            </div>
        </main>
    );
}

export default RentingSubmit;