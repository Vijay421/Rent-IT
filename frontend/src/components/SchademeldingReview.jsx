import { useState } from "react";
import "../styles/SchademeldingReview.css";

export default function SchadeclaimReview({ data, setSchadeclaims }) {
    const [opmerkingen, setOpmerkingen] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");
    const [messageType, setMessageType] = useState("");

    async function handleCreate(){
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
                foto: foto ? URL.createObjectURL(foto) : null,
                status: status,
            };
            try {
                setConfirmationMessage("");
                await createSchadeclaim(schadeClaim);
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
    async function handleUpdate(){
        const schadeClaim = {
            opmerkingen: opmerkingen,
        };
        try{
            setConfirmationMessage("");
            await updateSchadeclaim(schadeClaim);
            alert("Schadeclaim is geupdate!");
            updateSchadeclaimsLijst(data.id);
        }
        catch (e){            
            window.alert(e);
        }
    }


    function updateSchadeclaimsLijst(id) {
        setSchadeclaims((old) => {
            const copy = [...old];

            const schadeclaims = copy.filter(vehicle => vehicle.id === id);
            if (schadeclaims.length > 1) {
                return copy;
            }
            const schadeclaim = schadeclaims[0];

            return copy;
        });
    }
   
    return (
        <div className="voertuigTab">
            <p className="voertuigTab__text">
                {data.Voertuig}
            </p>
            <p>
                {data.beschrijving} - {new Date(data.datum).toLocaleDateString()}
            </p>
            <img>{/* {data.foto} */}</img>
            <div className="voertuigTab__inputs">
                <select /* defaultValue={data.status} */>
                    <option value="0">In behandeling</option>
                    <option value="1">In reparatie</option>
                    <option value="2">Afgehandeld</option>
                </select>
                
                <input
                    type="text"
                    placeholder="Opmerkingen"
                    value={opmerkingen}
                    onChange={(e) => setOpmerkingen(e.target.value)}
                />
                <button onClick={updateSchadeclaim}>Update</button>
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
async function updateSchadeclaim(payload){
    const response = await fetch(`https://localhost:53085/api/Schadeclaim/update/${data.id}`, {
        method: 'PUT',
        
        // TODO: change to 'same-origin' when in production.
        credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(payload),

    });
    return await response.json();
}
async function createSchadeclaim(payload) {
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


