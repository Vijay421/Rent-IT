import '../styles/RentalVehicleBox.css';
import PropTypes from "prop-types";
import Temp from '../assets/toyota-corolla.png';
import {useEffect, useState} from "react";
import {useNavigate} from "react-router-dom";

export function RentalAutoBox({ data, nieuwStartDatum, nieuwEindDatum }) {
    const [showPopup, setShowPopup] = useState(false);
    const [StartDatum, setStartDatum] = useState("");
    const [EindDatum, setEindDatum] = useState("");

    const navigate = useNavigate();

    useEffect(() => {
        setStartDatum(nieuwStartDatum);
        setEindDatum(nieuwEindDatum);
    }, [nieuwStartDatum, nieuwEindDatum]);

    const checkDatumFields = (e) => {
        if (StartDatum === "" && EindDatum === "") {
            e.preventDefault();
            alert("Startdatum en Einddatum moeten beide ingevuld zijn voordat u kunt huren.");
        } else if (StartDatum === "") {
            e.preventDefault();
            alert("Startdatum moet worden ingevuld.");
        } else if (EindDatum === "" && StartDatum !== "") {
            e.preventDefault();
            alert("Einddatum moet worden ingevuld.");
        } else {
            navigate("/huur-indienen", {
                state: { vehicleData: data, startDatum: StartDatum, eindDatum: EindDatum }
            });
        }
    };

    return (
        <div className='rental-vehicle-box__div' data-cy="vehicle" data-start-date={data.startDatum} data-end-date={data.eindDatum}>
            <div className='rental-vehicle-image__div'>
                <img src={Temp} className='rental-vehicle-image__img' alt={data.merk + " " + data.type}/>
            </div>
            <div className="rental-vehicle-data__div">
                <h3 className='rental-vehicle-auto__h3' data-cy="brand-type">{data.merk} {data.type}</h3>
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
                        <p className='rental-vehicle-info__p' data-cy="status">{data.status}</p>

                        <p className='rental-vehicle-title__p'>Soort</p>
                        <p className='rental-vehicle-info__p' data-cy="kind">{data.soort}</p>
                    </div>
                </div>
            </div>

            <div className='rental-vehicle-huur-box__div'>
                <h2
                    className='rental-vehicle-huurprijs__p'
                    onMouseEnter={() => {
                        setShowPopup(true);
                    }}
                    onMouseLeave={() => {
                        setShowPopup(false);
                    }}
                    data-cy="price"
                >
                    €{data.prijs.toFixed(2)}*

                    {showPopup && (
                        <span className='rental-vehicle-huurprijs-popup__span'>
                            Huurprijs: €{data.prijs.toFixed(2)} (Aantal dagen x €{data.prijs.toFixed(2)})<br/>
                            Verzekering: €75<br/>
                            Belasting: €37<br/>
                            Benzine: €43<br/>
                            Kilometervergoeding: €0.31/km<br/>
                            Borg: €500
                        </span>
                    )}
                </h2>
                <p className='rental-vehicle-kosten__p'>per dag</p>
                <button
                    onClick={checkDatumFields}
                    id='rental-vehicle-huur-box__button'
                    data-cy="rent"
                >
                    Huur
                </button>
            </div>
        </div>
    );
}


export function RentalCaravanBox({data, nieuwStartDatum, nieuwEindDatum}) {
    const [showPopup, setShowPopup] = useState(false);
    const [StartDatum, setStartDatum] = useState("");
    const [EindDatum, setEindDatum] = useState("");

    const navigate = useNavigate();

    useEffect(() => {
        setStartDatum(nieuwStartDatum);
        setEindDatum(nieuwEindDatum);
    }, [nieuwStartDatum, nieuwEindDatum]);

    const checkDatumFields = (e) => {
        if (StartDatum === "" && EindDatum === "") {
            e.preventDefault();
            alert("Startdatum en Einddatum moeten beide ingevuld zijn voordat u kunt huren.");
        } else if (StartDatum === "") {
            e.preventDefault();
            alert("Startdatum moet worden ingevuld.");
        } else if (EindDatum === "" && StartDatum !== "") {
            e.preventDefault();
            alert("Einddatum moet worden ingevuld.");
        } else {
            navigate("/huur-indienen", {
                state: { vehicleData: data, startDatum: StartDatum, eindDatum: EindDatum }
            });
        }
    };

        return (
            <div className='rental-vehicle-box__div' data-cy="vehicle" data-start-date={data.startDatum} data-end-date={data.eindDatum}>
                <div className='rental-vehicle-image__div'>
                    <img src={Temp} className='rental-vehicle-image__img' alt={data.merk + " " + data.type}/>
                </div>

                <div className="rental-vehicle-data__div">
                    <h3 className='rental-vehicle-auto__h3' data-cy="brand-type">{data.merk} {data.type}</h3>

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
                            <p className='rental-vehicle-info__p' data-cy="status">{data.status}</p>

                            <p className='rental-vehicle-title__p'>Soort</p>
                            <p className='rental-vehicle-info__p' data-cy="kind">{data.soort}</p>
                        </div>
                    </div>
                </div>

                <div className='rental-vehicle-huur-box__div'>
                    <h2
                        className='rental-vehicle-huurprijs__p'
                        onMouseEnter={() => {
                            setShowPopup(true);
                        }}
                        onMouseLeave={() => {
                            setShowPopup(false);
                        }}>
                        €{data.prijs.toFixed(2)}*

                        {showPopup && (
                            <span className='rental-vehicle-huurprijs-popup__span'>
                            Huurprijs: €{data.prijs.toFixed(2)} (Aantal dagen x €{data.prijs.toFixed(2)})<br/>
                            Verzekering: €65<br/>
                            Belasting: €62<br/> {/*21%*/}
                            Benzine: €0<br/>
                            Kilometervergoeding: €0.50/km<br/>
                            Borg: €750
                        </span>
                        )}
                    </h2>
                    <p className='rental-vehicle-kosten__p'>per dag</p>
                    <button
                        onClick={checkDatumFields}
                        id='rental-vehicle-huur-box__button'
                        data-cy="rent"
                    >
                        Huur
                    </button>
                </div>
            </div>
        );
}

