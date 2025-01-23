import PropTypes from "prop-types";
import '../styles/EmployeeBox.css';

export default function EmployeeBox({data}) {
    const amountOfDays = Math.floor((new Date(data.einddatum) - new Date(data.startdatum)) / (1000 * 60 * 60 * 24));

    const carPrice = data.voertuig.prijs * amountOfDays;
    const insurance = data.voertuig.soort === "Auto" ? 15.50 * amountOfDays : data.voertuig.soort === "Caravan" ? 22 * amountOfDays : 0;
    const fuel = data.voertuig.soort === "Auto" ? 50 : data.voertuig.soort === "Caravan" ? 0 : 100;
    const kmCharge = 0.23 * data.verwachte_km;
    const deposit = data.voertuig.soort === "Auto" ? 400 : data.voertuig.soort === "Caravan" ? 750 : 1500;
    const tax = (carPrice + insurance + kmCharge) * 0.21;
    const korting = 0; /*utilize later after adding korting column*/
    const totalCost = carPrice + insurance + fuel + kmCharge + deposit + tax - korting;

    return (
        <main className='employee-box__main'>
            <h2 className='employee-box-title__h2'>{data.wettelijke_naam}</h2>
            <div className="employee-box-details__div">
                <div className="employee-box-voertuig-details__div">
                    <div className="employee-box-voertuig__div">
                        <p className="employee-box-voertuig-title__p">Voertuig</p>
                        <p className="employee-box-voertuig-data__p">{data.voertuig.merk} {data.voertuig.type}</p>
                    </div>

                    <div className="employee-box-kenteken__div">
                        <p className="employee-box-voertuig-title__p">Kenteken</p>
                        <p className="employee-box-voertuig-data__p">{data.voertuig.kenteken}</p>
                    </div>

                    <div className="employee-box-kenteken__div">
                        <p className="employee-box-voertuig-title__p">Kleur</p>
                        <p className="employee-box-voertuig-data__p">{data.voertuig.kleur}</p>
                    </div>

                    <div className="employee-box-kenteken__div">
                        <p className="employee-box-voertuig-title__p">Aanschafjaar
                        </p>
                        <p className="employee-box-voertuig-data__p">{data.voertuig.aanschafjaar}</p>
                    </div>

                    <div className="employee-box-soort__div">
                        <p className="employee-box-voertuig-title__p">Soort</p>
                        <p className="employee-box-voertuig-data__p">{data.voertuig.soort}</p>
                    </div>
                </div>

                <div className="employee-box-huurperiode-details__div">
                    <div className="employee-box-huurperiode__div">
                        <p className="employee-box-huurperiode-title__p">Huurperiode</p>
                        <p className="employee-box-huurperiode-data__p">{data.startdatum} - {data.einddatum}</p>
                    </div>
                </div>

                <div className="employee-box-kosten-details__div">
                    <p className="employee-box-kosten-title__p">Kosten</p>
                    <div className="employee-box-totaal__div">
                        <p className="employee-box-kosten-data__p">€ {data.voertuig.prijs} p/d</p>
                        <p className="employee-box-kosten-data__p">€ {totalCost.toFixed(2)}*</p>
                    </div>
                </div>
            </div>
        </main>
    );
}

PropTypes.EmployeeBox = {};