import { useState } from "react";
import "../styles/VehicleReview.css";

export default function VehicleReview({ data }) {
    const [foto, setFoto] = useState(null); // Changed to null to represent no file initially
    const [beschrijving, setBeschrijving] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState(""); // Added for feedback to the user

    const schadeClaim = {
        voertuigId: data.id,
        beschrijving: beschrijving,
        datum: new Date().toISOString(), // Use ISO string for accurate timestamp
        foto: foto ? URL.createObjectURL(foto) : null, // Temporarily preview the image
    };

    function voertuigAccepteren() {
        alert("Voertuig is YIPPIE");
    }

    function voertuigWeigeren() {
        alert("Voertuig is GONE");
    }

    function voertuigRegistreren() {
        if (data.id && beschrijving && foto) {
            alert("Voertuig is geregistreerd!");
            // You can handle form submission here, e.g., send `schadeClaim` to an API
        } else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
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
                <p className="confirmationMessage">{confirmationMessage}</p>
            )}
        </div>
    );
}
