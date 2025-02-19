import '../styles/PrivacyStatement.css';
import { useContext, useState, useEffect } from 'react';
import { UserContext } from "./UserContext.jsx";

export default function PrivacyStatement() {
    const { userRole } = useContext(UserContext);

    const [privacyStatement, setPrivacyStatement] = useState('');
    const [newPrivacyStatement, setNewPrivacyStatement] = useState('');

    useEffect(() => {
        async function fetchPrivacyStatement() {
            try {
                const response = await fetch('https://localhost:53085/api/PrivacyStatement');
                if (!response.ok) {
                    throw new Error('Failed to fetch privacy statement');
                }
                const data = await response.json();
                setPrivacyStatement(data.statementText);
            } catch (error) {
                console.error('Error fetching privacy statement:', error);
            }
        }

        fetchPrivacyStatement();
    }, []);

    const handleInputChange = (event) => {
        setNewPrivacyStatement(event.target.value);
    };

    async function handlePrivacyButtonClick() {
        try {
            const response = await fetch('https://localhost:53085/api/PrivacyStatement', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                // TODO: change to 'same-origin' when in production.
                credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                body: JSON.stringify({
                    StatementText: newPrivacyStatement,
                }),
            });

            if (!response.ok) {
                throw new Error('Failed to update privacy statement');
            }

            const data = await response.json();
            setPrivacyStatement(data.statementText);
        } catch (error) {
            console.error('Error updating privacy statement:', error);
        }
    }

    return (
        <main className="Main-Content">
            <pre className="PrivacyStatement__div">
                <h1 className='privacy-statement-title__h1'>Privacybeleid</h1>
                {privacyStatement}

                {userRole === 'backoffice_medewerker' && (
                    <div className="backoffice-medewerker__Content">
                        <textarea
                            className="privacy-input"
                            placeholder="Vul de nieuwe privacy statement hier in..."
                            value={newPrivacyStatement}
                            onChange={handleInputChange}
                            cols="30"
                        ></textarea>
                        <button
                            className="change-privacy-statement__button"
                            type="submit"
                            onClick={handlePrivacyButtonClick}
                            data-cy="submit"
                        >
                            Change Statement
                        </button>
                    </div>
                )}
            </pre>
        </main>
    );
}
