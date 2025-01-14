import { useState } from "react";
import "../styles/VehicleReview.css";

export default function VehicleReview({ data }) {
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
                const element = document.createElement("a");
                const email = new Blob(["Dit hoort een email te zijn!"], {type: 'text/plain'});
                email.href = element;
                email.setAttribute("download", "image.png"); //or any other extension
                document.body.appendChild(element);
                element.click();
            } 
            // else alert(response);
        }
        catch (e) {
            alert(e);
        }
    }

    async function handleWeigeren(){       
        if (beschrijving && foto) {
            const schadeClaim = {
                Voertuig: data,
                beschrijving: beschrijving,
                datum: new Date(),
                foto: foto ? URL.createObjectURL(foto) : null,
            };
            try {
                setConfirmationMessage("");
                await voertuigWeigeren(schadeClaim);
                alert("Voertuig is succcesvol geweigerd!");
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