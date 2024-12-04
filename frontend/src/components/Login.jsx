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
            // TODO: use the useCookie query parameter.
            const response = await fetch('https://localhost:53085/auth/login', {
                method: 'POST',
                headers: {
                    'content-type': 'application/problem+json'
                },
                body: JSON.stringify(userData)
            });

            if (response.ok) {
                const responseData = await response.json();

                // TODO: figure out if saving tokens (and other important data) in the local storage is save.
                localStorage.setItem('accessToken', responseData.accessToken);
                localStorage.setItem('refreshToken', responseData.refreshToken);

                status.current.textContent = 'Inloggen is succesvol';
                status.current.style.color = 'green';

                login();

                // TODO: fail the login if GetUserClaims throws an error. 
                const userClaims = await GetUserClaims(null, responseData.accessToken);

                // TODO: store the user claims in the session store, so they are deleted when the window closes.
                localStorage.setItem('userClaims', JSON.stringify(userClaims));

                // TODO: go to profile page, instead of refreshing the page.
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
                        <Link to="/wachtwoord-vergeten">Wachtwoord vergeten? Account hier herstellen</Link>
                        <Link to="/register">Geen account? Maak hier een account aan</Link>
                    </nav>
                </form>
            </div>
        </main>
    );
}

// TODO: handle the the errors correctly.
/**
 * Will try to get the user claims of the current logged in user. 
 * @param {Function} setResponse
 * @param {String} accessToken
 * @returns {Object}
 */
async function GetUserClaims(setResponse, accessToken) {
    const request = {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${accessToken}`,
        },
    };

    try {
        const response = await fetch('https://localhost:53085/api/ParticuliereUser/user', request);

        switch (response.status) {
            case 200:
                const user = await response.json();
                // setResponse({
                //     msg: 'de gebruiker is opgehaald',
                //     isError: false,
                // });
                console.log('user data', user);

                return user;

            case 400:
                const errorMsg = await response.text();
                // setResponse({
                //     msg: errorMsg,
                //     isError: true,
                // });
            break;

            default:
                // setResponse({
                //     msg: 'er is een serverfout opgetreden',
                //     isError: true,
                // });
            break;
        }
    } catch (error) {
        // setResponse({
        //     msg: 'er is een serverfout opgetreden',
        //     isError: true,
        // });
        console.error('error when sending get user data request, or parsing the response', error);
    }
}

export default Login;
