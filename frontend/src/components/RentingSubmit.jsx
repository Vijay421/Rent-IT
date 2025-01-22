import {useState} from "react";
import "../styles/RentingSubmit.css";
import { useNavigate, useLocation } from "react-router-dom";
import {DisplayAutoBox, DisplayCamperBox, DisplayCaravanBox} from "./DisplayVehicleBox.jsx";

function RentingSubmit() {
    const location = useLocation();
    const navigate = useNavigate();
    const vehicleData = location.state?.vehicleData;
    const startDatum = location.state?.startDatum;
    const eindDatum = location.state?.eindDatum;

    const [wettelijkenaam, setWettelijkenaam] = useState("");
    const [adresgegevens, setAdresgegevens] = useState("");
    const [stadgegevens, setStadgegevens] = useState("");
    const [postcodegegevens, setPostcodegegevens] = useState("");
    const [rijbewijsnummer, setRijbewijsnummer] = useState("");
    const [reisaard, setReisaard] = useState("");
    const [verwachteKm, setVerwachteKm] = useState("");
    const [verstePunt, setVerstePunt] = useState("");
    const [startPunt, setStartPunt] = useState("");
    const [eindPunt, setEindPunt] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");

    const userData = {
        naam: wettelijkenaam,
        adres: adresgegevens,
        stad: stadgegevens,
        postcode: postcodegegevens,
        rbwnr: rijbewijsnummer,
        reisaard: reisaard,
        verwachtekm: verwachteKm,
        verstePunt: verstePunt,
        startPunt: startPunt,
        eindPunt: eindPunt,
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
            eindPunt &&

            rijbewijsnummer.match(/^[0-9]+$/) &&
            verwachteKm.match(/^[0-9]+$/)
        ) {
            setConfirmationMessage("");

            navigate('/bevestiging', { state: { vehicleData, userData, startDatum, eindDatum } });
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
        }
    }

    return (
        <main>
            <div className='TopDiv' id='top-div__div'>
                {vehicleData.soort === "Auto" && <DisplayAutoBox data={vehicleData} nieuwStartDatum={startDatum} nieuwEindDatum={eindDatum} huurButtonStatus={false} onHuur={() => {}}/>}
                {vehicleData.soort === "Caravan" && <DisplayCaravanBox data={vehicleData} nieuwStartDatum={startDatum} nieuwEindDatum={eindDatum} huurButtonStatus={false} onHuur={() => {}}/>}
                {vehicleData.soort === "Camper" && <DisplayCamperBox data={vehicleData} nieuwStartDatum={startDatum} nieuwEindDatum={eindDatum} huurButtonStatus={false} onHuur={() => {}}/>}
            </div>

            <div className="SubmitMainDiv">
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
                        minLength='2'
                        maxLength='50'
                        data-cy="name"
                    />

                    <label htmlFor="form__adres-gegevens" className="label">
                        Adres
                    </label>
                    <input
                        id="form__adres-gegevens"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier uw adres gegevens in voor het huren van dit voertuig."
                        value={adresgegevens}
                        onChange={(e) => setAdresgegevens(e.target.value)}
                        maxLength='28'
                        data-cy="address"
                    />

                    <label htmlFor="form__stad-gegevens" className="label">
                        Stad
                    </label>
                    <input
                        id="form__stad-gegevens"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier uw stad in voor het huren van dit voertuig."
                        value={stadgegevens}
                        onChange={(e) => setStadgegevens(e.target.value)}
                        maxLength='16'
                        data-cy="city"
                    />

                    <label htmlFor="form__postcode-gegevens" className="label">
                        Postcode
                    </label>
                    <input
                        id="form__postcode-gegevens"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier uw postcode in voor het huren van dit voertuig."
                        value={postcodegegevens}
                        onChange={(e) => setPostcodegegevens(e.target.value)}
                        maxLength='6'
                        data-cy="zipcode"
                    />

                    <label htmlFor="form__rijbewijs-nummer" className="label">
                        Rijbewijsnummer
                    </label>
                    <input
                        id="form__rijbewijs-nummer"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier uw rijbewijs nummer in voor het huren van dit voertuig."
                        value={rijbewijsnummer}
                        onChange={(e) => setRijbewijsnummer(e.target.value)}
                        maxLength='10'
                        onKeyDown={(e) => {
                            if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight' && e.key !== 'Tab') {
                                e.preventDefault();
                            }
                        }}
                        data-cy="driverid"
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
                        maxLength='100'
                        data-cy="travel-nature"
                    />

                    <label htmlFor="form__verwachte-km" className="label">
                        Verwachte gereden kilometers
                    </label>
                    <input
                        id="form__verwachte-km"
                        className="renting-submit-form"
                        type="text"
                        placeholder="Vul hier in hoeveel kilometer afstand u verwacht af te leggen."
                        value={verwachteKm}
                        onChange={(e) => setVerwachteKm(e.target.value)}
                        minLength='0'
                        maxLength='5'
                        onKeyDown={(e) => {
                            if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight' && e.key !== 'Tab') {
                                e.preventDefault();
                            }
                        }}
                        data-cy="distance"
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
                        maxLength='50'
                        data-cy="furthest-point"
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
                        maxLength='50'
                        data-cy="starting-point"
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
                        maxLength='50'
                        data-cy="end-point"
                    />
                </div>
                {confirmationMessage && (
                    <p className={`confirmation-message ${confirmationMessage === "Uw huuraanvraag is verzonden!" ? "success" : "error"}`}>
                        {confirmationMessage}
                    </p>
                )}

                    <button onClick={handleSubmit} data-cy="submit" className="submit-button__button">Volgende pagina</button>
            </div>
        </main>
    );
}

export default RentingSubmit;
