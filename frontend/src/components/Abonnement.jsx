/* eslint-disable */

import {useState} from "react";
import PropTypes from "prop-types";
import downloadFile from "../scripts/downloadFile";

export default function Abonnement({data, onUpdate}) {
    const statusText = document.getElementById("abonnement-keuren-status__span");
    const [reden, setReden] = useState("");

    const amountOfDays = Math.floor((new Date(data.einddatum) - new Date(data.startdatum)) / (1000 * 60 * 60 * 24));
    const amountOfMonths = Math.floor(amountOfDays / 30);
    const leftOverDays = amountOfDays % 30;

    async function saveAbonnement(payload) {
        const goedkeurenButton = document.getElementById(`abonnement-keuren-goedkeuren__button-${payload.id}`);
        const afkeurenButton = document.getElementById(`abonnement-keuren-afkeuren__button-${payload.id}`);
        const confirmButton = document.getElementById(`abonnement-keuren-confirm__button-${payload.id}`);
        const redenTextarea = document.getElementById(`reden__textarea-${payload.id}`);
        const terugButton = document.getElementById(`abonnement-keuren-terug__button-${payload.id}`);


        const response = await fetch(`https://localhost:53085/api/Abonnement/${payload.id}`, {
            method: "PUT",
            credentials: 'include',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(payload)
        });

        const contents = getEmailContents(payload.geaccepteerd, payload.naam, payload.reden);
        downloadFile(contents, "abonnementkeuring.txt");

        if (response.ok) {
            statusText.style.display = 'flex';
            statusText.style.color = 'green';
            statusText.innerHTML = 'Het abonnement is beoordeeld';

            goedkeurenButton.style.display = 'flex';
            afkeurenButton.style.display = 'flex';
            confirmButton.style.display = 'none';
            redenTextarea.style.display = 'none';
            terugButton.style.display = 'none';

            onUpdate(payload);
        } else {
            statusText.style.display = 'flex';
            statusText.style.color = 'red';
            statusText.innerHTML += await response.text();
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
        const terugButton = document.getElementById(`abonnement-keuren-terug__button-${id}`);


        if (goedkeurenButton) goedkeurenButton.style.display = "none";
        if (afkeurenButton) afkeurenButton.style.display = "none";
        if (confirmButton) confirmButton.style.display = "flex";
        if (redenTextarea) redenTextarea.style.display = "flex";
        if (terugButton) terugButton.style.display = "flex";

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

    function onTerugButtonClick(data) {
        const goedkeurenButton = document.getElementById(`abonnement-keuren-goedkeuren__button-${data.id}`);
        const afkeurenButton = document.getElementById(`abonnement-keuren-afkeuren__button-${data.id}`);
        const confirmButton = document.getElementById(`abonnement-keuren-confirm__button-${data.id}`);
        const redenTextarea = document.getElementById(`reden__textarea-${data.id}`);
        const terugButton = document.getElementById(`abonnement-keuren-terug__button-${data.id}`);

        if (goedkeurenButton) goedkeurenButton.style.display = "flex";
        if (afkeurenButton) afkeurenButton.style.display = "flex";
        if (confirmButton) confirmButton.style.display = "none";
        if (redenTextarea) redenTextarea.style.display = "none";
        if (terugButton) terugButton.style.display = "none";
    }

    return (
        <div key={data.id} className="abonnement-content-box__div">
            <h2 className='abonnement-content-box__h2'>{data.naam}</h2>
            <div className='abonnement-content__div' data-cy='abonnement-content-div'>
                <p className='abonnement-content__p' id='abonnement-content-soort' data-cy='abonnement-content-soort'>
                    <b>Soort abonnement:</b> {data.soort === "pay_as_you_go" ? "Pay as you go" : "Prepaid"}
                </p>

                <p className='abonnement-content__p' id='abonnement-content-maxHuurders'
                   data-cy='abonnement-content-maxHuurders'><b>Max
                    huurders:</b> {data.maxHuurders}</p>


                <p className='abonnement-content__p' id='abonnement-content-startDatum'
                   data-cy='abonnement-content-startdatum'><b>Start
                    datum:</b> {data.startdatum}</p>

                <p className='abonnement-content__p' id='abonnement-content-eindDatum'
                   data-cy='abonnement-content-einddatum'><b>Eind
                    datum:</b> {data.einddatum}</p>

                <p className='abonnement-content__p' id='abonnement-content-prijs' data-cy='abonnement-content-ppm'><b>Prijs
                    per maand:</b> € {data.soort === "pay_as_you_go"
                    ?
                    (data.maxHuurders * 30).toFixed(2)
                    :
                    (data.maxHuurders * 25).toFixed(2)
                }</p>

                <p className='abonnement-content__p' id='abonnement-content-totale-prijs' data-cy='abonnement-content-totale'><b>Totale prijs:</b> € {data.soort === "pay_as_you_go"
                    ?
                    ((data.maxHuurders * amountOfMonths * 30) + (data.maxHuurders * leftOverDays * (30 / 30))).toFixed(2)
                    :
                    ((data.maxHuurders * amountOfMonths * 25) + (data.maxHuurders * leftOverDays * (25 / 30))).toFixed(2)
                }</p>

                <p className='abonnement-content__p' id='abonnement-content-geaccepteerd'
                   data-cy='abonnement-content-geaccepteerd'>
                    <b>Status:</b> {data.geaccepteerd === null ? "Nog niet beoordeeld" : data.geaccepteerd ? "Goedgekeurd" : "Afgekeurd"}
                </p>
                <p className='abonnement-content__p' id='abonnement-content-reden' data-cy='abonnement-content-reden'>
                    <b>Reden:</b> {data.reden}</p>
            </div>
            <div className="abonnement-keuren__div">

                <button onClick={() => onGoedkeurenButtonClick(data)}
                        className='abonnement-keuren-goedkeur-button'
                        id={`abonnement-keuren-goedkeuren__button-${data.id}`}
                        data-cy='abonnement-keuren-goedkeuren-button'>Goedkeuren
                </button>

                <button
                    onClick={() => onAfkeurenButtonClick(data.id)}
                    className="abonnement-keuren-afkeur-button"
                    id={`abonnement-keuren-afkeuren__button-${data.id}`}
                    data-cy='abonnement-keuren-afkeuren-button'
                >
                    Afkeuren
                </button>

                <button style={{display: "none"}} onClick={() => onConfirmButtonClick(data)}
                        className='abonnement-keuren-confirm-button'
                        id={`abonnement-keuren-confirm__button-${data.id}`}
                        data-cy='abonnement-keuren-confirm-button'>Confirm
                </button>

                <textarea
                    name={`redenTextArea-${data.id}`}
                    id={`reden__textarea-${data.id}`}
                    className='reden-textarea-class'
                    placeholder="Voer afkeur reden hierin"
                    onChange={(e) => setReden(e.target.value)}
                    value={reden}
                    style={{display: "none", overflow: "hidden"}}
                    data-cy='abonnement-keuren-textarea'
                ></textarea>

                <button style={{display: "none"}} onClick={() => onTerugButtonClick(data)}
                        className='abonnement-keuren-terug-button'
                        id={`abonnement-keuren-terug__button-${data.id}`}>Terug
                </button>
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

/**
 * Returns the email contents of the confirmation email.
 * 
 * @param {boolean} accepted 
 * @param {string} subName 
 * @returns string
 */
function getEmailContents(accepted, subName, reason) {
    const review = accepted ? "goed" : "af";
    const extra = accepted ? "U kunt nu voertuigen huren met dit abonnement!" : `De reden hiervoor is: ${reason}` ;

    const contents = `Geachte heer/mevrouw,

Bij deze is abonnement: '${subName}' ${review}gekeurd.
${extra}

Met vriendelijke groet,

Rent-IT
`
    return contents;
}
