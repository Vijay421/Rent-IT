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
                    <img src="../assets/Car1.webp" alt="aa"/>
                    <div className="ParticulierDiv">
                        <h3 className="ParticulierH1">Voertuig huren</h3>
                    </div>
                    <div className='ParticulierDiv2'>
                        <h4>Wilt u een van onze voertuigen huren? Klik op de onderstaande knop om het huurproces te starten!</h4>
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
                        <h4>Bent u een bedrijf dat voertuigen wil verhuren voor hun werknemers? Klik op de onderstaande knop om het aanvraagproces voor een zakelijk account te starten!</h4>
                    </div>
                    <div className="ZakelijkDiv3">
                        <button onClick={() => navigate("/*", {})} className="ButtonDivRight">
                            Zakelijk account aanvragen
                        </button>
                    </div>
                </div>
            </div>
        </>
    );
}

export default IndexPageButton;
