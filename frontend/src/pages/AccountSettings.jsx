import 'react';
import Navbar from '../components/Navbar';
import '../styles/AccountSettings.css';

export default function AccountSettings() {
    return (
        <>
            <Navbar/>
            <main className='settings__main'>
                <form className='settings__form' onSubmit={(e) => e.preventDefault()}>

                    <h1 className='settings-title'>Accountinstellingen</h1>

                    <div className='settings__input-box settings__name-box'>
                        <label htmlFor="username">Naam:</label>
                        <input id="username" className='settings__input-field' type="text" placeholder='Vul hier je naam in' required/>
                    </div>

                    <div className='settings__input-box settings__email-box'>
                        <label htmlFor="email">E-mail adres:</label>
                        <input id="email" className='settings__input-field' type="email" placeholder='Vul hier je e-mail in' required/>
                    </div>

                    <div className='settings__input-box'>
                        <label htmlFor="password">Wachtwoord:</label>
                        <input id="password" className='settings__input-field' type="password" placeholder='Vul hier je wachtwoord in' required/>
                    </div>

                    <div className='settings__input-box'>
                        <label htmlFor="phone">Telefoonnummer:</label>
                        <input id="phone" className='settings__input-field' type="tel" inputMode="numeric" placeholder='Vul hier je telefoonnummer in' required/>
                    </div>

                    <div className='settings__input-box'>
                        <label htmlFor="phone">Adres:</label>
                        <input id="text" className='settings__input-field' inputMode="numeric" placeholder='Vul hier je adres in' minLength='5' maxLength='255' required/>
                    </div>

                    <nav className='settings__nav'>
                        <button className='settings__upload-button'>Update</button>
                    </nav>
                </form>
            </main>
        </>
    );
}
