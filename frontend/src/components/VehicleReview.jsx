import { useState } from "react";
import "../styles/VehicleReview.css";

export default function VehicleReview({ data }) {
    const [foto, setFoto] = useState(null);
    const [beschrijving, setBeschrijving] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");
    const [messageType, setMessageType] = useState("");

    const schadeClaim = {
        voertuigId: data.id,
        beschrijving: beschrijving,
        datum: new Date().toISOString(),
        foto: foto ? URL.createObjectURL(foto) : null,
    };

    function voertuigAccepteren() {
        alert("Voertuig is YIPPIE");
    }

    function voertuigWeigeren() {
        alert("Voertuig is GONE");
    }

    function voertuigRegistreren() {
        if (data.id && beschrijving && foto) {
            setConfirmationMessage("Voertuig is geregistreerd!");
            setMessageType("success");
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
            setMessageType("error");
        }
    }

    return (
        <div className="voertuigTab">
            <p className="voertuigTab__text">
                {data.merk} {data.type} - {data.kenteken}
            </p>
            <div className="voertuigTab__inputs">
                <input
                    type="text"
                    placeholder="Beschrijving"
                    value={beschrijving}
                    onChange={(e) => setBeschrijving(e.target.value)}
                />
                <input
                    type="file"
                    accept="image/*"
                    onChange={(e) => setFoto(e.target.files[0])}
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
