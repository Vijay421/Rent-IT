import "../styles/RentHistoryItem.css";
import Temp from '../assets/toyota-corolla.png';
import {useState} from "react";


export default function RentHistoryItem({ data }) {
    const [showPopup, setShowPopup] = useState(false);
    const altImageName = `${data.merk} ${data.type}`;

    return (
        <div className="rent-history-item">
            <div className="rent-history-item__vehicle-image-box">
                <img className="rent-history-item__vehicle-image-box--image" src={Temp} alt={altImageName} />
            </div>

            <h2 className="rent-history-item__title">{altImageName}</h2>

            <div className="rent-history-item__vehicle-details">
                <p className="rent-history-item__vehicle-title rent-history-item__vehicle-title--first">Kenteken</p>
                <p>{data.kenteken}</p>

                <p className="rent-history-item__vehicle-title">Kleur</p>
                <p>{data.kleur}</p>

                <p className="rent-history-item__vehicle-title">Aanschafjaar</p>
                <p>{data.aanschafjaar}</p>

                <p className="rent-history-item__vehicle-title">Soort</p>
                <p>{data.soort}</p>
            </div>

            <div className="rent-history-item__vehicle-period">
                <p className="rent-history-item__vehicle-title rent-history-item__vehicle-title--first">Huurperiode</p>
                <p>Van: {data.startdatum}</p>
                <p>Tot: {data.einddatum}</p>
                <p className="rent-history-item__vehicle-title">Reisaard</p>
                <p>{data.reisaard}</p>
            </div>

            <div className="rent-history-item__vehicle-costs">
                <p className="rent-history-item__vehicle-cost-title rent-history-item__vehicle-title rent-history-item__vehicle-title--first">Kosten</p>
                <p className="rent-history-item__vehicle-cost"
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
                            Belasting: €37<br/>
                            Benzine: €43<br/>
                            Kilometervergoeding: €0.31/km<br/>
                            Borg: €500
                        </span>
                )}</p>
            </div>
        </div>
    );
}
