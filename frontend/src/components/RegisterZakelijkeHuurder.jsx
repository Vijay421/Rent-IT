import '../styles/RegisterBeheerder.css';
import '../styles/Register.css';
import {useEffect, useRef, useState} from "react";

export default function RegisterZakelijkeHuurder() {

    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [address, setAddress] = useState("");
    const [invoiceAddress, setInvoiceAddress] = useState("");
    const [beheerders, setBeheerders] = useState([]);
    const [huurbeheerderId, setHuurbeheerderId] = useState(null);
    const form = useRef(null);

    useEffect(() => {
        const getData = async () => {
            const beheerders = await getBeheerders();
            setBeheerders(beheerders);
        };

        getData();
    }, []);

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

    function handleAddress(e) {
        setAddress(e.target.value);
    }

    function handleInvoiceAddress(e) {
        setInvoiceAddress(e.target.value);
    }

    function handleSelectedBeheerder(e) {
        const id = e.target.value;
        if (id === "none") {
            setHuurbeheerderId(null);
            return;
        }

        setHuurbeheerderId(id);
    }

    async function submitForm() {
        // Don't submit when the form is invalid.
        if (!form.current.checkValidity()) {
            return;
        }

        if (huurbeheerderId === null) {
            window.alert("Selecteer een huurbeheerder!");
            return;
        }

        const payload = {
            name: username,
            email,
            password,
            phoneNumber,
            address,
            factuuradres: invoiceAddress,
            huurbeheerderId,
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
                        <label htmlFor="address" className='register-box__input-text'>Adres:</label>
                        <input
                            id="address"
                            className='register-box__input-field'
                            type="text"
                            placeholder='Vul hier het adres in'
                            minLength='5'
                            maxLength='255'
                            data-cy='address'
                            required
                            value={address}
                            onChange={handleAddress}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="invoice-address" className='register-box__input-text'>Factuuradres:</label>
                        <input
                            id="invoice-address"
                            className='register-box__input-field'
                            type="text"
                            placeholder='Vul hier het factuuradres in'
                            minLength='5'
                            maxLength='255'
                            data-cy='invoice-address'
                            required
                            value={invoiceAddress}
                            onChange={handleInvoiceAddress}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="huurbeheerders" className='register-box__input-text'>Huurbeheerder:</label>
                        <select onChange={handleSelectedBeheerder} id="huurbeheerders" data-cy="select-huurbeheerder">
                            <option value="none">Geen</option>
                            {
                                beheerders.map((data, key) => (
                                    <option key={key} value={data.id}>{data.userName}</option>
                                ))
                            }
                        </select>
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
 * Tries to get the beheerders of the current logged-in company.
 * 
 * @returns 
 */
async function getBeheerders() {
    try {
        const response = await fetch('https://localhost:53085/api/Bedrijf/zakelijke_beheerders', {
            method: 'GET',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
        });

        if (response.ok) {
            return await response.json();
        } else {
            const error = await response.text();
            window.alert(`Kon de zakelijke huurder niet aanmaken: ${error}`);
        }
    } catch (error) {
        console.error('error when getting beheerders, or parsing the response:', error);
        window.alert("Error tijdens het ophalen");
        throw error;
    }
}

/**
 * Tries to create a zakelijke huurder on the server.
 * 
 * @param {Object} payload 
 * @returns 
 */
async function register(payload) {
    try {
        const response = await fetch('https://localhost:53085/api/Bedrijf/zakelijke_huurder', {
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
                window.alert("De zakelijke huurder is aangemaakt!");
                break;

            case 422:
            case 409:
                const error = await response.text();
                window.alert(`Kon de zakelijke huurder niet aanmaken: ${error}`);
                break;

            default:
                window.alert("Error tijdens het aanmaken");
                break;
        }
    } catch (error) {
        console.error('error when creating a zakelijke huurder, or parsing the response:', error);
        window.alert("Error tijdens het aanmaken");
        throw error;
    }
}
