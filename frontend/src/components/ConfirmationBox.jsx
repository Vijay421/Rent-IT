import '../styles/ConfirmationBox.css';
import {useLocation, useNavigate} from "react-router-dom";

export default function ConfirmationBox() {
    const location = useLocation();
    const navigate = useNavigate();
    const { vehicleData, userData, startDatum, eindDatum } = location.state;

    const basePrice = vehicleData.prijs * 4;
    const insurance = vehicleData.soort === "Auto" ? 25.50 * 4 : vehicleData.soort === "Caravan" ? 20 * 4 : 30 * 4;
    const tax = (basePrice) * 0.21;
    const fuel = vehicleData.soort === "Auto" ? 30 : vehicleData.soort === "Caravan" ? 0 : 50;
    const kmCharge = 0.30 * userData.verwachtekm;
    const deposit = vehicleData.soort === "Auto" ? 400 : vehicleData.soort === "Caravan" ? 750 : 1500;
    const totalCost = basePrice + insurance + tax + fuel + kmCharge + deposit;


    function handleAkkoordButtonClick() {
        const statusText = document.getElementById('confirmation-button-box-status__span');

        const payload = {
            id: 0,
            particuliereHuurderId: 1,
            voertuig: {
                id: vehicleData.Id,
                merk: vehicleData.merk,
                type: vehicleData.type,
                kenteken: vehicleData.kenteken,
                kleur: vehicleData.kleur,
                aanschafjaar: vehicleData.aanschafjaar,
                soort: vehicleData.soort,
                opmerking: vehicleData.opmerking,
                status: vehicleData.status,
                prijs: vehicleData.prijs,
                startDatum: vehicleData.startDatum,
                eindDatum: vehicleData.eindDatum,
            },
            startdatum: startDatum,
            einddatum: eindDatum,
            wettelijke_naam: userData.naam,
            adresgegevens: `${userData.adres}, ${userData.postcode} ${userData.stad}`,
            rijbewijsnummer: userData.rbwnr,
            reisaard: userData.reisaard,
            vereiste_bestemming: userData.verstePunt,
            verwachte_km: userData.verwachtekm,
            geaccepteerd: false,
            reden: null,
            veranderDatum: new Date().toJSON(),
            gezien: false,
        };

        fetch("https://localhost:53085/api/Huur", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(payload)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                statusText.style.color = 'green';
                statusText.textContent = 'Uw verzoek is succesvol verzonden.\r\n U wordt nu doorgestuurd naar de betaalpagina.';
                statusText.style.display = 'block';
                setTimeout(() => {
                    navigate("/payment", data);
                },3000);
            })
            .catch(error => {
                console.error(error);
                statusText.style.color = 'red';
                statusText.textContent = 'Uw verzoek kon niet worden verzonden. Probeer het later opnieuw.';
                statusText.style.display = 'block';
            });
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

                            <p>Start punt:</p>
                            <p>{userData.startPunt}</p>

                            <p>Eind punt:</p>
                            <p>{userData.eindPunt}</p>

                            <p>Reisaard:</p>
                            <p>{userData.reisaard}</p>

                            <p>Verste bestemming:</p>
                            <p>{userData.verstePunt}</p>

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
                                <p>€ {vehicleData.prijs}</p>

                                <p>Verzekering:</p>
                                {vehicleData.soort === "Auto" && <p>€ 25,50 / dag</p>}
                                {vehicleData.soort === "Caravan" && <p>€ 20 / dag</p>}
                                {vehicleData.soort === "Camper" && <p>€ 30 / dag</p>}

                                <p>Belasting:</p>
                                <p>€ {((vehicleData.prijs * 4) * 0.21).toFixed(2)}</p>

                                <p>Benzine:</p>
                                {vehicleData.soort === "Auto" && <p>€ 30</p>}
                                {vehicleData.soort === "Caravan" && <p>€ 0</p>}
                                {vehicleData.soort === "Camper" && <p>€ 50</p>}

                                <p>Km vergoeding:</p>
                                <p>€ 0.30 / km</p>

                                <p>Borg:</p>
                                {vehicleData.soort === "Auto" && <p>€ 400</p>}
                                {vehicleData.soort === "Caravan" && <p>€ 750</p>}
                                {vehicleData.soort === "Camper" && <p>€ 1500</p>}
                            </div>

                            <div className="voertuig-box-column3__div">
                                <p className='voertuig-box-column3-title1-paragraph__p'>Huurperiode</p>
                                <p className='voertuig-box-column3-title2-paragraph__p'>Totale kosten</p>
                            </div>
                            <div className="voertuig-box-column4__div">
                                <p className='voertuig-box-column3-answer1-paragraph__p'>{startDatum} – {eindDatum}</p>
                                <p className='voertuig-box-column3-answer2-paragraph__p'>
                                    € {totalCost.toFixed(2)}
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div className="confirmation-page-button-box__div">
                <h3 className='confirmation-button-box__h3'>Ik (huurder) bevestig hierbij dat alle hierboven weergegeven gegevens correct zijn en ga akkoord met het verzenden van dit verzoek en het openen van de betaalpagina.</h3>
                <button onClick={handleAkkoordButtonClick} className='confirmation-button-box__button'>Akkoord</button>
                <span id='confirmation-button-box-status__span'></span>
            </div>
        </div>
    );
}