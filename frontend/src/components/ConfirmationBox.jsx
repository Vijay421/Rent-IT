import '../styles/ConfirmationBox.css';

export default function ConfirmationBox() {


    return (
        <div className='confirmation-page-box__div'>
            <div className='confirmation-page-main__div'>
                <h1 className='confirmation-main-title__h1'>Gegevens</h1>

                <div className="confirmation-main-boxes__div">
                    <div className='confirmation-main-renter-box__div'>
                        <h2 className='renter-box-title__h2'>Huurder</h2>
                    </div>

                    <div className='confirmation-main-voertuig-box__div'>
                        <h2 className='voertuig-box-title__h2'>Voertuig</h2>

                        <div className='voertuig-box-columns__div'>
                            <div className='voertuig-box-column1__div'>
                                <p>Merk: </p>
                                <p>Model: </p>
                                <p>Kenteken: </p>
                                <p>Kleur: </p>
                                <p>Aanschafjaar: </p>
                            </div>

                            <div className='voertuig-box-column2__div'>
                                <p>Huurprijs: </p>
                                <p>Verzekering: </p>
                                <p>Belasting: </p>
                                <p>Benzine: </p>
                                <p>Kilometervergoeding: </p>
                                <p>Borg: </p>
                            </div>

                            <div className="voertuig-box-column3__div">
                                <p>Huurperiode:</p>
                                <p>Totale kosten:</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}