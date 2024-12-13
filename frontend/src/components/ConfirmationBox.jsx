import '../styles/ConfirmationBox.css';

export default function ConfirmationBox() {


    function handleAkkoordButtonClick() {
        console.log('clicked');
    }

    return (
        <div className='confirmation-page-box__div'>
            <div className='confirmation-page-main__div'>
                <h1 className='confirmation-main-title__h1'>Bevestigingspagina</h1>
                <h2 className='confirmation-main-title__h2'>Controleer of alle onderstaande informatie correct is</h2>

                <div className="confirmation-main-boxes__div">
                    <div className='confirmation-main-renter-box__div'>
                        <h3 className='renter-box-title__h2'>Huurder</h3>

                        <div className="renter-box-column__div">
                            <p>Klant naam: </p>
                            <p>John Doe </p>

                            <p>Huisadres:</p>
                            <p>Johanna Westerdijkplein 75</p>

                            <p>Stad:</p>
                            <p>Den Haag</p>

                            <p>Postcode:</p>
                            <p>2521 EP</p>

                            <p>Rijbewijsnummer: </p>
                            <p>0000000000</p>

                            <p>Email: </p>
                            <p>johndoe@hotmail.com </p>

                            <p>Reisaard: </p>
                            <p>example </p>

                            <p>Verste bestemming: </p>
                            <p>Hamburg </p>

                            <p>Verwachte gereden km: </p>
                            <p>1875 </p>
                        </div>
                    </div>

                    <div className='confirmation-main-voertuig-box__div'>
                        <h3 className='voertuig-box-title__h2'>Voertuig</h3>

                        <div className='voertuig-box-columns__div'>
                            <div className='voertuig-box-column1__div'>
                                <p>Merk:</p>
                                <p>Toyota</p>

                                <p>Model:</p>
                                <p>Corolla</p>

                                <p>Kenteken:</p>
                                <p>AB-CDEF-12</p>

                                <p>Kleur:</p>
                                <p>Rood</p>

                                <p>Aanschafjaar:</p>
                                <p>2012</p>
                            </div>

                            <div className='voertuig-box-column2__div'>
                                <p>Huurprijs:</p>
                                <p>€50</p>
                                <p>Verzekering:</p>
                                <p>€40</p>
                                <p>Belasting:</p>
                                <p>€26</p>
                                <p>Benzine:</p>
                                <p>€20</p>
                                <p>Km vergoeding:</p>
                                <p>€0.36/km</p>
                                <p>Borg:</p>
                                <p>€400</p>
                            </div>

                            <div className="voertuig-box-column3__div">
                                <p className='voertuig-box-column3-title1-paragraph__p'>Huurperiode</p>
                                <p className='voertuig-box-column3-title2-paragraph__p'>Totale kosten</p>
                            </div>
                            <div className="voertuig-box-column4__div">
                                <p className='voertuig-box-column3-answer1-paragraph__p'>00-00-0000 – 00-00-0000</p>
                                <p className='voertuig-box-column3-answer2-paragraph__p'>€526.78</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div className="confirmation-page-button-box__div">
                <h3 className='confirmation-button-box__h3'>Ik (huurder) bevestig hierbij dat alle hierboven weergegeven gegevens correct zijn en ga akkoord met het verzenden van dit verzoek en het openen van de betaalpagina.</h3>
                <button onClick={handleAkkoordButtonClick} className='confirmation-button-box__button'>Akkoord</button>
            </div>
        </div>
    );
}