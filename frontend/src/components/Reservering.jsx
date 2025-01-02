import '../styles/Reservering.css';
import {useContext, useEffect, useState} from "react";
import PropTypes from "prop-types";
import {useNavigate} from "react-router-dom";
import {UserContext} from "./UserContext.jsx";

export default function Reservering() {
    const {userId} = useContext(UserContext);

    const [userData, setUserData] = useState([]);

    useEffect(() => {
        fetchReserveringen();
    }, []);

    async function fetchReserveringen() {
        const response = await fetch(`https://localhost:53085/api/Huur`, {
            method: "GET",
            credentials: 'include',
            headers: {
                'content-type': 'application/json'
            },
        });
        const data = await response.json();
        setUserData(data);
        console.log(data);
    }

    function handleDelete(id) {
        setUserData((prevData) => prevData.filter((user) => user.id !== id));
    }

    return (
        <div className='content'>
            <div className="reserveringen-box__div">
                <h1 className='reserveringen-box-title__h1'>Reserveringen</h1>
                <div className="reservering-containers__div">
                    {userData
                        .filter((user) => {
                            if (user.startdatum !== null) {
                                const startDatum = new Date(user.startdatum).getTime();
                                const currentDate = new Date().getTime();
                                const difference = startDatum - currentDate;
                                const days = difference / (1000 * 3600 * 24);
                                return days > 3;
                            }
                            return false;
                        })
                        .map((user) => (
                        <ContainerContent key={user.id} user={user} onDelete={handleDelete} />
                        ))
                    }
                </div>
            </div>
        </div>
    );
}

function ContainerContent(props) {
    const navigate = useNavigate();

    function handleWijzigenButtonClick() {
        navigate('/reservering-wijziging',{ state: { user: props.user } });
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
                        <p className='container1-data__p'>€ {(props.user.voertuig.prijs).toFixed(2)}</p>

                        <p className='container1-title__p'>Huurperiode: </p>
                        <p className='container1-data__p'>
                            {new Date(props.user.startdatum).getDate()}-{new Date(props.user.startdatum).getMonth() + 1}-{new Date(props.user.startdatum).getFullYear()} - {new Date(props.user.einddatum).getDate()}-{new Date(props.user.einddatum).getMonth() + 1}-{new Date(props.user.einddatum).getFullYear()}</p>
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
                    <button className='action-container__button' onClick={handleWijzigenButtonClick}>Wijzigen</button>
                    <button className='action-container__button' onClick={handleAnnulerenButtonClick}>Annuleren</button>
                </div>
            </div>
        </>
    );
}

ContainerContent.propTypes = {
    user: PropTypes.object.isRequired,
    onDelete: PropTypes.func.isRequired,
};