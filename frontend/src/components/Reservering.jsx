import '../styles/Reservering.css';
import {useEffect, useState} from "react";
import PropTypes from "prop-types";

export default function Reservering() {
    const [userData, setUserData] = useState([]);

    useEffect(() => {
        fetchReserveringen();
    }, []);

    async function fetchReserveringen() {
        const userId = 1;

        const response = await fetch(`https://localhost:53085/api/Huur/${userId}`, {
            method: "GET",
            credentials: 'include',
            headers: {
                'content-type': 'application/json'
            },
        });
        const data = await response.json();
        setUserData(data);
    }

    function handleDelete(id) {
        setUserData((prevData) => prevData.filter((user) => user.id !== id));
    }

    return (
        <div className='content'>
            <div className="reserveringen-box__div">
                <h1 className='reserveringen-box-title__h1'>Reserveringen</h1>
                <div className="reservering-containers__div">
                    {userData.map((user) => (
                        <ContainerContent key={user.id} user={user} onDelete={handleDelete} />
                    ))}
                </div>
            </div>
        </div>
    );
}

function ContainerContent(props) {
    function handleWijzigenButtonClick() {
        console.log("wijzigen clicked");
    }

    async function handleAnnulerenButtonClick() {
        const response = await fetch(`https://localhost:53085/api/Huur/${props.user.id}`, {
            method: "DELETE",
            credentials: 'include',
            headers: {
                'content-type': 'application/json'
            },
        });

        if (response.ok) {
            props.onDelete(props.user.id);
        } else {
            console.error("Failed to delete reservation:", await response.text());
        }
    }


    return (
        <>
            <h2 className='reservering-nummer__h2'>Reservering #{props.user.id}</h2>
            <div className='reservering-container__div'>
                <div className='reservering-container-info-box__div'>
                    <div className="info-box-container1__div">
                        <p className='container1-title__p'>Merk:</p>
                        <p className='container1-data__p'>{props.user.voertuig.merk}</p>

                        <p className='container1-title__p'>Model:</p>
                        <p className='container1-data__p'>{props.user.voertuig.type}</p>

                        <p className='container1-title__p'>Kleur:</p>
                        <p className='container1-data__p'>{props.user.voertuig.kleur}</p>

                        <p className='container1-title__p'>Aanschafjaar:</p>
                        <p className='container1-data__p'>{props.user.voertuig.aanschafjaar}</p>

                        <p className='container1-title__p'>Prijs:</p>
                        <p className='container1-data__p'>€ {props.user.voertuig.prijs}</p>

                        <p className='container1-title__p'>Huurperiode: </p>
                        <p className='container1-data__p'>{props.user.voertuig.startDatum} - {props.user.voertuig.eindDatum}</p>
                    </div>

                    <div className="info-box-container2__div">
                        <p className='container2-title__p'>Wettelijke naam: </p>
                        <p className='container2-data__p'>{props.user.wettelijke_naam}</p>

                        <p className='container2-title__p'>Adres: </p>
                        <p className='container2-data__p'>{props.user.adresgegevens}</p>

                        <p className='container2-title__p'>Reisaard: </p>
                        <p className='container2-data__p'>{props.user.reisaard}</p>

                        <p className='container2-title__p'>Verachte gereden km: </p>
                        <p className='container2-data__p'>{props.user.verwachte_km} km</p>

                        <p className='container2-title__p'>Verste bestemming: </p>
                        <p className='container2-data__p'>{props.user.vereiste_bestemming}</p>
                    </div>
                </div>
                <div className='reservering-container-action-buttons__div'>
                    <button className='action-container__button' onClick={handleWijzigenButtonClick}>Reservering wijzigen
                    </button>
                    <button className='action-container__button' onClick={handleAnnulerenButtonClick}>Reservering
                        annuleren
                    </button>
                </div>
            </div>
        </>
    );
}

ContainerContent.propTypes = {
    user: PropTypes.object.isRequired,
    onDelete: PropTypes.func.isRequired,
};