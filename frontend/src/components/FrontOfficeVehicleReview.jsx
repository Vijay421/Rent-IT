import "../styles/FrontOffice.css";
import { useState, useEffect, useContext } from "react";
import { UserContext } from "./UserContext.jsx";
import {RentalAutoBox, RentalCamperBox, RentalCaravanBox} from "./RentalVehicleBox.jsx";

function FrontOffice() {
    const { userRole } = useContext(UserContext);
    const [vehicle, setVehicle] = useState([]);

    const vehicleData = location.state?.vehicleData;
    const startDatum = location.state?.startDatum;
    const eindDatum = location.state?.eindDatum;

    useEffect(() => {
        async function fetchVehicle() {
            try {
                // TO-DO: Mick's API endpoint toevoegen
                const response = await fetch('https://localhost:53085/api/Voertuig/{id}', {
                    method: 'GET',

                    // TODO: change to 'same-origin' when in production.
                    credentials: 'include', // 'credentials' has to be defined, otherwise the auth cookie will not be send in other fetch requests.
                    headers: {
                        'content-type': 'application/json'
                    },
                });
                const data = await response.json();
                setVehicle(data);
                console.log(userRole);
            }
            catch (e) {
                console.error(e);
            }
        }
        fetchVehicle();
    }, []);


    return (
        <main className="content">
            <div className={styles.TopDiv} id='top-div__div'>
                {vehicleData.soort === "Auto" && <RentalAutoBox data={vehicleData} nieuwStartDatum={startDatum} nieuwEindDatum={eindDatum}/>}
                {vehicleData.soort === "Caravan" && <RentalCaravanBox data={vehicleData} nieuwStartDatum={startDatum} nieuwEindDatum={eindDatum}/>}
                {vehicleData.soort === "Camper" && <RentalCamperBox data={vehicleData} nieuwStartDatum={startDatum} nieuwEindDatum={eindDatum}/>}
            </div>
            <div className="divMain">
                return (
                    <h1>{vehicle.merk}{vehicle.type}</h1>

                    <div className="voertuigTab">
                        <span>{vehicle.kenteken}</span>
                        <span>{} </span>
                        <button>Bekijk</button>
                    </div>
                );
            </div>
        </main>
    );
}


export default FrontOffice;