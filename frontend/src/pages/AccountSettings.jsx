import {useState, useRef} from 'react';
import Navbar from '../components/Navbar';
import '../styles/AccountSettings.css';

export default function AccountSettings() {
    const [email, setEmail] = useState(null);
    const [password, setPassword] = useState(null);
    const [currentPassword, setCurrentPassword] = useState(null);
    const [username, setUsername] = useState(null);
    const [phoneNumber, setPhoneNumber] = useState(null);
    const [address, setAddress] = useState(null);
    const [response, setResponse] = useState({
        msg: "",
        isError: null,
    });
    const form = useRef(null);

    async function submit() {
        // Don't submit when the form is invalid.
        if (!form.current.checkValidity()) {
            return;
        }

        const userClaims = JSON.parse(localStorage.getItem('userClaims'));
        const accessToken = localStorage.getItem('accessToken');
        console.log(userClaims);
        const payload = {
            email: email === "" ? null : email,
            password: password === "" ? null: password,
            currentPassword: currentPassword === "" ? null : currentPassword,
            username: username === "" ? null : username,
            phoneNumber: phoneNumber === "" ? null : phoneNumber,
            address: address === "" ? null : address,
        };

        let payloadHasValues = false;
        for (const [_key, value] of  Object.entries(payload)) {
            if (value !== null) {
                payloadHasValues = true;
                break;
            }
        }

        payload.id = userClaims.userId;

        if (!payloadHasValues) {
            setResponse({
                msg: 'Vul minimaal 1 waarde in',
                isError: true,
            });
            return;
        }

        if (payload.password !== null && payload.currentPassword === null) {
            setResponse({
                msg: 'Vul het huidige wachtwoord in',
                isError: true,
            });
            return;
        }

        await updateSettings(payload, setResponse, accessToken);
    }

    // TODO: allow all fields to be optional, but at least one fields should be defined (unless the password has been changed, then current password needs to be defined as well).
    return (
        <>
            <Navbar/>

            <main className='settings__main'>
                <form ref={form} className='settings__form' onSubmit={(e) => e.preventDefault()}>

                    <h1 className='settings-title'>Accountinstellingen</h1>

                    { response.msg != null ? <p>{response.msg}</p> : <></> }

                    <div className='settings__input-box settings__name-box'>
                        <label htmlFor="username">Naam:</label>
                        <input
                            id="username"
                            className='settings__input-field'
                            type="text"
                            placeholder='Vul hier je naam in'
                            minLength='2'
                            maxLength='50'
                            onChange={e => setUsername(e.target.value)}
                        />
                    </div>

                    <div className='settings__input-box settings__email-box'>
                        <label htmlFor="email">E-mail adres:</label>
                        <input
                            id="email"
                            className='settings__input-field'
                            type="email"
                            placeholder='Vul hier je e-mail in'
                            minLength='5'
                            maxLength='255'
                            onChange={e => setEmail(e.target.value)}
                        />
                    </div>

                    <div className='settings__input-box'>
                        <label htmlFor="password">Huidig wachtwoord:</label>
                        <input
                            id="password"
                            className='settings__input-field'
                            type="password"
                            placeholder='Vul hier je huidige wachtwoord in'
                            minLength='8'
                            maxLength='50'
                            onChange={e => setCurrentPassword(e.target.value)}
                        />
                    </div>

                    <div className='settings__input-box'>
                        <label htmlFor="password">Wachtwoord:</label>
                        <input
                            id="password"
                            className='settings__input-field'
                            type="password"
                            placeholder='Vul hier je wachtwoord in'
                            minLength='8'
                            maxLength='50'
                            onChange={e => setPassword(e.target.value)}
                        />
                    </div>

                    <div className='settings__input-box'>
                        <label htmlFor="phone">Telefoonnummer:</label>
                        <input
                            id="phone"
                            className='settings__input-field'
                            type="tel"
                            inputMode="numeric"
                            placeholder='Vul hier je telefoonnummer in'
                            minLength='5'
                            maxLength='15'
                            onChange={e => setPhoneNumber(e.target.value)}
                        />
                    </div>

                    <div className='settings__input-box'>
                        <label htmlFor="address">Adres:</label>
                        <input
                            id="address"
                            className='settings__input-field'
                            inputMode="numeric"
                            placeholder='Vul hier je adres in'
                            minLength='5'
                            maxLength='255'
                            onChange={e => setAddress(e.target.value)}
                        />
                    </div>

                    <nav className='settings__nav'>
                        <button onClick={submit} className='settings__upload-button'>Update</button>
                    </nav>
                </form>
            </main>
        </>
    );
}

/**
 * Will try to update the user settings by calling the api.
 * When it fails an error message will be displayed in the ui.
 * Otherwise a success message will be shown instead.
 * @param {Object} payload 
 * @param {number} payload.id
 * @param {string} payload.name
 * @param {string} payload.email
 * @param {number} payload.phoneNumber
 * @param {string} payload.password
 * @param {string} payload.address
 * @param {string} accessToken
 * @param {Function} setResponse
 */
async function updateSettings(payload, setResponse, accessToken) {
    const request = {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${accessToken}`,
        },
        body: JSON.stringify(payload),
    };

    try {
        const response = await fetch(`https://localhost:53085/api/ParticuliereUser/${payload.id}`, request);

        switch (response.status) {
            case 204:
                // const user = await response.json();
                setResponse({
                    msg: 'de instellingen zijn geüpdated',
                    isError: false,
                });
                // console.log(user);
            break;

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
