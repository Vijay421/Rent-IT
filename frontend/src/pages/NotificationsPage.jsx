import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import { useEffect, useState } from "react";
import "../styles/NotificationsPage.css";

export default function NotificationsPage() {
    const [notifications, setNotifications] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const receivedNotifications = await getNotifications();
            console.log(receivedNotifications);
            setNotifications(receivedNotifications);
        };

        getData();
    }, []);

    return (
        <>
            <Navbar/>

            <main className="notifications-page">
                <h1 className="notifications-page__title">Notificaties</h1>

                <div className="notifications-page__notifications">
                    {
                        notifications.map((data, key) => (
                            <div className="notifications-page__notification" key={key}>
                                <p className="notifications-page__label">Titel</p>
                                <p>{data.titel}</p>

                                <p className="notifications-page__label">Melding</p>
                                <p>{data.melding}</p>
                            </div>
                        ))
                    }
                </div>
            </main>

            <Footer/>
        </>
    );
}

/**
 * Will attempt to get the unread notifications from the server.
 * 
 * @returns {Object}
 */
async function getNotifications() {
    try {
        const response = await fetch('https://localhost:53085/api/ParticuliereUser/notifications', {
            method: 'GET',
    
            // TODO: change to 'same-origin' when in production.
            credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
            headers: {
                'content-type': 'application/json'
            },
        });

        return await response.json();
    } catch (error) {
        console.error('error when requesting the rent requests, or parsing the response:', error);
        throw error;
    }
}
