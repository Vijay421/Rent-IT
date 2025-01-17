import '../styles/IndexPageButton.css';
import {Link} from "react-router-dom";

function IndexPageButton() {
    return (
        <div className="Content">
            <div className="MainDivLeft">
                <div className="ParticulierDiv">
                    <pre className="ParticulierH1">Start met huren!</pre>
                </div>
                <div className="infoDivLeft">
                    <pre className="infoDivLeft__Text">Huur nu zonder account!</pre>
                </div>
                <Link to='/huur-overzicht'>
                    <div className="ButtonDivLeft">
                        <pre className="BottomDivLeftHuren">Huren</pre>
                    </div>
                </Link>
            </div>
            <div className="MainDivRight">
                <div className="ZakelijkDiv">
                    <h1 className="ZakelijkH1">Registreren!</h1>
                </div>
                <div className="infoDivRight__Top">
                    <pre className="infoDivRight__Text">Registreer als particuliere huurder. Hierbij krijgt u toegang tot een persoonlijk huur dashboard.</pre>
                </div>
                <div className="infoDivRight__Bottom">
                    <pre className="infoDivRight__Text">Registreer als bedrijf. Hierbij kunt u werknemers toevoegen aan een abonnement.</pre>
                </div>
                <Link to='/registreren'>
                    <div className="ButtonDivRight__Particulier">
                        <pre className="BottomDivRightRegistreren">Als Particulier</pre>
                    </div>
                </Link>
                <Link to='/*'>
                    <div className="ButtonDivRight__Bedrijfsaccount">
                        <pre className="BottomDivRightRegistreren">Als Bedrijf</pre>
                    </div>
                </Link>
            </div>
        </div>
    );
}

export default IndexPageButton;
