import "../styles/RentHistoryItem.css";
import Temp from '../assets/toyota-corolla.png';


export default function RentHistoryItem({ data }) {
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
                <p className="rent-history-item__vehicle-cost">€{data.prijs.toFixed(2)}</p>
            </div>
        </div>
    );
}
