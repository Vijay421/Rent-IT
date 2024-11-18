import {useState} from 'react';
import '../styles/Login.css';


function Login() {


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
        <main className='login-box'>
            <h1 className='login-box__text'>Login</h1>

            <h2 className='login-box__input-text'>E-mail adres:</h2>
            <input className='login-box__input-field' type="text" value={email} onChange={handleEmail}/>

            <h2 className='login-box__input-text'>Wachtwoord:</h2>
            <input className='login-box__input-field' type='password' value={password} onChange={handlePassword}/>

            <button className='login-box__button' type='button'>Login</button>

            <nav className="login-box__hyperlinks">
                <a href="#">Wachtwoord vergeten? Account hier herstellen</a>
                <a href="#">Geen account? Maak hier een account aan</a>
            </nav>
        </main>
    );
}

export default Login;