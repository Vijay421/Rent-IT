import '../styles/SubscriptionOverview.css';
import {Link} from "react-router-dom";

function SubscriptionOverview()
{
    return(
        <main className='subs_overview'>
            <div className='overview_sub'>
                <h1 className="overview_title">Monthly Subscription</h1>
                insert image
                <p> TO-DO: voeg informatie toe over maandelijks abonnement</p>

                <Link to='/huur-overzicht'>
                    <button className='button'>Huren</button>
                </Link>

            </div>

            <div className='overview_sub'>
                <h1 className="overview_title">Pay-as-you-go</h1>

                insert image
                <p> TO-DO: voeg informatie toe over het pay-as-you-go abonnement</p>

                <Link to='/huur-overzicht'>
                    <button className='button'>Huren</button>
                </Link>
            </div>

        </main>
    );
}

export default SubscriptionOverview;