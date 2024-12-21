import '../styles/Register.css';
import { useState, useRef, useContext } from "react";
import { Link } from "react-router-dom";
import getResponseClass from '../scripts/getResponseClass';
import { UserContext } from '../components/UserContext';

export default function Register() {
    const { userRole } = useContext(UserContext);

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [username, setUsername] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [address, setAddress] = useState("");
    const [role, setRole] = useState("backoffice_medewerker");
    const [response, setResponse] = useState({
        msg: "",
        isError: null,
    });
    const form = useRef(null);

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

    function handleAddress(e) {
        setAddress(e.target.value);
    }

    function handleRole(e) {
        setRole(e.target.value);
    }

    async function submitForm() {
        // Don't submit when the form is invalid.
        if (!form.current.checkValidity()) {
            return;
        }

        const payload = {
            name: username,
            email,
            phoneNumber,
            password,
            address: address.length === 0 ? null : address,
            role: role.length === 0 ? null : role,
        };

        await register(payload, setResponse, userRole);
    }

    const responseClass = getResponseClass(response, 'register-box__response-text');

    return (
        <main className='register-page'>
            <div className='register-box'>
                <h1 className='register-box__text'>Registeren</h1>

                { response.isError === null ? <></> : <p className={'register-box__response-text ' + responseClass}>{ response.msg }</p> }

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
                        <label htmlFor="phone" className='register-box__input-text'>Telefoonnummer:</label>
                        <input
                            id="phone"
                            className='register-box__input-field'
                            type="tel"
                            placeholder='Vul hier uw telefoonnummer in'
                            value={phoneNumber}
                            onChange={handlePhoneNumber}
                            minLength='5'
                            maxLength='15'
                            data-cy='phone'
                            required
                            pattern="[0-9]*"
                            inputMode="numeric"
                            onKeyDown={(e) => {
                                if (!/[0-9]/.test(e.key) && e.key !== 'Backspace' && e.key !== 'Delete' && e.key !== '+' && e.key !== 'ArrowLeft' && e.key !== 'ArrowRight') {
                                    e.preventDefault();
                                }
                            }}
                        />
                    </div>

                    { userRole !== "admin" && (
                        <div className="form-group">
                            <label htmlFor="adres" className='register-box__input-text'>Adres:</label>
                            <input
                                id="adres"
                                className='register-box__input-field'
                                type="text"
                                placeholder='Vul hier je adres in'
                                minLength='5'
                                maxLength='255'
                                data-cy='adres'
                                required
                                value={address}
                                onChange={handleAddress}
                            />
                        </div>
                    ) }

                    { userRole === "admin" && (
                        <div className="form-group">
                            <label htmlFor="rollen" className='register-box__input-text'>Rol:</label>
                            <select
                                className='register-box__input-field'
                                name="rollen"
                                id="rollen"
                                onChange={handleRole}
                            >
                                <option value="backoffice_medewerker">Backoffice</option>
                                <option value="frontoffice_medewerker">Frontoffice</option>
                            </select>
                        </div>
                    ) }

                    <button className='register-box__button' type='submit' onClick={submitForm} data-cy='submit' >Submit</button>
                </form>

                <nav className="register-box__hyperlinks">
                    <Link to="/login">Heb je al een account? Klik hier om in te loggen</Link>
                </nav>
            </div>
        </main>
    );
}

/**
 * Will try to register the user by calling the api.
 * When it fails an error message will be displayed in the ui.
 * Otherwise a success message will be shown instead.
 * @param {Object} payload 
 * @param {string} payload.name
 * @param {string} payload.email
 * @param {number} payload.phoneNumber
 * @param {string} payload.password
 * @param {string} payload.address
 * @param {Function} setResponse 
 * @param {string} userRole | null
 */
async function register(payload, setResponse, userRole) {
    const request = {
        method: 'POST',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(payload),
    };

    try {
        let url;
        if (userRole === "admin") {
            url = 'https://localhost:53085/api/Admin/employee';
        } else {
            url = 'https://localhost:53085/api/ParticuliereUser';
        }

        const response = await fetch(url, request);
        switch (response.status) {
            case 200:
            case 201:
                const user = await response.json();
                setResponse({
                    msg: 'de gebruiker is aangemaakt',
                    isError: false,
                });
                console.log(user);
            break;

            case 409:
            case 422:
            case 400:
                const errorMsg = await response.text();
                setResponse({
                    msg: errorMsg,
                    isError: true,
                });
            break;

            default:
                setResponse({
                    msg: 'er is een serverfout opgetreden',
                    isError: true,
                });
            break;
        }
    } catch (error) {
        setResponse({
            msg: 'er is een serverfout opgetreden',
            isError: true,
        });
        console.error('error when sending register request or parsing the response', error);
    }
}
