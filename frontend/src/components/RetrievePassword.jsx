import '../styles/RetrievePassword.css';
import {useState} from "react";


function RetrievePassword() {

    const [email, setEmail] = useState("");

    // // Handles action when typing in email field
    function handleEmail(e) {
        setEmail(e.target.value);
    }

    return (
        <main className='retrieve-password-page'>
            <div className='retrieve-password-box'>
                <h1 className='retrieve-password__text'>Wachtwoord Vergeten</h1>

                <div className="form-group">
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

                <button className='retrieve-password-box__button' type='submit'>Stuur wachtwoord terughaal e-mail</button>


            </div>
        </main>
    )
}

export default RetrievePassword;
