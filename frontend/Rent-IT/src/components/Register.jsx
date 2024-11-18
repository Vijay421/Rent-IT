import '../styles/Register.css';
import {useState} from "react";

export default function Register() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    // // Handles action when typing in email field
    function handleEmail(e) {
        setEmail(e.target.value);
    }

    // Handles action when typing in password field
    function handlePassword(e) {
        setPassword(e.target.value);
    }

    return (
        <main className='register-box'>
            <h1 className='register-box__text'>Register</h1>

            <h2 className='register-box__input-text'>E-mail adres:</h2>
            <input className='register-box__input-field' type="text" value={email} onChange={handleEmail}/>

            <h2 className='register-box__input-text'>Wachtwoord:</h2>
            <input className='register-box__input-field' type='password' value={password} onChange={handlePassword}/>

            <button className='register-box__button' type='button'>Login</button>

            <nav className="register-box__hyperlinks">
                <a href="#">Wachtwoord vergeten? Account hier herstellen</a>
                <a href="#">Geen account? Maak hier een account aan</a>
            </nav>
        </main>
    );
}