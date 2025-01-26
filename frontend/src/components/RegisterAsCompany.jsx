import '../styles/RegisterAsCompany.css';
import '../styles/Register.css';
import {useRef, useState} from "react";
import {Link} from "react-router-dom";

export default function RegisterAsCompany() {

    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [bedrijfsnaam, setBedrijfsnaam] = useState("");
    const [adres, setAdres] = useState("");
    const [kvkNummer, setKvkNummer] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [domein, setDomein] = useState("");
    const form = useRef(null);

    function handleUsername(e) {
        setUsername(e.target.value);
    }

    function handleEmail(e) {
        setEmail(e.target.value);
    }

    function handlePassword(e) {
        setPassword(e.target.value);
    }

    function handleBedrijfsnaam(e) {
        setBedrijfsnaam(e.target.value);
    }

    function handleAdres(e) {
        setAdres(e.target.value);
    }

    function handleKvkNummer(e) {
        setKvkNummer(e.target.value);
    }

    function handlePhoneNumber(e) {
        setPhoneNumber(e.target.value);
    }

    function handleDomein(e) {
        setDomein(e.target.value);
    }

    async function submitForm() {
        // Don't submit when the form is invalid.
        if (!form.current.checkValidity()) {
            return;
        }
        if (kvkNummer.length !== 12) {
            window.alert ("Uw Kwk-nummer moet 12 tekens lang zijn.");
            return;
        }

        const payload = {
            bedrijfsnaam,
            address: adres.length === 0 ? null : adres,
            kvk_nummer: kvkNummer,
            phoneNumber,
            domein,
            username,
            email,
            password,
        };
        await register(payload);
    }

    return (
        <main className='register-page'>
            <div className='register-box'>
                <h1 className='register-box__text'>Registeren</h1>
                <form ref={form} onSubmit={(e) => {
                    e.preventDefault();
                }}>
                    <div className="form-group">
                        <label htmlFor="username" className='register-box__input-text'>Naam:</label>
                        <input
                            id="username"
                            className='register-box__input-field'
                            type="text"
                            placeholder='Vul hier je naam in'
                            minLength='2'
                            maxLength='50'
                            data-cy='username'
                            required
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
                            minLength='5'
                            maxLength='255'
                            data-cy='email'
                            required
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
                            minLength='8'
                            maxLength='50'
                            data-cy='password'
                            required
                            value={password}
                            onChange={handlePassword}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="bedrijfsnaam" className='register-box__input-text'>Bedrijfsnaam:</label>
                        <input
                            id="bedrijfsnaam"
                            className='register-box__input-field'
                            type="text"
                            placeholder='Vul hier uw bedrijfsnaam in'
                            minLength='2'
                            maxLength='50'
                            data-cy='bedrijfsnaam'
                            required
                            value={bedrijfsnaam}
                            onChange={handleBedrijfsnaam}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="adres" className='register-box__input-text'>Adres:</label>
                        <input
                            id="adres"
                            className='register-box__input-field'
                            type="text"
                            placeholder='Vul hier uw adres in'
                            minLength='8'
                            maxLength='50'
                            data-cy='adres'
                            required
                            value={adres}
                            onChange={handleAdres}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="kvk-nummer" className='register-box__input-text'>KVK-nummer:</label>
                        <input
                            id="kvk-nummer"
                            className='register-box__input-field'
                            type="kvk-nummer"
                            placeholder='Vul hier uw KVK-nummer in'
                            value={kvkNummer}
                            onChange={handleKvkNummer}
                            minLength='12'
                            maxLength='12'
                            data-cy='kvk-nummer'
                            required
                            pattern="[0-9]*"
                            inputMode="numeric"
                            onKeyDown={(e) => {
                                if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight' && e.key !== 'Tab') {
                                    e.preventDefault();
                                }
                            }}
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
                            minLength='2'
                            maxLength='50'
                            data-cy='phone'
                            required
                            pattern="[0-9]*"
                            inputMode="numeric"
                            onKeyDown={(e) => {
                                if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight' && e.key !== 'Tab') {
                                    e.preventDefault();
                                }
                            }}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="domein" className='register-box__input-text'>Domein:</label>
                        <input
                            id="domein"
                            className='register-box__input-field'
                            type="text"
                            placeholder='Vul hier uw domein in'
                            minLength='2'
                            maxLength='50'
                            data-cy='domein'
                            required
                            value={domein}
                            onChange={handleDomein}
                        />
                    </div>
                    <button className='register-box__button' type='submit' onClick={submitForm}
                            data-cy='submit'>Submit
                    </button>
                </form>
                <nav className="register-box__hyperlinks">
                    <Link to="/login">Heeft u al een account? Klik hier om in te loggen</Link>
                    <Link to="/registreren">Wilt u registreren als particulier? Klik dan hier</Link>
                </nav>

            </div>
        </main>
);
}

/**
 * Tries to create a company on the server.
 * 
 * @param {Object} payload 
 * @returns 
 */
async function register(payload) {
    try {
        const response = await fetch('https://localhost:53085/api/Bedrijf', {
            method: 'POST',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(payload),
        });

        switch (response.status) {
            case 201:
            case 200:
                window.alert("Het bedrijf is aangemaakt!");
                break;

            case 422:
            case 409:
                const error = await response.text();
                window.alert(`Kon het bedrijf niet aanmaken: ${error}`);
                break;

            default:
                window.alert("Error tijdens het aanmaken");
                break;
        }
    } catch (error) {
        console.error('error when creating a company, or parsing the response:', error);
        window.alert("Error tijdens het aanmaken");
        throw error;
    }
}
