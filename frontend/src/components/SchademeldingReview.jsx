import { useState } from "react";
import "../styles/SchademeldingReview.css";

export default function SchadeclaimReview({ data }) {
    const [opmerkingen, setOpmerkingen] = useState("");
    const [confirmationMessage, setConfirmationMessage] = useState("");
    const [messageType, setMessageType] = useState("");

    async function voertuigReparatieZetten(){
        try {
            const response = await fetch(`https://localhost:53085/api/Schadeclaim/voertuig-accepteren/${data.id}`, {
                method: 'PUT',
        
                // TODO: change to 'same-origin' when in production.
                credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                headers: {
                    'content-type': 'application/json'
                },
            });
            if(response.ok) alert("Voertuig is geaccepteerd!");
            // else alert(response);
        }
        catch (e) {
            alert(e);
        }
    }
   
    return (
        <div className="voertuigTab">
            <p className="voertuigTab__text">
                {data.merk} {data.type} - {data.kenteken}
                {/* {data.foto} */}
                {/* {data.beschrijving} */}
            </p>
            <div className="voertuigTab__inputs">
                <select /* defaultValue={data.status} */>
                    <option value="">In reparatie</option>
                    <option value="">Afgehandeld</option>
                </select>
                
                <input
                    type="text"
                    placeholder="Opmerkingen"
                    value={opmerkingen}
                    onChange={(e) => setOpmerkingen(e.target.value)}
                />
                <button onClick={voertuigReparatieZetten}>In reparatie zetten</button>
            </div>
            {confirmationMessage && (
                <p className={`confirmationMessage ${messageType}`}>
                    {confirmationMessage}
                </p>
            )}
        </div>
    );
}

// /**
// * @param {Object} payload 
// * @returns {Object}
// */
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



    // async function handleWeigeren(){       
    //     if (beschrijving && foto) {
    //         const schadeClaim = {
    //             Voertuig: data,
    //             beschrijving: beschrijving,
    //             foto: foto ? URL.createObjectURL(foto) : null,
    //         };
    //         try {
    //             setConfirmationMessage("");
    //             await voertuigWeigeren(schadeClaim);
    //             alert("Voertuig is succcesvol geweigerd!");
    //         }
    //         catch (e) {
    //             window.alert(e);
    //         }
    //     }
    //     else {
    //         setConfirmationMessage("Vul alstublieft alle velden in.");
    //         setMessageType('error');
    //     }
    // }