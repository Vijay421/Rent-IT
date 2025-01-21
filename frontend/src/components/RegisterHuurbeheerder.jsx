import '../styles/RegisterBeheerder.css';
import '../styles/Register.css';
import {useRef, useState} from "react";

export default function RegisterHuurbeheerder() {

    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [companyRole, setCompanyRole] = useState("");
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

    function handleSetPhoneNumber(e) {
        setPhoneNumber(e.target.value);
    }

    function handleCompanyRole(e) {
        setCompanyRole(e.target.value);
    }

    async function submitForm() {
        // Don't submit when the form is invalid.
        if (!form.current.checkValidity()) {
            return;
        }

        const payload = {
            name: username,
            email,
            password,
            phoneNumber,
            bedrijfsrol: companyRole,
        };
        await register(payload);
    }

    return (
        <main className='register-beheerder-page'>
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
                            placeholder='Vul hier de naam in'
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
                            placeholder='Vul hier het e-mailadres in'
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
                            placeholder='Vul hier het wachtwoord in'
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
                            placeholder='Vul hier de telefoonnummer in'
                            minLength='5'
                            maxLength='15'
                            data-cy='phone'
                            required
                            value={phoneNumber}
                            onChange={handleSetPhoneNumber}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="company-role" className='register-box__input-text'>Bedrijfsrol:</label>
                        <input
                            id="company-role"
                            className='register-box__input-field'
                            type="text"
                            placeholder='Vul hier de bedrijfsrol in'
                            minLength='2'
                            maxLength='50'
                            data-cy='company-role'
                            required
                            value={companyRole}
                            onChange={handleCompanyRole}
                        />
                    </div>
                    <button className='register-box__button' type='submit' onClick={submitForm}
                            data-cy='submit'>Submit
                    </button>
                </form>

            </div>
        </main>
);
}

/**
 * Tries to create a zakelijke beheerder on the server.
 * 
 * @param {Object} payload 
 * @returns 
 */
async function register(payload) {
    try {
        const response = await fetch('https://localhost:53085/api/Bedrijf/zakelijke_beheerder', {
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
                window.alert("De zakelijke beheerder is aangemaakt!");
                break;

            case 422:
            case 409:
                const error = await response.text();
                window.alert(`Kon de zakelijke beheerder niet aanmaken: ${error}`);
                break;

            default:
                window.alert("Error tijdens het aanmaken");
                break;
        }
    } catch (error) {
        console.error('error when creating a zakelijke beheerder, or parsing the response:', error);
        window.alert("Error tijdens het aanmaken");
        throw error;
    }
}
