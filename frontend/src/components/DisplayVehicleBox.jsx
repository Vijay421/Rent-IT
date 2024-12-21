import Temp from "../assets/toyota-corolla.png";
import {useState} from "react";
import PropTypes from "prop-types";

export function DisplayAutoBox({ data, huurButtonStatus, onHuur }) {
    const [showPopup, setShowPopup] = useState(false);
    const huurButton = huurButtonStatus;

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
                        <p className='rental-vehicle-title__p'>Soort</p>
                        <p className='rental-vehicle-info__p'>{data.soort}</p>
                    </div>
                </div>
            </div>

            <div className='rental-vehicle-huur-box__div'>
                <p
                    className='rental-vehicle-huurprijs__p'
                    onMouseEnter={() => setShowPopup(true)}
                    onMouseLeave={() => setShowPopup(false)}>
                    €{data.prijs.toFixed(2)}

                    {showPopup && (
                        <span className='rental-vehicle-huurprijs-popup__span'>
                            Huurprijs: €{data.prijs} (Aantal dagen x €{data.prijs})<br/>
                            Verzekering: €75<br/>
                            Belasting: €37<br/>
                            Benzine: €43<br/>
                            Kilometervergoeding: €0.31/km<br/>
                            Borg: €500
                        </span>
                    )}
                </p>
                <p className='rental-vehicle-kosten__p'>Totale huurkosten</p>
                {huurButton && <button
                    id='rental-vehicle-huur-box__button'
                    onClick={onHuur}>
                    Huur
                </button>}
            </div>
        </div>
    );
}

DisplayAutoBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.number.isRequired,
        status: PropTypes.string.isRequired,
        prijs: PropTypes.number.isRequired,
        soort: PropTypes.string.isRequired,
    }).isRequired,
    huurButtonStatus: PropTypes.bool.isRequired,
    onHuur: PropTypes.func.isRequired,
};



export function DisplayCaravanBox({ data, huurButtonStatus, onHuur }) {
    const [showPopup, setShowPopup] = useState(false);
    const huurButton = huurButtonStatus;

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
                        <p className='rental-vehicle-title__p'>Soort</p>
                        <p className='rental-vehicle-info__p'>{data.soort}</p>
                    </div>
                </div>
            </div>

            <div className='rental-vehicle-huur-box__div'>
                <p
                    className='rental-vehicle-huurprijs__p'
                    onMouseEnter={() => setShowPopup(true)}
                    onMouseLeave={() => setShowPopup(false)}>
                    €{data.prijs.toFixed(2)}

                    {showPopup && (
                        <span className='rental-vehicle-huurprijs-popup__span'>
                            Huurprijs: €{data.prijs} (Aantal dagen x €{data.prijs})<br/>
                            Verzekering: €75<br/>
                            Belasting: €37<br/>
                            Benzine: €43<br/>
                            Kilometervergoeding: €0.31/km<br/>
                            Borg: €500
                        </span>
                    )}
                </p>
                <p className='rental-vehicle-kosten__p'>Totale huurkosten</p>
                {huurButton && <button
                    id='rental-vehicle-huur-box__button'
                    onClick={onHuur}>
                    Huur
                </button>}
            </div>
        </div>
    );
}

DisplayCaravanBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.number.isRequired,
        status: PropTypes.string.isRequired,
        prijs: PropTypes.number.isRequired,
        soort: PropTypes.string.isRequired,
    }).isRequired,
    huurButtonStatus: PropTypes.bool.isRequired,
    onHuur: PropTypes.func.isRequired,
};


export function DisplayCamperBox({ data, huurButtonStatus, onHuur }) {
    const [showPopup, setShowPopup] = useState(false);
    const huurButton = huurButtonStatus;

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
                        <p className='rental-vehicle-title__p'>Soort</p>
                        <p className='rental-vehicle-info__p'>{data.soort}</p>
                    </div>
                </div>
            </div>

            <div className='rental-vehicle-huur-box__div'>
                <p
                    className='rental-vehicle-huurprijs__p'
                    onMouseEnter={() => setShowPopup(true)}
                    onMouseLeave={() => setShowPopup(false)}>
                    €{data.prijs.toFixed(2)}

                    {showPopup && (
                        <span className='rental-vehicle-huurprijs-popup__span'>
                            Huurprijs: €{data.prijs} (Aantal dagen x €{data.prijs})<br/>
                            Verzekering: €75<br/>
                            Belasting: €37<br/>
                            Benzine: €43<br/>
                            Kilometervergoeding: €0.31/km<br/>
                            Borg: €500
                        </span>
                    )}
                </p>
                <p className='rental-vehicle-kosten__p'>Totale huurkosten</p>
                {huurButton && <button
                    id='rental-vehicle-huur-box__button'
                    onClick={onHuur}>
                    Huur
                </button>}
            </div>
        </div>
    );
}

DisplayCamperBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.number.isRequired,
        status: PropTypes.string.isRequired,
        prijs: PropTypes.number.isRequired,
        soort: PropTypes.string.isRequired,
    }).isRequired,
    huurButtonStatus: PropTypes.bool.isRequired,
    onHuur: PropTypes.func.isRequired,
};