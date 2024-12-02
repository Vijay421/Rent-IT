import {useState, useContext, useRef} from 'react';
import '../styles/Login.css';
import { Link } from 'react-router-dom';
import {AuthContext} from "./AuthContext.jsx";

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const { login } = useContext(AuthContext);

    const statusRef = useRef(null);

    function handleUsername(e) {
        setUsername(e.target.value);
    }

    function handlePassword(e) {
        setPassword(e.target.value);
    }

    async function handleLoginButtonClick() {
        const status = statusRef;

        const userData = {
            "email": username,
            "password": password,
            "twoFactorCode": "",
            "twoFactorRecoveryCode": ""
        };

        try {
            const response = await fetch('https://localhost:53085/auth/login', {
                method: 'POST',
                headers: {
                    'content-type': 'application/problem+json'
                },
                body: JSON.stringify(userData)
            });

            if (response.ok) {
                const responseData = await response.json();

                localStorage.setItem('accessToken', responseData.accessToken);
                localStorage.setItem('refreshToken', responseData.refreshToken);

                status.current.textContent = 'Inloggen is succesvol';
                status.current.style.color = 'green';

                login();

                setTimeout(() => {
                    window.location.href = '/';
                }, 1500);

            } else {
                const responseData = await response.json();
                console.error('Error: ', responseData);

                status.current.textContent = 'Gebruikersnaam of wachtwoord is onjuist';
                status.current.style.color = 'red';
            }
        } catch (error) {
            console.error('Error: ', error);
        }
    }

    return (
        <main className='login-page'>
            <div className='login-box'>
                <h1 className='login-box__text'>Login</h1>

                <form onSubmit={(e) => e.preventDefault()}>
                    <div className="form-group">
                        <label htmlFor="login-gebruikersnaam" className='login-box__input-text'>Gebruikersnaam:</label>
                        <input
                            id="login-gebruikersnaam"
                            className='login-box__input-field'
                            type="text"
                            placeholder="Vul hier uw gebruikersnaam in"
                            value={username}
                            onChange={handleUsername}
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="login-password" className='login-box__input-text'>Wachtwoord:</label>
                        <input
                            id="login-password"
                            className='login-box__input-field'
                            type='password'
                            placeholder="Vul hier uw wachtwoord in"
                            value={password}
                            onChange={handlePassword}
                        />
                    </div>

                    <p id='login-box__loginstatus' ref={statusRef}></p>

                    <button className='login-box__button' type='submit' onClick={handleLoginButtonClick}>Login</button>

                    <nav className="login-box__hyperlinks">
                        <a href="#">Wachtwoord vergeten? Account hier herstellen</a>
                        <Link to="/register">Geen account? Maak hier een account aan</Link>
                    </nav>
                </form>
            </div>
        </main>
    );
}

export default Login;