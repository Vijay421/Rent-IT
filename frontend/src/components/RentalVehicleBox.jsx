import '../styles/RentalVehicleBox.css';
import PropTypes from "prop-types";
import Temp from '../assets/toyota-corolla.png';
import {useState} from "react";

export function RentalAutoBox( {data} ) {
    const [showPopup, setShowPopup] = useState(true);

    function onHuurButtonClick() {
        alert(`De gebruiker heeft de ${data.merk} ${data.type} als voertuig geselecteerd`);
    }

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
                    onMouseEnter={() => {setShowPopup(true);}}
                    onMouseLeave={() => {setShowPopup(false);}}>
                    €{data.prijs.toFixed(2)}

                    {showPopup && (
                        <span className='rental-vehicle-huurprijs-popup__span'>
                            Huurprijs: €{data.prijs * 4} (4 x €{data.prijs})<br/>
                            Verzekering: €50<br/>
                            Belasting: €20<br/>
                            Benzine: €36<br/>
                            Kilometervergoeding: €0.36/km<br/>
                            Borg: €250
                        </span>
                    )}
                </p>
                <p className='rental-vehicle-kosten__p'>Totale huurkosten</p>
                <button id='rental-vehicle-huur-box__button' onClick={onHuurButtonClick}>Huur</button>
            </div>
        </div>
    );
}

export function RentalCaravanBox({data}) {
    const [showPopup, setShowPopup] = useState(false);

    function onHuurButtonClick() {
        alert(`De gebruiker heeft de ${data.merk} ${data.type} als voertuig geselecteerd`);
    }

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
                            Verzekering: €80<br/>
                            Belasting: €35<br/>
                            Benzine: €41<br/>
                            Kilometervergoeding: €0.58/km<br/>
                            Borg: €400
                        </span>
                    )}
                </p>
                <p className='rental-vehicle-kosten__p'>Totale huurkosten</p>
                <button id='rental-vehicle-huur-box__button' onClick={onHuurButtonClick}>Huur</button>
            </div>
        </div>
    );
}

export function RentalCamperBox({data}) {
    const [showPopup, setShowPopup] = useState(false);

    function onHuurButtonClick() {
        alert(`De gebruiker heeft de ${data.merk} ${data.type} als voertuig geselecteerd`);
    }

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
                <button id='rental-vehicle-huur-box__button' onClick={onHuurButtonClick}>Huur</button>
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
};