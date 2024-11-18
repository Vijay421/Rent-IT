import '../styles/Register.css';
import {useState} from "react";

export default function Register() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [username, setUsername] = useState("");
    const [phoneNumber, setPhoneNumber] = useState();

    // // Handles action when typing in email field
    function handleEmail(e) {
        setEmail(e.target.value);
    }

    // Handles action when typing in password field
    function handlePassword(e) {
        setPassword(e.target.value);
    }

    function handleUsername(e) {
        setUsername(e.target.value);
    }

    function handlePhoneNumber(e) {
        setPhoneNumber(e.target.value);
    }

    return (
        <main className='register-box'>
            <h1 className='register-box__text'>Registeren</h1>

            <h2 className='register-box__input-text'>Naam:</h2>
            <input className='register-box__input-field' type="text" value={username} onChange={handleUsername}/>

            <h2 className='register-box__input-text'>E-mail adres:</h2>
            <input className='register-box__input-field' type="text" value={email} onChange={handleEmail}/>

            <h2 className='register-box__input-text'>Wachtwoord:</h2>
            <input className='register-box__input-field' type='password' value={password} onChange={handlePassword}/>

            <h2 className='register-box__input-text'>Telefoonnummer:</h2>
            <input className='register-box__input-field' type='tel' value={phoneNumber} onChange={handlePhoneNumber} maxLength='13' pattern="[0-9]*" inputMode='numeric' onKeyDown={(e) => {
                if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight') {
                    e.preventDefault();
                }
            }}
            />

            <button className='register-box__button' type='button'>Submit</button>

            <nav className="register-box__hyperlinks">
                <a href="#">Heb je al een account? Klik hier om in te loggen</a>
            </nav>
        </main>
    );
}