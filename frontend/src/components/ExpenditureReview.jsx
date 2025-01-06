import { useState } from "react";

export default function ExpenditureReview({ vehicle, customer }) {
    const [beschrijving, setBeschrijving] = useState('');
    const [confirmationMessage, setConfirmationMessage] = useState('');
    const [messageType, setMessageType] = useState(''); // 'error' or 'success'

    const voertuigRegistreren = () => {
        if (beschrijving) {
            setConfirmationMessage('Expenditure successfully registered!');
            setMessageType('success');
        } else {
            setConfirmationMessage('Please provide a description.');
            setMessageType('error');
        }
    };

    return (
        <div className="voertuigTab">
            <p className="voertuigTab__text">
                {vehicle.merk} {vehicle.type} - {vehicle.kenteken}
            </p>
            <p className="voertuigTab__text">
                {customer ? customer.naam : 'No customer data available'}
            </p>
            <div className="voertuigTab__inputs">
                <input
                    type="text"
                    placeholder="Beschrijving"
                    value={beschrijving}
                    onChange={(e) => setBeschrijving(e.target.value)}
                />
                <button onClick={voertuigRegistreren}>Registreren</button>
            </div>
            {confirmationMessage && (
                <p className={`confirmationMessage ${messageType}`}>
                    {confirmationMessage}
                </p>
            )}
        </div>
    );
}
