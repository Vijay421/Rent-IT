import PropTypes from "prop-types";
import '../styles/EmployeeBox.css';

export default function EmployeeBox({data}) {
    return (
        <main className='employee-box__main'>
            <h2 className='employee-box-title__h2'>{data.wettelijke_naam}</h2>
            <div className="employee-box-details__div">
                <div className="employee-box-voertuig-details__div">
                    <div className="employee-box-voertuig__div">
                        <p className="employee-box-voertuig-title__p">Voertuig</p>
                        <p className="employee-box-voertuig-data__p">{data.voertuig.merk}</p>
                    </div>

                    <div className="employee-box-kenteken__div">
                        <p className="employee-box-voertuig-title__p">Kenteken</p>
                        <p className="employee-box-voertuig-data__p">{data.voertuig.kenteken}</p>
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
                        <p className="employee-box-kosten-data__p">€ {data.voertuig.prijs} p/dag</p>
                        <p className="employee-box-kosten-data__p">€ 5100.00*</p>
                    </div>
                </div>
            </div>
        </main>
    );
}

PropTypes.EmployeeBox = {};