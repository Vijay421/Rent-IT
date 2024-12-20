import {useState, useRef, useContext} from 'react';
import Navbar from '../components/Navbar';
import '../styles/AccountSettings.css';
import getResponseClass from '../scripts/getResponseClass';
import { useNavigate } from 'react-router-dom';
import { UserContext } from '../components/UserContext';

export default function AccountSettings() {
    const navigate = useNavigate();
    const { userRole } = useContext(UserContext);
    const isMedewerker = userRole === "backoffice_medewerker" || userRole === "frontoffice_medewerker";

    const [email, setEmail] = useState(null);
    const [password, setPassword] = useState(null);
    const [currentPassword, setCurrentPassword] = useState(null);
    const [username, setUsername] = useState(null);
    const [phoneNumber, setPhoneNumber] = useState(null);
    const [address, setAddress] = useState(null);
    const [deleteConfig, setDeleteConfig] = useState({
        clickedDelete: false,
        text: "Verwijder account",
    });
    const [response, setResponse] = useState({
        msg: null,
        isError: null,
    });
    const form = useRef(null);

    async function submit() {
        // Don't submit when the form is invalid.
        if (!form.current.checkValidity()) {
            return;
        }

        const userClaims = JSON.parse(sessionStorage.getItem('userClaims'));
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

        await updateSettings(payload, setResponse);
    }

    async function handleDeleteAccount() {
        if (!deleteConfig.clickedDelete) {
            setDeleteConfig({
                clickedDelete: true,
                text: "Daadwerkelijk verwijderen"
            });
        } else {
            if (await callDeleteUserEndpoint(setResponse)) {
                setTimeout(() => {
                    navigate('/');
                }, 1500);
            }
        }
    }

    function handleWontDelete() {
        setDeleteConfig({
            clickedDelete: false,
            text: "Verwijder account",
        });
    }

    const responseClass = getResponseClass(response, 'settings__response-text');

    return (
        <>
            <Navbar/>

            <main className='settings__main'>
                <form ref={form} className='settings__form' onSubmit={(e) => e.preventDefault()}>

                    <h1 className='settings-title'>Accountinstellingen</h1>

                    { response.msg != null ? <p className={'settings__response-text ' + responseClass}>{response.msg}</p> : <></> }

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
                            data-cy='username'
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
                            data-cy='email'
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
                            data-cy='currentPassword'
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
                            data-cy='updatedPassword'
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
                            data-cy='phone'
                        />
                    </div>

                    { !isMedewerker && (
                        <div className='settings__input-box'>
                            <label htmlFor="address">Adres:</label>
                            <input
                                id="address"
                                className='settings__input-field'
                                inputMode="numeric"
                                placeholder='Vul hier je adres in'
                                minLength='5'
                                maxLength='255'
                                onChange={e => setAddress(e.target.value.length === 0 ? null : e.target.value)}
                                data-cy='address'
                            />
                        </div>
                    ) }

                    <nav className='settings__nav'>
                        <button onClick={submit} className='settings__button' data-cy='submit'>Update</button>

                        <div className='settings_delete-buttons'>
                            <button onClick={handleDeleteAccount} className='settings__button settings__button--delete' data-cy='delete'>{deleteConfig.text}</button>

                            { deleteConfig.clickedDelete && <button onClick={handleWontDelete} className='settings__button settings__button--dont-delete'>Niet verwijderen</button> }
                        </div>
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
 * 
 * @param {Object} payload 
 * @param {number} payload.id
 * @param {string} payload.name
 * @param {string} payload.email
 * @param {number} payload.phoneNumber
 * @param {string} payload.password
 * @param {string | null} payload.address
 * @param {Function} setResponse
 */
async function updateSettings(payload, setResponse) {
    const request = {
        method: 'PUT',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(payload),
    };

    try {
        const response = await fetch(`https://localhost:53085/api/User/${payload.id}`, request);

        switch (response.status) {
            case 200:
                setResponse({
                    msg: 'de instellingen zijn geüpdated',
                    isError: false,
                });
            break;

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
                console.error('server error:', await response.text());
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

/**
 * Will attempt to delete the user account.
 * 
 * @param {Function} setResponse
 * @returns {boolean}
 */
async function callDeleteUserEndpoint(setResponse) {
    const request = {
        method: 'DELETE',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
    };

    try {
        const claimsData = sessionStorage.getItem('userClaims');
        if (claimsData === null) {
            setResponse({ msg: 'U bent niet ingelogd', isError: true});
            return false;
        }

        const claims = JSON.parse(claimsData);

        const response = await fetch(`https://localhost:53085/api/User/${claims.userId}`, request);

        if (response.ok) {
            setResponse({
                msg: 'Account verwijderd',
                isError: false,
            });

            return true;
        } else {
            setResponse({
                msg: await response.text(),
                isError: true,
            });
        }
    } catch {
        setResponse({
            msg: 'Er is een servererror opgetreden',
            isError: true,
        });
    }

    return false;
}
