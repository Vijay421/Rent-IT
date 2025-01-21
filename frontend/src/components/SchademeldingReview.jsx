import { useState } from "react";
import "../styles/SchademeldingReview.css";

export default function SchadeclaimReview({ data, setSchadeclaims }) {
    const [opmerkingen, setOpmerkingen] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");
    const [messageType, setMessageType] = useState("");

    async function handleUpdate(){
        const schadeClaim = {
            beschrijving: beschrijving,
        };
        try{
            setConfirmationMessage("");
            await updateSchadeclaim(schadeclaim);
            alert("Voertuig is geaccepteerd!");
            updateSchadeclaimsLijst(data.id);
        }
        catch (e){
            
        }
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
                {/* {data.merk} {data.type} - {data.kenteken} */}
                {data.beschrijving} - {new Date(data.datum).toLocaleDateString()}
            </p>
            <img>{/* {data.foto} */}</img>
            <div className="voertuigTab__inputs">
                <select /* defaultValue={data.status} */>
                    <option value="0">Onverhuurbaar</option>
                    <option value="1">Verhuurbaar</option>
                    <option value="2">In reparatie</option>
                    <option value="3">Geblokkeerd</option>
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


// async function voertuigWeigeren(payload) {
//     const response = await fetch('https://localhost:53085/api/Schadeclaim/create', {
//         method: 'POST',

//         // TODO: change to 'same-origin' when in production.
//         credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
//         headers: {
//             'content-type': 'application/json'
//         },
//         body: JSON.stringify(payload),
//     });
//     return await response.json();
// }


