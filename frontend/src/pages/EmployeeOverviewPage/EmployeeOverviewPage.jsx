import Navbar from "../../components/Navbar.jsx";
import Footer from "../../components/Footer.jsx";
import { useEffect, useState } from "react";
import pageStyles from "./page.module.css";

export default function EmployeeOverviewPage() {
    const [employees, setEmployees] = useState([]);

    useEffect(() => {
        const getData = async () => {
            const receivedEmployees = await getEmployees();

            // Map date string to date object.
            const employeesMapped = receivedEmployees.map((e) => {
                e.lockoutEnd = new Date(e.lockoutEnd);
                return e;
            });
            setEmployees(employeesMapped);
        };

        getData();
    }, []);

    async function handleUnlockEmployee(id) {
        try {
            const unblockedEmployee =  await unblockEmployee(id);
            setEmployees((old) => {
                const copy = [...old];
                const index = copy.findIndex((employee) => employee.id === id);
                if (index === -1) {
                    return copy;
                }

                // Map date string to date object.
                unblockedEmployee.lockoutEnd = new Date(unblockedEmployee.lockoutEnd);

                copy[index] = unblockedEmployee;
                return copy;
            });
        } catch (error) {
            window.alert(error);
        }
    }

    return (
        <>
            <Navbar/>

            <main className={pageStyles.main}>
                <h1 className={pageStyles.title}>Medewerkers</h1>

                <div className={pageStyles.employees}>
                    {
                        employees.map((data, key) => (
                            <div key={key} className={pageStyles.employee}>
                                <p className={`${pageStyles.idLabel} ${pageStyles.label}`}>Id</p>
                                <p className={pageStyles.id}>{data.id}</p>

                                <p className={`${pageStyles.usernameLabel} ${pageStyles.label}`}>Gebruikersnaam</p>
                                <p className={pageStyles.username}>{data.userName}</p>

                                <p className={`${pageStyles.emailLabel} ${pageStyles.label}`}>Email</p>
                                <p className={pageStyles.email}>{data.email}</p>

                                <p className={`${pageStyles.lockedDateLabel} ${pageStyles.label}`}>Blokeereinddatum</p>
                                <p className={pageStyles.lockedDate}>{data.lockoutEnd === null ? "N.v.t." : formatDate(data.lockoutEnd)}</p>

                                <p className={`${pageStyles.roleLabel} ${pageStyles.label}`}>Rol</p>
                                <p className={pageStyles.role}>{data.role}</p>

                                {isLockedout(data.lockoutEnd) && (
                                    <button className={pageStyles.lockout} onClick={() => handleUnlockEmployee(data.id)} data-cy="unblock">Deblokkeren</button>
                                ) }
                            </div>
                        ))
                    }

                    {
                        employees.length === 0 && <p className={pageStyles.emptyText}>Geen medewerkers</p>
                    }
                </div>
            </main>

            <Footer/>
        </>
    );
}

/**
 * Format the given date to: dd-mm-yyyy hh:mm:ss
 * 
 * @param {Date} date 
 * @returns string
 */
function formatDate(date) {
    const day = date.getDate();
    const month = date.getMonth() + 1; // Months start from 0 for some reason.
    const year = date.getFullYear();

    const hours = date.getHours();
    const minutes = date.getMinutes();
    const seconds = date.getSeconds();

    return `${day}-${month}-${year} ${hours}:${minutes}:${seconds}`;
}

/**
 * Return true when lockoutEnd is set later then the current time.
 * 
 * @param {string} lockoutEnd 
 * @returns bool
 */
function isLockedout(date) {
    const lockedOutEnd = new Date(date).getTime();
    const today = new Date().getTime();

    const isLockedOut = lockedOutEnd > today;

    return isLockedOut;
}

/**
 * Return employees from the server.
 * 
 * @returns {Object}
 */
async function getEmployees() {
    const request = {
        method: 'GET',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
    };

    try {
        const response = await fetch("https://localhost:53085/api/Admin/employees", request);
        return await response.json();
    } catch (error) {
        console.error('error when getting the employees, or parsing the response:', error);
        throw error;
    }
}

/**
 * Attempts to unblock the user with the given id.
 * 
 * @param {string} id 
 * @returns {Object}
 */
async function unblockEmployee(id) {
    const request = {
        method: 'POST',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
    };

    try {
        const response = await fetch(`https://localhost:53085/api/Admin/unblock-employee/${id}`, request);

        if (!response.ok) {
            if (response.status === 404) {
                throw new Error(await response.text());
            }
            throw new Error("Kon de medewerker niet deblokkeren");
        }

        return await response.json();
    } catch (error) {
        console.error('error when unblocking an employees, or parsing the response:', error);
        throw new Error("Kon de medewerker niet deblokkeren");
    }
}
