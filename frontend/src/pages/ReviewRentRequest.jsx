import { useState, useEffect } from "react";
import Navbar from "../components/Navbar.jsx";
import Footer from "../components/Footer.jsx";
import RentRequest from "../components/RentRequest.jsx";
import "../styles/ReviewRentRequest.css";

export default function IndexPage() {
    const [requests, setRequests] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const receivedRequests = await getRentRequests();
            setRequests([receivedRequests[0]]);
            // setRequests(receivedRequests); // TODO: show all data.
            console.log(requests);
        };
        getData();
    }, []);

    return (
        <>
            <Navbar/>

            <main className="rent-requests__page">
                <div className="rent-requests__filter">
                    filter
                </div>

                <div className="rent-requests__requests">
                    {
                        requests.map((data, key) => <RentRequest key={key} data={data} />)
                    }
                </div>
            </main>

            <Footer/>
        </>
    );
}

// TODO: handle server errors.
/**
 * Will attempt to get the rent requests from the server.
 * 
 * @returns {Object}
 */
async function getRentRequests() {
    try {
        const response = await fetch('https://localhost:53085/api/BackOffice/huuraanvragen', {
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
