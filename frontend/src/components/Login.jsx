import {useState} from 'react';
import '../styles/Login.css';
import { Link } from 'react-router-dom';

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    function handleEmail(e) {
        setEmail(e.target.value);
    }

    function handlePassword(e) {
        setPassword(e.target.value);
    }

    return (
        <main className='login-page'>
            <div className='login-box'>
                <h1 className='login-box__text'>Login</h1>

                <form onSubmit={(e) => {
                    e.preventDefault();
                }}>
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

                    <button className='login-box__button' type='submit'>Login</button>

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
