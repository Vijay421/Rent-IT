import { useState } from "react";

export default function VehicleReview({data}){

    const [foto, setFoto] = useState("");
    const [beschrijving, setBeschrijving] = useState("");

    const schadeClaim = {
        voertuigId: data.id,
        beschrijving: beschrijving,
        datum: new Date().getDate(),
        foto: foto
    };

    function voertuigAccepteren(){
        alert("Voertuig is YIPPIE");
    }

    async function voertuigWeigeren(){
        // try {
        //     const response = await fetch('https://localhost:53085/api/Schadeclaim/put', {
        //         method: 'PUT',

        //         // TODO: change to 'same-origin' when in production.
        //         credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
        //         headers: {
        //             'content-type': 'application/json'
        //         },
        //     });
        //     // const data = await response.json();
        //     if (response.ok){
                alert("Voertuig is geweigerd!");
        //     }
        // }
        // catch (e) {
        //     console.error(e);
        // }
    }

    function voertuigRegistreren(){
        // Voertuigstatus kan bijgewerkt worden bij inname (teruggebracht, met schade).
        // Innamestatus wordt automatisch geüpdatet in het systeem en zichtbaar voor andere medewerkers.

        if (VoertuigId && Beschrijving && Foto){
            alert("Voertuig is geregistreerd!");
        }
        else setConfirmationMessage("Vul alstublieft alle velden in.");
    }
    return(
        <div className="voertuigTab">
            <h2>{data.merk} {data.type} - {data.kenteken}</h2>
            <input
                onChange={(e) => setBeschrijving(e.target.value)}
            />
            <input
                onChange={(e) => setFoto(e.target.value)}
            />
            <button onClick={voertuigRegistreren}>Registreren</button>
            {/* <button onClick={voertuigWeigeren}>Weigeren</button> */}
        </div>
    )
}