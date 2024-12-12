import { useState } from "react";
import "../styles/RentRquest.css";

export default function RentRequest({ data, setRequests, index }) {
    const [shouldReview, setShouldReview] = useState(false);
    const [reason, setReason] = useState(null);

    function handleShouldReview() {
        setShouldReview(true);
    }

    function handleBackButton() {
        setShouldReview(false);
    }

    function handleReason(e) {
        setReason(e.target.value);
    }

    async function handleBackCorrect() {
        const payload = { beoordeling: true };
        try {
            const huuraanvraag = await sendReview(data.id, payload);

            // Update the state from the parent, and insert the updated huuraanvraag.
            setRequests((huuraanvragen) => {
                const copy = [...huuraanvragen]; // Can only update a copy of the array.
                copy[index] = huuraanvraag;
                return copy;
            });
        } catch {
            window.alert("error tijdens het versturen van de beoordeling");
        }
    }

    async function handleBackWrong() {
        if (reason === null || reason === "") {
            window.alert("Vul een reden in bij het afkeuren!");
            return;
        }

        const payload = {
            reden: reason,
            beoordeling: false,
        };

        try {
            const huuraanvraag = await sendReview(data.id, payload);

            // Update the state from the parent, and insert the updated huuraanvraag.
            setRequests((huuraanvragen) => {
                const copy = [...huuraanvragen]; // Can only update a copy of the array.
                copy[index] = huuraanvraag;
                return copy;
            });
        } catch {
            window.alert("error tijdens het versturen van de beoordeling");
        }
    }

    /**
     * Return the correct status based on the given status.
     * 
     * @param {string} status 
     * @returns {string}
     */
    function getStatusString(status) {
        if (status === true) {
            return "geaccepteerd";
        } if (status === false) {
            return "geweigered";
        } else {
            return "niet beoordeeld";
        }
    }

    /**
     * Will either return an empty fragment or paragraphs with the reason.
     * 
     * @param {string} reason 
     * @returns {ReactElement}
     */
    function getReasonElement(reason) {
        if (reason === null || reason === "") {
            return <></>;
        } else {
            return (
                <>
                    <p className="rent-request__label">Reden</p>
                    <p>{reason}</p>
                </>
            );
        }
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

            <div className="rent-request__trip rent-request__box">
                <h3>Reis</h3>

                <p className="rent-request__label">Reisaard</p>
                <p>{data.reisaard}</p>

                <p className="rent-request__label">Verste bestemming</p>
                <p>{data.vereiste_bestemming}</p>

                <p className="rent-request__label">Verwachte kilometers</p>
                <p>{data.verwachte_km}km</p>
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
                <p>{getStatusString(data.geaccepteerd)}</p>
                {getReasonElement(data.reden)}
            </div>

            <div className="rent-request__review">
                {
                    shouldReview === false ? (
                        <button onClick={handleShouldReview}>Beoordelen</button>
                    ) : (
                        <div className="rent-request__review--buttons">
                            <button className="rent-request__review--back" onClick={handleBackButton}>Terug</button>
                            <button className="rent-request__review--correct" onClick={handleBackCorrect}>Goedkeuren</button>
                            <button className="rent-request__review--wrong" onClick={handleBackWrong}>Afkeuren</button>
                            <textarea className="rent-request__review--text" onInput={handleReason} placeholder="Reden..." maxLength="500"></textarea>
                        </div>
                    )
                }
            </div>
        </div>
    );
}

/**
 * Will send the review to the backend.
 * 
 * @param {number} id 
 * @param {Object} payload 
 * @returns {Object}
 */
async function sendReview(id, payload) {
    try {
        const response = await fetch(`https://localhost:53085/api/BackOffice/huuraanvragen-beoordelen/${id}`, {
            method: 'PUT',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(payload),
        });

        return await response.json();
    } catch (error) {
        console.error('error when requesting the rent history request, or parsing the response:', error);
        throw error;
    }
}
