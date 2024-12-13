import '../styles/RentalVehicleBox.css';
import PropTypes from "prop-types";
import Temp from '../assets/toyota-corolla.png';
import {useEffect, useState} from "react";
import {Link} from "react-router-dom";

export function RentalAutoBox( { data, nieuwStartDatum, nieuwEindDatum } ) {
    const [showPopup, setShowPopup] = useState(false);
    const [StartDatum, setStartDatum] = useState(nieuwStartDatum);
    const [EindDatum, setEindDatum] = useState(nieuwEindDatum);

    useEffect(() => {
        setStartDatum(nieuwStartDatum);
        setEindDatum(nieuwEindDatum);
    }, [nieuwStartDatum, nieuwEindDatum]);


    return (
        <div className='rental-vehicle-box__div'>
            <div className='rental-vehicle-image__div'>
                <img src={Temp} className='rental-vehicle-image__img' alt={data.merk + " " + data.type}/>
            </div>
            <div className="rental-vehicle-data__div">
                <h3 className='rental-vehicle-auto__h3'>{data.merk} {data.type}</h3>
                <div className="rental-vehicle-data-columns__div">
                    <div className="rental-vehicle-data-column1__div">
                        <p className='rental-vehicle-title__p'>Kenteken</p>
                        <p className='rental-vehicle-info__p'>{data.kenteken}</p>
                        <p className='rental-vehicle-title__p'>Kleur</p>
                        <p className='rental-vehicle-info__p'>{data.kleur}</p>
                        <p className='rental-vehicle-title__p'>Aanschafjaar</p>
                        <p className='rental-vehicle-info__p'>{data.aanschafjaar}</p>
                    </div>
                    <div className="rental-vehicle-data-column2__div">
                        <p className='rental-vehicle-title__p'>Beschikbaarheid</p>
                        <p className='rental-vehicle-info__p'>{data.status}</p>
                    </div>
                </div>
            </div>

            <div className='rental-vehicle-huur-box__div'>
                <p
                    className='rental-vehicle-huurprijs__p'
                    onMouseEnter={() => {
                        setShowPopup(true);
                    }}
                    onMouseLeave={() => {
                        setShowPopup(false);
                    }}>
                    €{data.prijs.toFixed(2)}

                    {showPopup && (
                        <span className='rental-vehicle-huurprijs-popup__span'>
                            Huurprijs: €{data.prijs * 4} (4 x €{data.prijs})<br/>
                            Verzekering: €75<br/>
                            Belasting: €37<br/>
                            Benzine: €43<br/>
                            Kilometervergoeding: €0.61/km<br/>
                            Borg: €500
                        </span>
                    )}
                </p>
                <p className='rental-vehicle-kosten__p'>Totale huurkosten</p>
                <Link
                    to="/renting-submit"
                    state={{ vehicleData: data, startDatum: StartDatum, eindDatum: EindDatum }}
                    id='rental-vehicle-huur-box__button'>
                    Huur
                </Link>
            </div>
        </div>
    );
}


export function RentalCaravanBox({data, nieuwStartDatum, nieuwEindDatum}) {
    const [showPopup, setShowPopup] = useState(false);
    const [StartDatum, setStartDatum] = useState(nieuwStartDatum);
    const [EindDatum, setEindDatum] = useState(nieuwEindDatum);

    useEffect(() => {
        setStartDatum(nieuwStartDatum);
        setEindDatum(nieuwEindDatum);
    }, [nieuwStartDatum, nieuwEindDatum]);


        return (
            <div className='rental-vehicle-box__div'>
                <div className='rental-vehicle-image__div'>
                    <img src={Temp} className='rental-vehicle-image__img' alt={data.merk + " " + data.type}/>
                </div>

                <div className="rental-vehicle-data__div">
                    <h3 className='rental-vehicle-auto__h3'>{data.merk} {data.type}</h3>

                    <div className="rental-vehicle-data-columns__div">
                        <div className="rental-vehicle-data-column1__div">
                            <p className='rental-vehicle-title__p'>Kenteken</p>
                            <p className='rental-vehicle-info__p'>{data.kenteken}</p>

                            <p className='rental-vehicle-title__p'>Kleur</p>
                            <p className='rental-vehicle-info__p'>{data.kleur}</p>

                            <p className='rental-vehicle-title__p'>Aanschafjaar</p>
                            <p className='rental-vehicle-info__p'>{data.aanschafjaar}</p>
                        </div>

                        <div className="rental-vehicle-data-column2__div">
                            <p className='rental-vehicle-title__p'>Beschikbaarheid</p>
                            <p className='rental-vehicle-info__p'>{data.status}</p>
                        </div>
                    </div>
                </div>

                <div className='rental-vehicle-huur-box__div'>
                    <p
                        className='rental-vehicle-huurprijs__p'
                        onMouseEnter={() => {
                            setShowPopup(true);
                        }}
                        onMouseLeave={() => {
                            setShowPopup(false);
                        }}>
                        €{data.prijs.toFixed(2)}

                        {showPopup && (
                            <span className='rental-vehicle-huurprijs-popup__span'>
                            Huurprijs: €{data.prijs * 4} (4 x €{data.prijs})<br/>
                            Verzekering: €75<br/>
                            Belasting: €37<br/>
                            Benzine: €43<br/>
                            Kilometervergoeding: €0.61/km<br/>
                            Borg: €500
                        </span>
                        )}
                    </p>
                    <p className='rental-vehicle-kosten__p'>Totale huurkosten</p>
                    <Link
                        to="/renting-submit"
                        state={{ vehicleData: data, startDatum: StartDatum, eindDatum: EindDatum  }}
                        id='rental-vehicle-huur-box__button'>
                        Huur
                    </Link>
                </div>
            </div>
        );
}

