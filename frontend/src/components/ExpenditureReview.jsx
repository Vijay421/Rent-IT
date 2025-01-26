import { useState } from "react";
import '../styles/FrontofficeUitgave.css';
import PropTypes from "prop-types";

export default function ExpenditureReview({ uitgave, setUitgave }) {
    const [beschrijving, setBeschrijving] = useState('');
    const [confirmationMessage, setConfirmationMessage] = useState('');
    const [messageType, setMessageType] = useState(''); // 'error' or 'success'


    async function changeVoertuigUitgaveStatus() {

        if (beschrijving) {
            setConfirmationMessage('');
            alert("Voertuig is succcesvol uitgegeven!");
            setConfirmationMessage('Expenditure successfully registered!');
            setMessageType('success');
        } else {
            setConfirmationMessage('Please provide a description.');
            setMessageType('error');
            return;
        }

        try {
            const response = await fetch(`https://localhost:53085/api/FrontOffice/uitgave/${uitgave.id}`, {
                method: 'POST',

                // TODO: change to 'same-origin' when in production.
                credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                        omschrijving: beschrijving,
                }),
            });
            const data = await response.json();
            setConfirmationMessage("Expenditure successfully registered!");
            setMessageType('success');
            return data;
        }
        catch (e) {
            setConfirmationMessage(e.message);
            setMessageType('error');
        }
    }

    async function handleUitgaven() {
        if (beschrijving.length === 0) {
            window.alert("Vul een beschrijving in.");
            return;
        }

        const response = await changeVoertuigUitgaveStatus();

        setUitgave(old => {
            const copy = [...old];
            const filtered = copy.filter(aanvraag => aanvraag.voertuigId != response.voertuigId);
            return filtered;
        });
    }

    return (
        <div className="voertuigTab">
            <p className="voertuigTab__text">
                {uitgave.merk} {uitgave.type} - {uitgave.kenteken}
            </p>
            <p className="voertuigTab__text">
                {uitgave.wettelijkenaam}
            </p>
            <div className="voertuigTab__inputs">
                <input
                    type="text"
                    placeholder="Beschrijving"
                    value={beschrijving}
                    onChange={(e) => setBeschrijving(e.target.value)}
                />
                <button onClick={handleUitgaven}>Registreren</button>
            </div>
            {confirmationMessage && (
                <p className={`confirmationMessage ${messageType}`}>
                    {confirmationMessage}
                </p>
            )}
        </div>
    );
}

ExpenditureReview.propTypes = {
    uitgave: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        startdatum: PropTypes.string.isRequired,
        einddatum: PropTypes.string.isRequired,
        rijbewijsnummer: PropTypes.string.isRequired,
        id: PropTypes.number.isRequired
    }).isRequired,
};
