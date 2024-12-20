import '../styles/Reservering.css';
import {useEffect, useState} from "react";
import PropTypes from "prop-types";

export default function Reservering() {
    const [userData, setUserData] = useState([]);

    useEffect(() => {
        fetchReserveringen();
    },[]);

    async function fetchReserveringen() {
        const userId = 1;

        const response = await fetch(`https://localhost:53085/api/Huur/${userId}`, {
            method: "GET",
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
        });
        const data = await response.json();

        setUserData(data);
    }

    return (
        <div className='content'>
            <div className="reserveringen-box__div">
                <h1 className='reserveringen-box-title__h1'>Reserveringen</h1>
                <div className="reservering-containers__div">
                    {userData.map((user) => {
                        return (
                            <>
                                <h2 className='reservering-nummer__h2'>Reservering #{user.id}</h2>
                                <ContainerContent key={user.id} user={user}/>;
                            </>
                        );
                    })}
                </div>
            </div>
        </div>
    );
}

function ContainerContent(props) {


    function handleWijzigenButtonClick() {
        console.log("wijzigen clicked");
    }

    function handleAnnulerenButtonClick() {
        console.log("annuleren clicked");
    }

    return (
        <div className='reservering-container__div'>
            <div className='reservering-container-info-box__div'>
                <div className="info-box-container1__div">
                    <p>Merk:</p>
                    <p>{}toyota</p>

                    <p>Model:</p>
                    <p>{}corolla</p>

                    <p>Kleur:</p>
                    <p>{}red</p>

                    <p>Aanschafjaar:</p>
                    <p>{}2019</p>

                    <p>Prijs:</p>
                    <p>{}50</p>

                    <p>Huurperiode: </p>
                    <p>{props.user.startdatum} - {props.user.einddatum}</p>
                </div>

                <div className="info-box-container2__div">
                    <p>Wettelijke naam: </p>
                    <p>{props.user.wettelijke_naam}</p>

                    <p>Adres: </p>
                    <p>{props.user.adresgegevens}</p>

                    <p>Reisaard: </p>
                    <p>{props.user.reisaard}</p>

                    <p>Verachte gereden km: </p>
                    <p>{props.user.verwachte_km} km</p>

                    <p>Verste bestemming: </p>
                    <p>{props.user.vereiste_bestemming}</p>
                </div>
            </div>
            <div className='reservering-container-action-buttons__div'>
                <button className='action-container__button' onClick={handleWijzigenButtonClick}>Wijzigen</button>
                <button className='action-container__button' onClick={handleAnnulerenButtonClick}>Annuleren</button>
            </div>
        </div>
    );
}

ContainerContent.propTypes = {
    user: PropTypes.object,
};