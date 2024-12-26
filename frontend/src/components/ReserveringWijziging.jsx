import '../styles/ReserveringWijziging.css';
import {useEffect, useRef, useState} from "react";
import {useLocation} from "react-router-dom";
import {DisplayAutoBox, DisplayCamperBox, DisplayCaravanBox} from "./DisplayVehicleBox.jsx";

export default function ReserveringWijziging() {
    const location = useLocation();
    const userData = location.state?.user;
    const [selectedVehicle, setSelectedVehicle] = useState(null);
    const [vehicles, setVehicles] = useState([]);
    const [wettelijkeNaam, setWettelijkenaam] = useState(userData.wettelijke_naam);
    const [adresGegevens, setAdresGegevens] = useState(userData.adresgegevens);
    const [reisAard, setReisAard] = useState(userData.reisaard);
    const [verwachteKm, setVerwachteKm] = useState(userData.verwachte_km);
    const [versteBestemming, setVersteBestemming] = useState(userData.vereiste_bestemming);
    const [startDatum, setStartDatum] = useState(userData.startdatum);
    const [eindDatum, setEindDatum] = useState(userData.einddatum);

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
        setSelectedVehicle(vehicle);
        document.getElementById("wijziging-voertuigen-list__div").style.display = 'none';
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

    function handleCarChangeButtonClick() {
        document.getElementById("wijziging-voertuigen-list__div").style.display = 'flex';
    }

    return (
        <>
            <div className='wijziging-page-container__div'>
                <h1 className='form-box-title__h1'>Reservering wijzigen</h1>

                <div className="wijziging-page-voertuig-box__div">
                    {selectedVehicle && (
                        selectedVehicle.soort === "Auto" ? (
                            <DisplayAutoBox data={selectedVehicle} huurButtonStatus={false} onHuur={() => {}} />
                        ) : selectedVehicle.soort === "Caravan" ? (
                            <DisplayCaravanBox data={selectedVehicle} huurButtonStatus={false} onHuur={() => {}} />
                        ) : (
                            <DisplayCamperBox data={selectedVehicle} huurButtonStatus={false} onHuur={() => {}} />
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
        </>
    );
}