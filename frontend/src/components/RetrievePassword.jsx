import '../styles/RetrievePassword.css';
import {useState} from "react";


function RetrievePassword() {

    const [email, setEmail] = useState("");

    // // Handles action when typing in email field
    function handleEmail(e) {
        setEmail(e.target.value);
    }

    function handleRetrieveSubmitButtonClick() {
        if (email.length === 0) {
            alert("U moet een e-mailadres invullen");
        }
        else if (!email.includes("@") || !email.includes(".com")) {
            alert("Error: Verkeerd e-mailformaat");
        }
        else {
            alert("Nu zou het een e-mail moeten versturen, maar het is nog niet helemaal geïmplementeerd, dus hier is een alert :)");
        }
    }

    return (
        <main className='retrieve-password-page'>
            <div className='retrieve-password-box'>
                <h1 className='retrieve-password__text'>Wachtwoord Vergeten</h1>
                <h2 className='retrieve-password-desc__h2'>Vul hier uw e-mailadres in. Als dit overeenkomt met een account, ontvangt u een e-mail met herstelinstructies.</h2>
                <div className="retrieve-form-group">
                    <label htmlFor="retrieve-password-email" className='retrieve-password-box__input-text'>E-mail adres:</label>
                    <input
                        id="retrieve-password-email"
                        className='retrieve-password-box__input-field'
                        type="text"
                        placeholder="Vul hier uw e-mailadres in om uw vergeten wachtwoord op te vragen."
                        value={email}
                        onChange={handleEmail}
                    />
                </div>

                <button className='retrieve-password-box__button' type='submit' onClick={handleRetrieveSubmitButtonClick}>Stuur wachtwoord terughaal e-mail</button>


            </div>
        </main>
    )
}

export default RetrievePassword;
