import Navbar from "../../components/Navbar.jsx";
import Footer from "../../components/Footer.jsx";
import pageStyles from "./vehicleOverviewPage.module.css";
import { useLocation } from 'react-router-dom';
import { useState, useRef } from "react";

export default function VehicleCreateAndUpdate() {
    const { state } = useLocation();
    const { mode } = state;
    const form = useRef(null);

    const [brand, setBrand] = useState("");
    const [type, setType] = useState("");
    const [licensePlate, setLicensePlate] = useState("");

    function submit(e) {
        e.preventDefault();

        const payload = {
            merk: brand,
            type,
            kenteken: licensePlate,
        };

        console.log("payload", payload);
    }

    return (
        <>
            <Navbar/>

            <main className={pageStyles.main}>
                <div className={pageStyles.content}>

                    <h1 className={pageStyles.title}>Voertuig {getModeText(mode)}</h1>

                    <form ref={form} className={pageStyles.form}>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="brand">Merk</label>
                            <input
                                id="brand"
                                className="brand"
                                placeholder="Merknaam"
                                minLength="2"
                                maxLength="25"
                                data-cy="brand"
                                required={mode === "create"}
                                value={brand}
                                onChange={(e) => setBrand(e.target.value)}
                                type="text"
                            />
                        </div>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="type">Type</label>
                            <input
                                id="type"
                                className="type"
                                placeholder="Type"
                                minLength="2"
                                maxLength="25"
                                data-cy="type"
                                required={mode === "create"}
                                value={type}
                                onChange={(e) => setType(e.target.value)}
                                type="text"
                            />
                        </div>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="licensePlate">Kenteken</label>
                            <input
                                id="licensePlate"
                                className="licensePlate"
                                placeholder="Kenteken"
                                minLength="8"
                                maxLength="9"
                                data-cy="licensePlate"
                                required={mode === "create"}
                                value={licensePlate}
                                onChange={(e) => setLicensePlate(e.target.value)}
                                type="text"
                            />
                        </div>

                        <button className="" type="submit" onClick={submit} data-cy="submit" >Opslaan</button>
                    </form>
                </div>
            </main>

            <Footer/>
        </>
    );
}

/**
 * Returns wether the page should create or update a vehicle.
 * 
 * @param {string} mode 
 * @returns string
 */
function getModeText(mode) {
    switch (mode) {
        case "create":
            return "toevoegen";

        case "update":
            return "updaten";

        default:
            console.error(`Expected mode to be of value 'create' or 'update', received: '${mode}'`);
            return "toevoegen";
    }
}
