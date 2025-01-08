import '../styles/SubscriptionOverview.css';
import {Link} from "react-router-dom";

function SubscriptionOverview()
{
    return(
        <main className='subs_overview'>
            <div className='overview_sub'>
                <h1 className="overview_title">Maand abonnement</h1>
                <hr className="horizontal-line"/>
                <h3>Voor ongelimiteerd huren:</h3>
                <p className="prijs__text">€150</p>
                <h3>per maand.</h3>

                <Link to='/abonnement'>
                    <button className='button'>Neem dit abonnement</button>
                </Link>

            </div>

            <div className='overview_sub'>
                <h1 className="overview_title">Pay-as-you-go</h1>
                <hr className="horizontal-line"/>
                <h3>Voor 20% korting op elk huurverzoek:</h3>
                <p className="prijs__text">€50</p>
                <h3>per maand.</h3>

                <Link to='/abonnement'>
                    <button className='button'>Neem dit abonnement</button>
                </Link>
            </div>
        </main>
    );
}

export default SubscriptionOverview;