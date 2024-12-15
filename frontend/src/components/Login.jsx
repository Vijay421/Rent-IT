import {useState, useContext, useRef} from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/Login.css';
import { Link } from 'react-router-dom';
import {AuthContext} from "./AuthContext.jsx";
import {UserContext} from "./UserContext.jsx";

function Login() {
    const navigate = useNavigate();

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const { login } = useContext(AuthContext);
    const { setUserRole, setUserName } = useContext(UserContext);

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

        await callLoginEndpoint(userData, status, login, navigate, setUserRole, setUserName);
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

/**
 *  Will try to perform a login with the given user credentials.
 * 
 * @param {Object} userData
 * @param {string} userData.email
 * @param {string} userData.password
 * @param {React.MutableRefObject<null>} status
 * @param {Function} login
 * @param {Navigate} navigate
 * @param {Function} setUserRole
 * @param {Function} setUserName
 * @returns
 */
async function callLoginEndpoint(userData, status, login, navigate, setUserRole, setUserName) {
    try {
        const response = await fetch('https://localhost:53085/auth/login?useCookies=true&useSessionCookies=true', {
            method: 'POST',

            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(userData)
        });

        if (response.ok) {
            login();

            try {
                const userClaims = await getUserClaims();
                sessionStorage.setItem('userClaims', JSON.stringify(userClaims));
                setUserRole(userClaims.role);
                setUserName(userClaims.userName);

                setTimeout(() => {
                    navigate('/profile');
                }, 1500);
            } catch (error) {
                status.current.textContent = 'Fout tijdens het inloggen';
                status.current.style.color = 'red';
                console.error('error when fetching the user claims.');

                return;
            }

            status.current.textContent = 'Inloggen is succesvol';
            status.current.style.color = 'green';

        } else {
            const responseData = await response.json();
            console.error('Error: ', responseData);

            status.current.textContent = 'Gebruikersnaam of wachtwoord is onjuist';
            status.current.style.color = 'red';
        }
    } catch (error) {
        console.error('Error: ', error);

        status.current.textContent = 'Kan niet inloggen wegens een servererror';
        status.current.style.color = 'red';
    }
}

/**
 * Will try to get the user claims of the current logged in user.
 * 
 * @returns {Object}
 */
async function getUserClaims() {
    const request = {
        method: 'GET',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
    };

    try {
        const response = await fetch('https://localhost:53085/api/User/claims', request);
        return await response.json();
    } catch (error) {
        console.error('error when sending user claims request, or parsing the response:', error);
        throw error;
    }
}

export default Login;
