import { useState } from "react";
import "../styles/VehicleReview.css";
import downloadFile from "../scripts/downloadFile.js";

export default function VehicleReview({ data, setVehicles }) {
    const [foto, setFoto] = useState(null);
    const [beschrijving, setBeschrijving] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");
    const [messageType, setMessageType] = useState("");

    async function voertuigAccepteren(){
        try {
            const response = await fetch(`https://localhost:53085/api/Schadeclaim/voertuig-accepteren/${data.id}`, {
                method: 'PUT',
        
                // TODO: change to 'same-origin' when in production.
                credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                headers: {
                    'content-type': 'application/json'
                },
            });
            if(response.ok){
                alert("Voertuig is geaccepteerd!");
                updateVehicles(data.id, "Verhuurbaar");
                downloadFile(`Dit hoort een email te zijn met informatie over de ${data.merk} ${data.type} - ${data.kenteken}`, "bevestigingsemail.txt")
            } 
            // else alert(response);
        }
        catch (e) {
            alert(e);
        }
    }

    function updateVehicles(id, status) {
        setVehicles((old) => {
            const copy = [...old];

            const vehicles = copy.filter(vehicle => vehicle.id === id);
            if (vehicles.length > 1) {
                return copy;
            }
            const vehicle = vehicles[0];
            vehicle.status = status;

            return copy;
        });
    }

    async function handleWeigeren(){
        if (beschrijving.length < 5) {
            setConfirmationMessage("De beschrijving moet langer zijn dan 4 characters.");
            setMessageType('error');
            return;
        }

        if (beschrijving && foto) {
            const schadeClaim = {
                Voertuig: data,
                beschrijving: beschrijving,
                datum: new Date(),
                foto: foto,
                status: "In behandeling",
            };
            try {
                setConfirmationMessage("");
                await voertuigWeigeren(schadeClaim);
                alert("Voertuig is succcesvol geweigerd!");

                updateVehicles(data.id, "Onverhuurbaar");
            }
            catch (e) {
                window.alert(e);
            }
        }
        else {
            setConfirmationMessage("Vul alstublieft alle velden in.");
            setMessageType('error');
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
                <button onClick={voertuigAccepteren}>Accepteer</button>
                <button onClick={handleWeigeren}>Weiger</button>
            </div>
            {confirmationMessage && (
                <p className={`confirmationMessage ${messageType}`}>
                    {confirmationMessage}
                </p>
            )}
        </div>
    );
}

/**
* @param {Object} payload 
* @returns {Object}
*/
async function voertuigWeigeren(payload) {
    const response = await fetch('https://localhost:53085/api/Schadeclaim/create', {
        method: 'POST',

        // TODO: change to 'same-origin' when in production.
        credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(payload),
    });
    return await response.json();
}