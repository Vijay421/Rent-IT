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

    function voertuigWeigeren(){
        alert("Voertuig is GONE");
    }

    function voertuigRegistreren(){
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