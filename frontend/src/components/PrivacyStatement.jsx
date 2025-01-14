import '../styles/PrivacyStatement.css';
import React, { useContext, useState, useEffect } from 'react';
import { UserContext } from "./UserContext.jsx";

export default function PrivacyStatement() {
    const { userRole } = useContext(UserContext);

    const [privacyStatement, setPrivacyStatement] = useState('');
    const [newPrivacyStatement, setNewPrivacyStatement] = useState('');
    const [isLoading, setIsLoading] = useState(true);
    const [isUpdating, setIsUpdating] = useState(false);

    useEffect(() => {
        async function fetchPrivacyStatement() {
            try {
                const response = await fetch('https://localhost:53085/api/PrivacyStatement');
                if (!response.ok) {
                    throw new Error('Failed to fetch privacy statement');
                }
                const data = await response.json();
                setPrivacyStatement(data.statementText);
                setIsLoading(false);
            } catch (error) {
                console.error('Error fetching privacy statement:', error);
                setIsLoading(false);
            }
        }

        fetchPrivacyStatement();
    }, []);

    const handleInputChange = (event) => {
        setNewPrivacyStatement(event.target.value);
    };

    async function handlePrivacyButtonClick() {
        // setIsUpdating(true);
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
        } finally {
            setIsUpdating(false);
        }
    }

    // if (isLoading) {
    //     return <p>Loading privacy statement...</p>;
    // }

    return (
        <main className="Main-Content">
            <pre className="PrivacyStatement__div">
                {privacyStatement}

                {userRole === 'backoffice_medewerker' && (
                    <div className="backoffice-medewerker__Content">
                        <textarea
                            className="privacy-input"
                            placeholder="Enter the new privacy policy text here..."
                            value={newPrivacyStatement}
                            onChange={handleInputChange}
                            rows="6"
                            cols="50"
                        ></textarea>
                        <button
                            className="change-privacy-statement__button"
                            type="submit"
                            onClick={handlePrivacyButtonClick}
                            disabled={isUpdating}
                            data-cy="submit"
                        >
                            {isUpdating ? 'Updating...' : 'Change Statement'}
                        </button>
                    </div>
                )}
            </pre>
        </main>
    );
}
