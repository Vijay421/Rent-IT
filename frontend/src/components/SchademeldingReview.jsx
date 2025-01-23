import { useState } from "react";
import "../styles/SchademeldingReview.css";
import mock from '../assets/toyota-corolla.png';

export default function SchadeclaimReview({ data, setSchadeclaims }) {
    const [status, setStatus] = useState("");
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
                datum: data.datum,
                foto: foto ? new URL(`${process.env.PUBLIC_URL}/img/${foto}`) : null,
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
            status: status,
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
                {data.VoertuigId}
            </p>
            <p>
                {data.beschrijving} - {new Date(data.datum).toLocaleDateString()}
            </p>
            <div className="schademeldingTab">
                Foto:<img src={mock}  className='schademelding_Foto' ></img>
                {/* {`${process.env.PUBLIC_URL}/img/${data.foto}`} */}
                <div className="voertuigTab__inputs">
                    <select onChange={(e) => setStatus(e.target.value)}>
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
                    {/* TO-DO: Knop moet navigeren naar Voertuig aanpassing */}
                    <button>Voertuig aanpassen</button>
                    <button onClick={handleUpdate}>Update</button>
                </div>
                {confirmationMessage && (
                    <p className={`confirmationMessage ${messageType}`}>
                        {confirmationMessage}
                    </p>
                )}
            </div>
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


