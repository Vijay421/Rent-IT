import '../styles/ConfirmationBox.css';
import {useLocation} from "react-router-dom";

export default function ConfirmationBox() {
    const location = useLocation();
    const { vehicleData, userData, startDatum, eindDatum } = location.state;

    const amountOfDays = Math.floor((new Date(eindDatum) - new Date(startDatum)) / (1000 * 60 * 60 * 24));

    const carPrice = vehicleData.prijs * amountOfDays;
    const insurance = vehicleData.soort === "Auto" ? 15.50 * amountOfDays : vehicleData.soort === "Caravan" ? 22 * amountOfDays : 0;
    const fuel = vehicleData.soort === "Auto" ? 50 : vehicleData.soort === "Caravan" ? 0 : 100;
    const kmCharge = 0.23 * userData.verwachtekm;
    const deposit = vehicleData.soort === "Auto" ? 400 : vehicleData.soort === "Caravan" ? 750 : 1500;
    const tax = (carPrice + insurance + kmCharge) * 0.21;
    const korting = 0; /*utilize later after adding korting column*/
    const totalCost = carPrice + insurance + fuel + kmCharge + deposit + tax - korting;


    async function handleAkkoordButtonClick() {
        const statusText = document.getElementById('confirmation-button-box-status__span');

        const payload = {
            id: 0, /*huuraanvraag id*/
            //particuliereHuurderId: 1, /*has to be modified later so store the current users account Id*/
            voertuigId: vehicleData.id, /*selected vehicles id*/
            startdatum: startDatum,
            einddatum: eindDatum,
            wettelijke_naam: userData.naam,
            adresgegevens: `${userData.adres}, ${userData.postcode} ${userData.stad}`,
            rijbewijsnummer: userData.rbwnr,
            reisaard: userData.reisaard,
            vereiste_bestemming: userData.verstePunt,
            verwachte_km: userData.verwachtekm,
            geaccepteerd: null,
            reden: null,
            veranderDatum: new Date().toJSON(),
            gezien: false,
        };

        try {
            const response = await fetch("https://localhost:53085/api/Huur", {
                method: "POST",
                // TODO: change to 'same-origin' when in production.
                credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(payload),
            });

            if (response.ok) {
                statusText.style.color = 'green';
                statusText.textContent = 'Uw verzoek is succesvol verzonden.\r\n U wordt nu doorgestuurd naar de betaalpagina.';
                statusText.style.display = 'block';

                // setTimeout(() => {
                    // TODO: redirect to the page with it exists.
                    // navigate("/betaling", data);
                // },3000);
            } else {
                const errorMsg = await response.text();
                statusText.style.color = 'red';
                statusText.textContent = `Error tijdens het versturen: ${errorMsg}`;
                statusText.style.display = 'block';
            }
        } catch {
            statusText.style.color = 'red';
            statusText.textContent = 'Uw verzoek kon niet worden verzonden. Probeer het later opnieuw.';
            statusText.style.display = 'block';
        }
    }

    return (
        <div className='confirmation-page-box__div'>
            <div className='confirmation-page-main__div'>
                <h1 className='confirmation-main-title__h1'>Bevestigingspagina</h1>
                <h2 className='confirmation-main-title__h2'>Controleer of alle onderstaande informatie correct is</h2>

                <div className="confirmation-main-boxes__div">
                    <div className='confirmation-main-renter-box__div'>
                        <h3 className='renter-box-title__h2'>Huurder</h3>

                        <div className="renter-box-column__div">
                            <p>Klant naam: </p>
                            <p>{userData.naam}</p>

                            <p>Huisadres:</p>
                            <p>{userData.adres}</p>

                            <p>Stad:</p>
                            <p>{userData.stad}</p>

                            <p>Postcode:</p>
                            <p>{userData.postcode}</p>

                            <p>Rijbewijsnummer:</p>
                            <p>{userData.rbwnr}</p>

                            <p>Reisaard:</p>
                            <p>{userData.reisaard}</p>

                            <p>Start punt:</p>
                            <p>{userData.startPunt}</p>

                            <p>Eind punt:</p>
                            <p>{userData.eindPunt}</p>

                            <p>Verste bestemming:</p>
                            <p>{userData.verstePunt}</p>

                            <p>Aantal dagen:</p>
                            <p>{amountOfDays} dagen</p>

                            <p>Verwachte gereden km:</p>
                            <p>{userData.verwachtekm} km</p>
                        </div>
                    </div>

                    <div className='confirmation-main-voertuig-box__div'>
                        <h3 className='voertuig-box-title__h2'>Voertuig</h3>

                        <div className='voertuig-box-columns__div'>
                            <div className='voertuig-box-column1__div'>
                                <p>Merk:</p>
                                <p>{vehicleData.merk}</p>

                                <p>Model:</p>
                                <p>{vehicleData.type}</p>


                                <p>Kenteken:</p>
                                <p>{vehicleData.kenteken}</p>


                                <p>Kleur:</p>
                                <p>{vehicleData.kleur}</p>


                                <p>Aanschafjaar:</p>
                                <p>{vehicleData.aanschafjaar}</p>

                            </div>

                            <div className='voertuig-box-column2__div'>
                                <p>Huurprijs:</p>
                                <p>€ {amountOfDays * vehicleData.prijs} ({amountOfDays} x € {vehicleData.prijs})</p>

                                <p>Verzekering:</p>
                                {vehicleData.soort === "Auto" &&
                                    <p>€ {amountOfDays * 15.50} ({amountOfDays} x € 15.50)</p>}
                                {vehicleData.soort === "Caravan" &&
                                    <p>€ {amountOfDays * 22} ({amountOfDays} x € 22)</p>}
                                {vehicleData.soort === "Camper" && <p>€ 0 (Eigen verzekering)</p>}

                                <p>Belasting:</p>
                                <p>€ {tax.toFixed(2)} (21%)</p>

                                <p>Km vergoeding:</p>
                                <p>€{(0.23 * userData.verwachtekm).toFixed(2)} (0.23 / {userData.verwachtekm} km)</p>

                                <p>Borg:</p>
                                {vehicleData.soort === "Auto" && <p>€ 400*</p>}
                                {vehicleData.soort === "Caravan" && <p>€ 750*</p>}
                                {vehicleData.soort === "Camper" && <p>€ 1500*</p>}

                                <p>Benzine:</p>
                                {vehicleData.soort === "Auto" && <p>€ 50**</p>}
                                {vehicleData.soort === "Caravan" && <p>€ 0</p>}
                                {vehicleData.soort === "Camper" && <p>€ 100**</p>}

                                <p>Korting:</p>
                                <p>€ 0</p>
                            </div>

                            <div className="voertuig-box-column3__div">
                                <p>* De borgsom wordt terugbetaald als het voertuig in dezelfde staat wordt
                                    teruggebracht als waarin het is ontvangen.</p>
                                <p>** De brandstofkosten worden terugbetaald als het voertuig met een volle tank wordt
                                    ingeleverd.</p>
                            </div>

                            <div className="voertuig-box-column4__div">
                                <p className='voertuig-box-column4-title1-paragraph__p'>Huurperiode</p>
                                <p className='voertuig-box-column4-title2-paragraph__p'>Totale kosten</p>
                            </div>

                            <div className="voertuig-box-column5__div">
                                <p className='voertuig-box-column5-answer1-paragraph__p'>{startDatum} – {eindDatum}</p>
                                <p className='voertuig-box-column5-answer2-paragraph__p'>
                                    € {totalCost.toFixed(2)}
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div className="confirmation-page-button-box__div">
                <h3 className='confirmation-button-box__h3'>Ik (huurder) bevestig hierbij dat alle hierboven weergegeven
                    gegevens correct zijn en ga akkoord met het verzenden van dit verzoek en het openen van de
                    betaalpagina.</h3>
                <button onClick={handleAkkoordButtonClick} data-cy="confirm" className='confirmation-button-box__button'>Akkoord</button>
                <span id='confirmation-button-box-status__span'></span>
            </div>
        </div>
    );
}