import Navbar from "../../components/Navbar.jsx";
import Footer from "../../components/Footer.jsx";
import pageStyles from "./vehicleOverviewPage.module.css";
import { useLocation } from 'react-router-dom';
import { useState, useRef } from "react";

export default function VehicleCreateAndUpdate() {
    const { state } = useLocation();
    const { mode, vehicle } = state;
    const form = useRef(null);

    const [brand, setBrand] = useState(vehicle.merk || "");
    const [type, setType] = useState(vehicle.type || "");
    const [licensePlate, setLicensePlate] = useState(vehicle.kenteken || "");
    const [color, setColor] = useState(vehicle.kleur || "");
    const [boughtYear, setBoughtYear] = useState(vehicle.aanschafjaar || "");
    const [kind, setKind] = useState(vehicle.soort || "");
    const [comment, setComment] = useState(vehicle.opmerking || "");
    const [status, setStatus] = useState(vehicle.status || "");
    const [price, setPrice] = useState(vehicle.prijs || "");
    const [startDate, setStartDate] = useState(vehicle.startdatum || "");
    const [endDate, setEndDate] = useState(vehicle.einddatum || "");

    const [formStatus, setFormStatus] = useState({ msg: "", isError: false });

    const today = new Date();

    async function submit() {
        // Don't submit when the form is invalid.
        if (!form.current.checkValidity()) {
            return;
        }

        if (boughtYear.length !== 0) {
            if (today.getFullYear() < Number(boughtYear)) {
                window.alert("Aanschafjaar kan niet later plaatsvinden dan dit jaar.");
                return;
            }
        }

        if (startDate.length !== 0 && endDate.length !== 0) {
            const startDateObj = new Date(startDate);
            const endDateObj = new Date(endDate);

            if (startDateObj > endDateObj) {
                window.alert("Einddatum kan niet eerder zijn dan startdatum.");
                return;
            }
        }

        const payload = {
            merk: brand.length === 0 ? null : brand,
            type: type.length === 0 ? null : type,
            kenteken: licensePlate.length === 0 ? null : licensePlate,
            kleur: color.length === 0 ? null : color,
            aanschafjaar: boughtYear.length === 0 ? null : boughtYear,
            soort: kind.length === 0 ? null : kind,
            opmerking: comment.length === 0 ? null : comment,
            status: status.length === 0 ? null : status,
            prijs: price.length === 0 ? null : price,
            startDatum: startDate.length === 0 ? null : startDate,
            eindDatum: endDate.length === 0 ? null : endDate,
        };


        await save(payload, mode, setFormStatus, vehicle);
    }

    return (
        <>
            <Navbar/>

            <main className={pageStyles.main}>
                <div className={pageStyles.content}>

                    <h1 className={pageStyles.title}>Voertuig {getModeText(mode)}</h1>

                    { (formStatus.msg.length !== 0) && (
                        <div className={pageStyles.formStatus}>
                            <p
                                className={`${pageStyles.formStatusText} ${ formStatus.isError ? pageStyles.error : pageStyles.success }`}
                            >
                                {formStatus.msg}
                            </p>
                        </div>
                    ) }

                    <form ref={form} className={pageStyles.form} onSubmit={(e) => {e.preventDefault()}}>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="brand">Merk:</label>
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
                            <label htmlFor="type">Type:</label>
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
                            <label htmlFor="licensePlate">Kenteken:</label>
                            <input
                                id="licensePlate"
                                className="licensePlate"
                                placeholder="AA-BB-CC"
                                minLength="8"
                                maxLength="9"
                                data-cy="licensePlate"
                                required={mode === "create"}
                                value={licensePlate}
                                onChange={(e) => setLicensePlate(e.target.value)}
                                type="text"
                            />
                        </div>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="color">Kleur:</label>
                            <input
                                id="color"
                                className="color"
                                placeholder="Kleur"
                                minLength="2"
                                maxLength="25"
                                data-cy="color"
                                required={mode === "create"}
                                value={color}
                                onChange={(e) => setColor(e.target.value)}
                                type="text"
                            />
                        </div>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="boughtYear">Aanschafjaar:</label>
                            <input
                                id="boughtYear"
                                className="boughtYear"
                                placeholder="Aanschafjaar"
                                data-cy="boughtYear"
                                required={mode === "create"}
                                value={boughtYear}
                                onChange={(e) => setBoughtYear(e.target.value)}
                                type="number"
                            />
                        </div>

                        <div className={pageStyles.formGroup}>

                            <label htmlFor="kind">Soort:</label>
                            <select
                                id="kind"
                                className="kind"
                                name="kind"
                                data-cy="kind"
                                required={mode === "create"}
                                onChange={(e) => setKind(e.target.value)}
                            >
                                <option value="">Selecteer</option>
                                <option value="Auto">Auto</option>
                                <option value="Camper">Camper</option>
                                <option value="Caravan">Caravan</option>
                            </select>
                        </div>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="comment">Opmerking:</label>
                            <textarea
                                id="comment"
                                className={pageStyles.comment}
                                placeholder="Opmerking"
                                minLength="2"
                                maxLength="500"
                                data-cy="comment"
                                required={mode === "create"}
                                value={comment}
                                onChange={(e) => setComment(e.target.value)}
                                type="textare"
                                rows="5"
                                cols="25"
                            />
                        </div>

                        <div className={pageStyles.formGroup}>

                            <label htmlFor="status">Status:</label>
                            <select
                                id="status"
                                className="status"
                                name="status"
                                data-cy="status"
                                required={mode === "create"}
                                onChange={(e) => setStatus(e.target.value)}
                            >
                                <option value="">Selecteer</option>
                                <option value="Verhuurbaar">Verhuurbaar</option>
                                <option value="Onverhuurbaar">Onverhuurbaar</option>
                            </select>
                        </div>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="price">Prijs:</label>
                            <input
                                id="price"
                                className="price"
                                placeholder="prijs"
                                min="0"
                                data-cy="price"
                                required={mode === "create"}
                                value={price}
                                onChange={(e) => setPrice(e.target.value)}
                                type="number"
                            />
                        </div>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="startDate">Startdatum:</label>
                            <input
                                id="startDate"
                                className="startDate"
                                placeholder="Startdatum"
                                data-cy="startDate"
                                required={mode === "create"}
                                onChange={(e) => setStartDate(e.target.value)}
                                type="date"
                            />
                        </div>

                        <div className={pageStyles.formGroup}>
                            <label htmlFor="EndDate">Einddatum:</label>
                            <input
                                id="EndDate"
                                className="EndDate"
                                placeholder="Einddatum"
                                data-cy="EndDate"
                                required={mode === "create"}
                                onChange={(e) => setEndDate(e.target.value)}
                                type="date"
                            />
                        </div>

                        <button className={pageStyles.button__submit} type="submit" onClick={submit} data-cy="submit" >Opslaan</button>
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

async function save(payload, mode, setFormStatus, vehicle) {
    if (mode === "create") {
        try {
            await createVehicle(payload);
            setFormStatus({ msg: "Het voertuig is aangemaakt.", isError: false });
        } catch (error) {
            setFormStatus({ msg: error, isError: true });
        }
    }

    if (mode === "update") {
        try {
            await updateVehicle(payload, vehicle.id);
            setFormStatus({ msg: "Het voertuig is geüpdatet.", isError: false });
        } catch (error) {
            setFormStatus({ msg: error, isError: true });
        }
    }
}

async function createVehicle(payload) {
    const request = {
        method: 'POST',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(payload),
    };

    try {
        const response = await fetch(`https://localhost:53085/api/Voertuig`, request);

        if (!response.ok) {
            if (response.status === 422) {
                const msg = await response.text();
                throw new Error(msg);
            }
            throw new Error("Kon het voertuig niet aanmaken");
        }

        return await response.json();
    } catch (error) {
        console.error('error when creating vehicle, or parsing the response:', error);
        throw new Error("Kon het voertuig niet aanmaken");
    }
}

async function updateVehicle(payload, id) {
    const request = {
        method: 'PUT',
        credentials: 'include', // TODO: change to 'same-origin' when in production.
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(payload),
    };

    try {
        const response = await fetch(`https://localhost:53085/api/Voertuig/${id}`, request);

        if (!response.ok) {
            throw new Error("Kon het voertuig niet updaten");
        }

        return await response.json();
    } catch (error) {
        console.error('error when updating vehicle, or parsing the response:', error);
        throw new Error("Kon het voertuig niet updaten");
    }
}
