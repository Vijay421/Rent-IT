import {useState} from "react";
import PropTypes from "prop-types";

export default function Abonnement({data}) {
    const statusText = document.getElementById("abonnement-keuren-status__span");
    const [reden, setReden] = useState("");

    async function saveAbonnement(payload) {
        const goedkeurenButton = document.getElementById(`abonnement-keuren-goedkeuren__button-${payload.id}`);
        const afkeurenButton = document.getElementById(`abonnement-keuren-afkeuren__button-${payload.id}`);
        const confirmButton = document.getElementById(`abonnement-keuren-confirm__button-${payload.id}`);
        const redenTextarea = document.getElementById(`reden__textarea-${payload.id}`);

        const response = await fetch(`https://localhost:53085/api/Abonnement/${payload.id}`, {
            method: "PUT",
            credentials: 'include',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(payload)
        });

        if (response.ok) {
            statusText.style.display = 'flex';
            statusText.style.color = 'green';
            statusText.innerHTML = 'Abonnement gekeurd';

            goedkeurenButton.style.display = 'flex';
            afkeurenButton.style.display = 'flex';
            confirmButton.style.display = 'none';
            redenTextarea.style.display = 'none';
        } else {
            console.error(response);
            statusText.style.display = 'flex';
            statusText.style.color = 'red';
            statusText.innerHTML = `Error ${response.status}: `;
        }
    }

    function onGoedkeurenButtonClick(abonnement) {
        const payload = {
            id: abonnement.id,
            naam: abonnement.naam,
            prijsPerMaand: abonnement.prijsPerMaand,
            maxHuurders: abonnement.maxHuurders,
            einddatum: abonnement.einddatum,
            soort: abonnement.soort,
            geaccepteerd: true,
            reden: ""
        };

        saveAbonnement(payload);
    }

    function onAfkeurenButtonClick(id) {
        const goedkeurenButton = document.getElementById(`abonnement-keuren-goedkeuren__button-${id}`);
        const afkeurenButton = document.getElementById(`abonnement-keuren-afkeuren__button-${id}`);
        const confirmButton = document.getElementById(`abonnement-keuren-confirm__button-${id}`);
        const redenTextarea = document.getElementById(`reden__textarea-${id}`);

        if (goedkeurenButton) goedkeurenButton.style.display = "none";
        if (afkeurenButton) afkeurenButton.style.display = "none";
        if (confirmButton) confirmButton.style.display = "flex";
        if (redenTextarea) redenTextarea.style.display = "flex";

        statusText.style.display = 'none';
    }

    function onConfirmButtonClick(abonnement) {
        const payload = {
            id: abonnement.id,
            naam: abonnement.naam,
            prijsPerMaand: abonnement.prijsPerMaand,
            maxHuurders: abonnement.maxHuurders,
            einddatum: abonnement.einddatum,
            soort: abonnement.soort,
            geaccepteerd: false,
            reden: reden,
        };

        if (reden === "") {
            statusText.style.display = 'flex';
            statusText.style.color = 'red';
            statusText.innerHTML = 'Reden is verplicht';
        }
        else {
            saveAbonnement(payload);
            setReden("");
        }
    }

    return (
        <div key={data.id} className="abonnement-content-box__div">
            <h2 className='abonnement-content-box__h2'>{data.naam}</h2>
            <div className='abonnement-content__div'>
                <p className='abonnement-content__p' id='abonnement-content-prijs'><b>Prijs per
                    maand:</b> € {data.prijsPerMaand.toFixed(2)}</p>
                <p className='abonnement-content__p' id='abonnement-content-soort'>
                    <b>Soort
                        abonnement:</b> {data.soort === "pay_as_you_go" ? "Pay as you go" : "Prepaid"}
                </p>
                <p className='abonnement-content__p' id='abonnement-content-eindDatum'><b>Eind
                    datum:</b> {data.einddatum}</p>
                <p className='abonnement-content__p' id='abonnement-content-maxHuurders'><b>Max
                    huurders:</b> {data.maxHuurders}</p>
                {/*<p className='abonnement-content__p' id='abonnement-content-geaccepteerd'>{abonnement.geaccepteerd}</p>*/}
                {/*<p className='abonnement-content__p' id='abonnement-content-reden'>{abonnement.reden}</p>*/}
            </div>
            <div className="abonnement-keuren__div">

                <button onClick={() => onGoedkeurenButtonClick(data)}
                        className='abonnement-keuren-goedkeur-button'
                        id={`abonnement-keuren-goedkeuren__button-${data.id}`}>Goedkeuren
                </button>

                <button
                    onClick={() => onAfkeurenButtonClick(data.id)}
                    className="abonnement-keuren-afkeur-button"
                    id={`abonnement-keuren-afkeuren__button-${data.id}`}
                >
                    Afkeuren
                </button>

                <button style={{display: "none"}} onClick={() => onConfirmButtonClick(data)}
                        className='abonnement-keuren-confirm-button'
                        id={`abonnement-keuren-confirm__button-${data.id}`}>Confirm
                </button>

                <textarea
                    name={`redenTextArea-${data.id}`}
                    id={`reden__textarea-${data.id}`}
                    className='reden-textarea-class'
                    placeholder="Voer afkeur reden hierin"
                    onChange={(e) => setReden(e.target.value)}
                    value={reden}
                    style={{display: "none", overflow: "hidden"}}
                ></textarea>
            </div>
        </div>
    );
}

PropTypes.Abonnement = {
    data: PropTypes.object.isRequired,

    id: PropTypes.number.isRequired,
    naam: PropTypes.string.isRequired,
    prijsPerMaand: PropTypes.number.isRequired,
    soort: PropTypes.string.isRequired,
    einddatum: PropTypes.string.isRequired,
    maxHuurders: PropTypes.number.isRequired,
    geaccepteerd: PropTypes.bool.isRequired,
    reden: PropTypes.string.isRequired
};