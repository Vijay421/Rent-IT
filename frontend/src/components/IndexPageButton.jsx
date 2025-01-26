import '../styles/IndexPageButton.css';
import {useNavigate} from "react-router-dom";

function IndexPageButton() {

    const navigate = useNavigate();

    return (
        <>
            <h1 className='index-page-title__h1'>CarAndAll</h1>
            <h2 className='index-page-title-desc__h2'>Huur zonder gedoe een voertuig, wanneer u maar wilt.</h2>
            <div className="Content">
                <div className="MainDivLeft">
                    <div className="ParticulierDiv">
                        <h3 className="ParticulierH1">Voertuig huren</h3>
                    </div>
                    <div className='ParticulierDiv2'>
                        <h4>Wilt u een van onze voertuigen huren en heeft u geen account? Geen account nodig! Klik gewoon op de onderstaande knop om het huurproces te starten!</h4>
                    </div>
                    <div className="ParticulierDiv3">
                        <button onClick={() => navigate("/huur-overzicht", {})} className="ButtonDivLeft">
                            Huren
                        </button>
                    </div>
                </div>


                <div className="MainDivRight">
                    <div className="ZakelijkDiv">
                        <h3 className="ZakelijkH1">Zakelijke gebruiker</h3>
                    </div>
                    <div className='ZakelijkDiv2'>
                        <h4>Bent u een bedrijf of gewoon iemand die voertuigen wil huren? Klik op de onderstaande knop om het proces van het aanmaken van een account te starten!</h4>
                    </div>
                    <div className="ZakelijkDiv3">
                        <button onClick={() => navigate("/registreren", {})} className="ButtonDivRight">
                            Account aanmaken
                        </button>

                        <button onClick={() => navigate("/registreren/bedrijf", {})} className="ButtonDivRight">
                            Bedrijfsaccount aanvragen
                        </button>
                    </div>
                </div>
            </div>
        </>
    );
}

export default IndexPageButton;
