import '../styles/Register.css';
import { useState } from "react";
import { Link } from "react-router-dom";

export default function Register() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [username, setUsername] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");

    function handleEmail(e) {
        setEmail(e.target.value);
    }

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
        <main className='register-page'>
            <div className='register-box'>
                <h1 className='register-box__text'>Registeren</h1>

                <form onSubmit={(e) => {
                    e.preventDefault();
                }}>
                    <div className="form-group">
                        <label htmlFor="username" className='register-box__input-text'>Naam:</label>
                        <input
                            id="username"
                            className='register-box__input-field'
                            type="text"
                            placeholder='Vul hier je naam in'
                            value={username}
                            onChange={handleUsername}
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="email" className='register-box__input-text'>E-mail adres:</label>
                        <input
                            id="email"
                            className='register-box__input-field'
                            type="email"
                            placeholder='Vul hier uw e-mailadres in'
                            value={email}
                            onChange={handleEmail}
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="password" className='register-box__input-text'>Wachtwoord:</label>
                        <input
                            id="password"
                            className='register-box__input-field'
                            type="password"
                            placeholder='Vul hier uw wachtwoord in'
                            value={password}
                            onChange={handlePassword}
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="phone" className='register-box__input-text'>Telefoonnummer:</label>
                        <input
                            id="phone"
                            className='register-box__input-field'
                            type="tel"
                            placeholder='Vul hier uw telefoonnummer in'
                            value={phoneNumber}
                            onChange={handlePhoneNumber}
                            maxLength="15"
                            pattern="[0-9]*"
                            inputMode="numeric"
                            onKeyDown={(e) => {
                                if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight') {
                                    e.preventDefault();
                                }
                            }}
                        />
                    </div>

                    <button className='register-box__button' type='submit'>Submit</button>
                </form>

                <nav className="register-box__hyperlinks">
                    <Link to="/login">Heb je al een account? Klik hier om in te loggen</Link>
                </nav>
            </div>
        </main>
    );
}
