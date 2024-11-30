import {useState, useContext} from 'react';
import '../styles/Login.css';
import { Link } from 'react-router-dom';
import {AuthContext} from "./AuthContext.jsx";

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const { login } = useContext(AuthContext);

    function handleEmail(e) {
        setEmail(e.target.value);
    }

    function handlePassword(e) {
        setPassword(e.target.value);
    }

    async function handleLoginButtonClick() {
        const status = document.getElementById('login-box__loginstatus');

        const userData = {
            "email": email,
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
                console.log('Login successful', responseData);

                localStorage.setItem('accessToken', responseData.accessToken);
                localStorage.setItem('refreshToken', responseData.refreshToken);

                status.textContent = 'Inloggen is succesvol';
                status.style.color = 'green';

                login();
            } else {
                const responseData = await response.json();
                console.log('Error: ', responseData);

                status.textContent = 'E-mailadres of wachtwoord is onjuist';
                status.style.color = 'red';
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
                        <label htmlFor="login-email" className='login-box__input-text'>E-mail adres:</label>
                        <input
                            id="login-email"
                            className='login-box__input-field'
                            type="text"
                            placeholder="Vul hier uw e-mailadres in"
                            value={email}
                            onChange={handleEmail}
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

                    <p id='login-box__loginstatus'></p>

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