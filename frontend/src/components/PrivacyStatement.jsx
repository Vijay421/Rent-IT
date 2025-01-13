import '../styles/PrivacyStatement.css';
import React, {useContext} from 'react';
import {UserContext} from "./UserContext.jsx";

export default function PrivacyStatement() {
    const { userRole } = useContext(UserContext);

    return (
        <main className="Main-Content">
            <div className="PrivacyStatement__div">
                <p>
                    <strong>Privacybeleid</strong><br/><br/>
                    <strong>Ingangsdatum:</strong> 13 januari 2025<br/><br/>
                    Car Rent All zet zich in voor de bescherming van uw privacy. Dit Privacybeleid legt uit hoe wij uw
                    informatie verzamelen, gebruiken en delen.<br/><br/>
                    <strong>1. Informatie die wij verzamelen</strong><br/>
                    - <strong>Persoonlijke informatie:</strong> Naam, e-mail, telefoonnummer en adres.<br/>
                    - <strong>Niet-persoonlijke informatie:</strong> Browsertype, IP-adres, apparaatgegevens en
                    gebruikspatronen.<br/>
                    - <strong>Cookies:</strong> Gebruikt voor functionaliteit en analyse; aan te passen via
                    browserinstellingen.<br/><br/>
                    <strong>2. Gebruik van informatie</strong><br/>
                    Wij gebruiken uw informatie om:<br/>
                    - Diensten te leveren en te verbeteren<br/>
                    - Transacties te verwerken<br/>
                    - Met u te communiceren<br/>
                    - Websiteprestaties te analyseren en te verbeteren<br/><br/>
                    <strong>3. Delen van informatie</strong><br/>
                    Wij verkopen uw informatie niet. We kunnen gegevens delen met serviceproviders, voldoen aan
                    wettelijke vereisten of tijdens bedrijfsovergangen.<br/><br/>
                    <strong>4. Uw rechten</strong><br/>
                    U kunt:<br/>
                    - Uw gegevens inzien, corrigeren of verwijderen<br/>
                    - Afzien van marketing<br/>
                    - Gegevensvoorkeuren beheren<br/><br/>
                    Neem contact met ons op via aubmailonsniet@gmail.com om uw rechten uit te oefenen.<br/><br/>
                    <strong>5. Beveiliging</strong><br/>
                    Wij nemen maatregelen om uw gegevens te beschermen, maar kunnen absolute veiligheid niet garanderen.<br/><br/>
                    <strong>6. Neem contact met ons op</strong><br/>
                    Vragen? Neem contact met ons op via:<br/>
                    Car Rent All<br/>
                    wijreagerenwellicht@gmail.com<br/>
                    Dat ronde gebouw, Den Haag
                </p>
                {userRole === 'backoffice_medewerker' && (
                    <div className="backoffice-medewerker__Content">
                        <p>hier komt button om shit te veranderen.</p>
                    </div>
                )}
            </div>
        </main>
    );
}

// Alle tekst moet in een <pre> komen voor sql injection tegen te gaan.
// HttpPut request om de p tag te veranderen.