export function RentalCamperBox({data, nieuwStartDatum, nieuwEindDatum}) {
    const [showPopup, setShowPopup] = useState(false);
    const [StartDatum, setStartDatum] = useState("");
    const [EindDatum, setEindDatum] = useState("");

    const navigate = useNavigate();

    useEffect(() => {
        setStartDatum(nieuwStartDatum);
        setEindDatum(nieuwEindDatum);
    }, [nieuwStartDatum, nieuwEindDatum]);

    const checkDatumFields = (e) => {
        if (StartDatum === "" && EindDatum === "") {
            e.preventDefault();
            alert("Startdatum en Einddatum moeten beide ingevuld zijn voordat u kunt huren.");
        } else if (StartDatum === "") {
            e.preventDefault();
            alert("Startdatum moet worden ingevuld.");
        } else if (EindDatum === "" && StartDatum !== "") {
            e.preventDefault();
            alert("Einddatum moet worden ingevuld.");
        } else {
            navigate("/huur-indienen", {
                state: { vehicleData: data, startDatum: StartDatum, eindDatum: EindDatum }
            });
        }
    };

    return (
        <div className='rental-vehicle-box__div' data-cy="vehicle" data-start-date={data.startDatum} data-end-date={data.eindDatum}>
            <div className='rental-vehicle-image__div'>
                <img src={Temp} className='rental-vehicle-image__img' alt={data.merk + " " + data.type}/>
            </div>

            <div className="rental-vehicle-data__div">
                <h3 className='rental-vehicle-auto__h3' data-cy="brand-type">{data.merk} {data.type}</h3>

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
                        <p className='rental-vehicle-info__p' data-cy="status">{data.status}</p>

                        <p className='rental-vehicle-title__p'>Soort</p>
                        <p className='rental-vehicle-info__p' data-cy="kind">{data.soort}</p>
                    </div>
                </div>
            </div>

            <div className='rental-vehicle-huur-box__div'>
                <h2
                    className='rental-vehicle-huurprijs__p'
                    onMouseEnter={() => {
                        setShowPopup(true);
                    }}
                    onMouseLeave={() => {
                        setShowPopup(false);
                    }}>
                    €{data.prijs.toFixed(2)}*

                    {showPopup && (
                        <span className='rental-vehicle-huurprijs-popup__span'>
                        Huurprijs: €{data.prijs.toFixed(2)} (Aantal dagen x €{data.prijs.toFixed(2)})<br/>
                        Verzekering: €75<br/>
                        Belasting: €37<br/> {/*21%*/}
                        Benzine: €60<br/>
                        Kilometervergoeding: €0.61/km<br/>
                        Borg: €1500
                    </span>
                    )}
                </h2>
                <p className='rental-vehicle-kosten__p'>per dag</p>
                <button
                    onClick={checkDatumFields}
                    id='rental-vehicle-huur-box__button'
                    data-cy="rent"
                >
                    Huur
                </button>
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
        eindDatum: PropTypes.string.isRequired,
        soort: PropTypes.string.isRequired,
    }).isRequired,
    nieuwStartDatum: PropTypes.any,
    nieuwEindDatum: PropTypes.any
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
        eindDatum: PropTypes.string.isRequired,
        soort: PropTypes.string.isRequired,
    }).isRequired,
    nieuwStartDatum: PropTypes.any,
    nieuwEindDatum: PropTypes.any
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
        eindDatum: PropTypes.string.isRequired,
        soort: PropTypes.string.isRequired,
    }).isRequired,
    nieuwStartDatum: PropTypes.any,
    nieuwEindDatum: PropTypes.any
};
