import { useState } from "react";
import "../styles/RentRquest.css";

export default function RentRequest({ data }) {
    const [shouldReview, setShouldReview] = useState(false);

    function handleShouldReview() {
        setShouldReview(true);
    }

    function handleBackButton() {
        setShouldReview(false);
    }

    return (
        <div className="rent-request">
            <div className="rent-request__renter rent-request__box">
                <h3>Huurder</h3>

                <p className="rent-request__label">Wettelijke naam</p>
                <p>{data.wettelijke_naam}</p>

                <p className="rent-request__label">Adresgegevens</p>
                <p>{data.adresgegevens}</p>

                <p className="rent-request__label">Rijbewijsnummer</p>
                <p>{data.rijbewijsnummer}</p>
            </div>

            <div className="rent-request__vehicle rent-request__box">
                <h3>Voertuig</h3>

                <p className="rent-request__label">Naam</p>
                <p>{data.voertuig.merk} {data.voertuig.type}</p>

                <p className="rent-request__label">Soort</p>
                <p>{data.voertuig.soort}</p>

                <p className="rent-request__label">Status</p>
                <p>{data.voertuig.status}</p>

                <p className="rent-request__label">Prijs</p>
                <p>€{data.voertuig.prijs.toFixed(2)}</p>
            </div>

            <div className="rent-request__period rent-request__box">
                <h3>Huurperiode</h3>

                <p className="rent-request__label">Startdatum</p>
                <p>{data.startdatum}</p>

                <p className="rent-request__label">Einddatum</p>
                <p>{data.einddatum}</p>
            </div>

            <div className="rent-request__status rent-request__box">
                <h3>Status</h3>
                {/* TODO: handle when geaccepteerd is null/undefined */}
                <p>{data.geaccepteerd ? "geaccepteerd" : "geweigered"}</p>
            </div>

            <div className="rent-request__review">
                {
                    shouldReview === false ? (
                        <button onClick={handleShouldReview}>Beoordelen</button>
                    ) : (
                        <>
                            <button onClick={handleBackButton}>Terug</button>
                            <button>Goedkeuren</button>
                            <button>Afkeuren</button>
                            <textarea placeholder="Reden..."></textarea>
                        </>
                    )
                }
            </div>
        </div>
    );
}
