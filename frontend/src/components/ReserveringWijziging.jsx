import '../styles/ReserveringWijziging.css';
import {useEffect, useRef, useState} from "react";
import {useLocation} from "react-router-dom";
import {DisplayAutoBox, DisplayCamperBox, DisplayCaravanBox} from "./DisplayVehicleBox.jsx";

export default function ReserveringWijziging() {
    const location = useLocation();
    const userData = location.state?.user || {};
    const [selectedVehicle, setSelectedVehicle] = useState(null);
    const [vehicles, setVehicles] = useState([]);
    const [wettelijkeNaam, setWettelijkenaam] = useState(userData.wettelijke_naam);
    const [adresGegevens, setAdresGegevens] = useState(userData.adresgegevens);
    const [reisAard, setReisAard] = useState(userData.reisaard);
    const [verwachteKm, setVerwachteKm] = useState(userData?.verwachte_km || 0);
    const [versteBestemming, setVersteBestemming] = useState(userData.vereiste_bestemming);
    const [startDatum, setStartDatum] = useState(userData.startdatum);
    const [eindDatum, setEindDatum] = useState(userData.einddatum);

    const amountOfDays = isNaN(new Date(startDatum)) || isNaN(new Date(eindDatum)) ? 0 : Math.floor((new Date(eindDatum) - new Date(startDatum)) / (1000 * 60 * 60 * 24));

    const carPrice = selectedVehicle ? selectedVehicle.prijs * amountOfDays : 0;
    const insurance = selectedVehicle
        ? (selectedVehicle.soort === "Auto"
            ? 15.50 * amountOfDays
            : selectedVehicle.soort === "Caravan"
                ? 22 * amountOfDays
                : 0)
        : 0;
    const fuel = selectedVehicle
        ? (selectedVehicle.soort === "Auto"
            ? 50
            : selectedVehicle.soort === "Caravan"
                ? 0
                : 100)
        : 0;
    const kmCharge = 0.23 * (verwachteKm || 0);
    const deposit = selectedVehicle
        ? (selectedVehicle.soort === "Auto"
            ? 400
            : selectedVehicle.soort === "Caravan"
                ? 750
                : 1500)
        : 0;
    const tax = (carPrice + insurance + kmCharge) * 0.21;
    const korting = 0; // Placeholder for future implementation
    const totalCost = carPrice + insurance + fuel + kmCharge + deposit + tax - korting;

    const form = useRef(null);

    useEffect(() => {
        fetchVehicles();
    }, []);

    useEffect(() => {
        const initialVehicle = vehicles.find(vehicle => vehicle.id === userData.voertuigId);
        setSelectedVehicle(initialVehicle);
    }, [vehicles]);

    async function fetchVehicles() {
        try {
            const response = await fetch('https://localhost:53085/api/Voertuig', {
                method: 'GET',
                credentials: 'include',
                headers: {
                    'content-type': 'application/json',
                },
            });
            const data = await response.json();
            setVehicles(data);
        } catch (e) {
            console.error(e);
        }
    }

    function handleVehicleHuurButtonClick(vehicle) {
        console.log(vehicle);
        setSelectedVehicle(vehicle);
        document.getElementById("wijziging-voertuigen-list__div").style.display = 'none';
        document.getElementById("wijziging-voertuig-kosten__div").style.display = 'flex';
    }

    function handleCarChangeButtonClick() {
        document.getElementById("wijziging-voertuigen-list__div").style.display = 'flex';
        document.getElementById("wijziging-voertuig-kosten__div").style.display = 'none';
    }

    function handleFormSubmit() {
        if (!form.current.checkValidity()) {
            console.log("not valid");
            return;
        }

        const payload = {
            id: userData.id,
            particuliereHuurderId: userData.particuliereHuurderId,
            voertuigId: selectedVehicle.id,
            startdatum: startDatum,
            einddatum: eindDatum,
            wettelijke_naam: wettelijkeNaam,
            adresgegevens: adresGegevens,
            rijbewijsnummer: userData.rijbewijsnummer,
            reisaard: reisAard,
            vereiste_bestemming: versteBestemming,
            verwachte_km: verwachteKm,
            geaccepteerd: null,
            reden: null,
            veranderDatum: new Date().toJSON(),
            gezien: false,
        };

        try {
            fetch(`https://localhost:53085/api/Huur/${userData.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(payload),
            });
        } catch (e) {
            console.error(e);
        }
    }

    return (
        <>
            <div className='wijziging-page-container__div'>
                <h1 className='form-box-title__h1'>Reservering wijzigen</h1>

                <div className="wijziging-page-voertuig-box__div">
                    {selectedVehicle && (
                        selectedVehicle.soort === "Auto" ? (
                            <DisplayAutoBox data={selectedVehicle} huurButtonStatus={false} onHuur={() => {
                            }}/>
                        ) : selectedVehicle.soort === "Caravan" ? (
                            <DisplayCaravanBox data={selectedVehicle} huurButtonStatus={false} onHuur={() => {
                            }}/>
                        ) : (
                            <DisplayCamperBox data={selectedVehicle} huurButtonStatus={false} onHuur={() => {
                            }}/>
                        )
                    )}
                </div>

                <div className="wijziging-page-form-box__div">
                    <form ref={form} className='wijziging-form' onSubmit={(e) => e.preventDefault()}>
                        <div className='wijziging-fields'>
                            <label htmlFor="wettelijke-naam__form">
                                Wettelijke naam
                            </label>
                            <input
                                type="text"
                                className='wettelijke-form__input'
                                id='wettelijke-naam__form'
                                placeholder='Vul hier uw volledige naam in'
                                value={wettelijkeNaam}
                                onChange={(e) => setWettelijkenaam(e.target.value)}
                            />
                        </div>

                        <div className='wijziging-fields'>
                            <label htmlFor="adres-gegevens__form">
                                Adres gegevens
                            </label>
                            <input type="text"
                                   className='wettelijke-form__input'
                                   id='adres-gegevens__form'
                                   placeholder='Vul hier uw adres gegevens in ((Adres), (Postcode) (Stad)'
                                   value={adresGegevens}
                                   onChange={(e) => setAdresGegevens(e.target.value)}
                            />
                        </div>

                        <div className='wijziging-fields'>
                            <label htmlFor="reisaard__form">
                                Reisaard
                            </label>
                            <input type="text"
                                   className='wettelijke-form__input'
                                   id='reisaard__form'
                                   placeholder='Vul hier uw reis aard in'
                                   value={reisAard}
                                   onChange={(e) => setReisAard(e.target.value)}
                            />
                        </div>

                        <div className='wijziging-fields'>
                            <label htmlFor="verwachte-gereden-km__form">
                                Verwachte gereden km
                            </label>
                            <input type="number"
                                   className='wettelijke-form__input'
                                   id='verwachte-gereden-km__form'
                                   placeholder='Vul hier in hoeveel kilometer afstand u verwacht af te leggen'
                                   value={verwachteKm}
                                   onChange={(e) => setVerwachteKm(e.target.value)}
                            />
                        </div>

                        <div className='wijziging-fields'>
                            <label htmlFor="verste-bestemming__form">
                                Verste bestemming
                            </label>
                            <input type="text"
                                   className='wettelijke-form__input'
                                   id='verste-bestemming__form'
                                   placeholder='Vul hier het verste punt in wat u verwacht af te leggen'
                                   value={versteBestemming}
                                   onChange={(e) => setVersteBestemming(e.target.value)}
                            />
                        </div>


                        <div className="datum-fields__div">
                            <div className="start-datum-field">
                                <label htmlFor="start-datum__form">
                                    Start datum
                                </label>
                                <input type="date"
                                       className='datum-fields__input'
                                       id='start-datum__form'
                                       value={startDatum}
                                       onChange={(e) => setStartDatum(e.target.value)}
                                />
                            </div>
                            <div className="eind-datum-field">
                                <label htmlFor="eind-datum__form">
                                    Eind datum
                                </label>
                                <input type="date"
                                       className='datum-fields__input'
                                       id='eind-datum__form'
                                       value={eindDatum}
                                       onChange={(e) => setEindDatum(e.target.value)}
                                />
                            </div>
                        </div>
                    </form>

                    <div className="wijziging-page-action-buttons__div">
                        <button onClick={handleCarChangeButtonClick} className='form-box-submit__button'>Kies een andere
                            auto
                        </button>
                        <button onClick={handleFormSubmit} className='form-box-submit__button'>Gegevens opslaan</button>
                    </div>
                </div>
            </div>


            <div id='wijziging-voertuigen-list__div'>
                {vehicles
                    .filter(vehicle => vehicle.id !== (selectedVehicle?.id || userData.voertuigId))
                    .map(vehicle => (
                        vehicle.soort === "Auto" ? (
                            <DisplayAutoBox
                                key={vehicle.id}
                                data={vehicle}
                                huurButtonStatus={true}
                                onHuur={() => handleVehicleHuurButtonClick(vehicle)}
                            />
                        ) : vehicle.soort === "Caravan" ? (
                            <DisplayCaravanBox
                                key={vehicle.id}
                                data={vehicle}
                                huurButtonStatus={true}
                                onHuur={() => handleVehicleHuurButtonClick(vehicle)}
                            />
                        ) : (
                            <DisplayCamperBox
                                key={vehicle.id}
                                data={vehicle}
                                huurButtonStatus={true}
                                onHuur={() => handleVehicleHuurButtonClick(vehicle)}
                            />
                        )
                    ))}
            </div>


            <div id="wijziging-voertuig-kosten__div">
                <h1 className='voertuig-kosten-title__h1'>Kosten</h1>

                <div className="voertuig-kosten-box__div">
                        {selectedVehicle ? (
                            <>
                                <div className='voertuig-box-column2__div'>
                                    <p>Huurprijs:</p>
                                    <p>€ {(amountOfDays * selectedVehicle.prijs).toFixed(2)} ({amountOfDays} x
                                        € {selectedVehicle.prijs})</p>

                                    <p>Verzekering:</p>
                                    {selectedVehicle.soort === "Auto" &&
                                        <p>€ {(amountOfDays * 15.50).toFixed(2)} ({amountOfDays} x € 15.50)</p>}
                                    {selectedVehicle.soort === "Caravan" &&
                                        <p>€ {amountOfDays * 22} ({amountOfDays} x € 22)</p>}
                                    {selectedVehicle.soort === "Camper" && <p>€ 0 (Eigen verzekering)</p>}

                                    <p>Belasting:</p>
                                    <p>€ {tax.toFixed(2)} (21%)</p>

                                    <p>Km vergoeding:</p>
                                    <p>€ {(0.23 * userData.verwachte_km).toFixed(2)} (€ 0.23
                                        / {userData.verwachte_km} km)</p>

                                    <p>Borg:</p>
                                    {selectedVehicle.soort === "Auto" && <p>€ 400*</p>}
                                    {selectedVehicle.soort === "Caravan" && <p>€ 750*</p>}
                                    {selectedVehicle.soort === "Camper" && <p>€ 1500*</p>}

                                    <p>Benzine:</p>
                                    {selectedVehicle.soort === "Auto" && <p>€ 50**</p>}
                                    {selectedVehicle.soort === "Caravan" && <p>€ 0</p>}
                                    {selectedVehicle.soort === "Camper" && <p>€ 100**</p>}

                                    <p>Korting:</p>
                                    <p>€ 0</p>
                                </div>

                                <div className="voertuig-box-column3__div">
                                    <div className="voertuig-box-row">
                                        <p>*</p>
                                        <p>De borgsom wordt terugbetaald als het voertuig in dezelfde staat wordt
                                            teruggebracht als waarin het is ontvangen.</p>
                                    </div>
                                    <div className="voertuig-box-row">
                                        <p>**</p>
                                        <p>De brandstofkosten worden terugbetaald als het voertuig met een volle tank
                                            wordt ingeleverd.</p>
                                    </div>
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
                            </>
                        ) : (
                            <p>An error has occurred</p>
                        )}
                </div>
            </div>
        </>
    );
}