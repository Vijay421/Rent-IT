import '../styles/IndexPageButton.css';
import {Link} from "react-router-dom";

function IndexPageButton() {
    return (
        <div className="Content">
            <div className="MainDivLeft">
                <div className="ParticulierDiv">
                    <h1 className="ParticulierH1">Particulier</h1>
                </div>
                <Link to='/renting'>
                    <div className="ButtonDivLeft">
                        <h1 className="BottomDivLeftHuren">Huren</h1>
                    </div>
                </Link>
            </div>
            <div className="MainDivRight">
                <div className="ZakelijkDiv">
                    <h1 className="ZakelijkH1">Zakelijk</h1>
                </div>

                <Link to='/renting'>
                    <div className="ButtonDivRight">
                        <h1 className="BottomDivRightHuren">Huren</h1>
                    </div>
                </Link>
            </div>
        </div>
    );
}

export default IndexPageButton;