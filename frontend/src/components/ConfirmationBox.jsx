import '../styles/ConfirmationBox.css';

export default function ConfirmationBox() {


    return (
        <div className='confirmation-page-box__div'>
            <div className='confirmation-page-main__div'>
                <h1 className='confirmation-main-title__h1'>Gegevens</h1>

                <div className="confirmation-main-boxes__div">
                    <div className='confirmation-main-renter-box__div'>
                        <h2 className='renter-box-title__h2'>Huurder</h2>

                        <div className="renter-box-column__div">

                        </div>
                    </div>

                    <div className='confirmation-main-voertuig-box__div'>
                        <h2 className='voertuig-box-title__h2'>Voertuig</h2>

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
        </div>
    );
}