export function RentalCamperBox({data, nieuwStartDatum, nieuwEindDatum}) {
    const [showPopup, setShowPopup] = useState(false);
    const [StartDatum, setStartDatum] = useState(nieuwStartDatum);
    const [EindDatum, setEindDatum] = useState(nieuwEindDatum);

    useEffect(() => {
        setStartDatum(nieuwStartDatum);
        setEindDatum(nieuwEindDatum);
    }, [nieuwStartDatum, nieuwEindDatum]);


    return (
        <div className='rental-vehicle-box__div'>
            <div className='rental-vehicle-image__div'>
                <img src={Temp} className='rental-vehicle-image__img' alt={data.merk + " " + data.type}/>
            </div>

            <div className="rental-vehicle-data__div">
                <h3 className='rental-vehicle-auto__h3'>{data.merk} {data.type}</h3>

                <div className="rental-vehicle-data-columns__div">
                    <div className="rental-vehicle-data-column1__div">
                        <p className='rental-vehicle-title__p'>Kenteken</p>
                        <p className='rental-vehicle-info__p'>{data.kenteken}</p>

                        <p className='rental-vehicle-title__p'>Kleur</p>
                        <p className='rental-vehicle-info__p'>{data.kleur}</p>

                        <p className='rental-vehicle-title__p'>Aanschafjaar</p>
                        <p className='rental-vehicle-info__p'>{data.aanschafjaar}</p>
                    </div>

                    <div className="rental-vehicle-data-column2__div">
                        <p className='rental-vehicle-title__p'>Beschikbaarheid</p>
                        <p className='rental-vehicle-info__p'>{data.status}</p>
                    </div>
                </div>
            </div>

            <div className='rental-vehicle-huur-box__div'>
                <p
                    className='rental-vehicle-huurprijs__p'
                    onMouseEnter={() => {
                        setShowPopup(true);
                    }}
                    onMouseLeave={() => {
                        setShowPopup(false);
                    }}>
                    €{data.prijs.toFixed(2)}

                    {showPopup && (
                        <span className='rental-vehicle-huurprijs-popup__span'>
                        Huurprijs: €{data.prijs * 4} (4 x €{data.prijs})<br/>
                        Verzekering: €75<br/>
                        Belasting: €37<br/>
                        Benzine: €43<br/>
                        Kilometervergoeding: €0.61/km<br/>
                        Borg: €500
                    </span>
                    )}
                </p>
                <p className='rental-vehicle-kosten__p'>Totale huurkosten</p>
                <Link
                    to="/renting-submit"
                    state={{ vehicleData: data, startDatum: StartDatum, eindDatum: EindDatum  }}
                    id='rental-vehicle-huur-box__button'>
                    Huur
                </Link>
            </div>
        </div>
    );
}

RentalAutoBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.number.isRequired,
        status: PropTypes.string.isRequired,
        prijs: PropTypes.number.isRequired,
        startDatum: PropTypes.string.isRequired,
        eindDatum: PropTypes.string.isRequired
    }).isRequired,
    nieuwStartDatum: PropTypes.any.isRequired,
    nieuwEindDatum: PropTypes.any.isRequired
};

RentalCaravanBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.number.isRequired,
        status: PropTypes.string.isRequired,
        prijs: PropTypes.number.isRequired,
        startDatum: PropTypes.string.isRequired,
        eindDatum: PropTypes.string.isRequired
    }).isRequired,
    nieuwStartDatum: PropTypes.any.isRequired,
    nieuwEindDatum: PropTypes.any.isRequired
};

RentalCamperBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.number.isRequired,
        status: PropTypes.string.isRequired,
        prijs: PropTypes.number.isRequired,
        startDatum: PropTypes.string.isRequired,
        eindDatum: PropTypes.string.isRequired
    }).isRequired,
    nieuwStartDatum: PropTypes.any.isRequired,
    nieuwEindDatum: PropTypes.any.isRequired
};