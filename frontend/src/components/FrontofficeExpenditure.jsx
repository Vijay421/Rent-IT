import ExpenditureReview from "./ExpenditureReview.jsx";
import '../styles/FrontofficeUitgave.css';
import { useState, useEffect } from "react";

function FrontofficeExpenditure() {

    // Mock data for vehicles
    const mockVehicles = [
        { id: 1, prijs: 25000, merk: "Toyota", type: "Corolla", kenteken: "AB-123-CD" },
        { id: 2, prijs: 18000, merk: "Honda", type: "Civic", kenteken: "EF-456-GH" },
        { id: 3, prijs: 30000, merk: "BMW", type: "320i", kenteken: "IJ-789-KL" },
        { id: 4, prijs: 22000, merk: "Volkswagen", type: "Golf", kenteken: "MN-012-OP" },
    ];

    // Mock data for customer (assuming it is related to vehicle)
    const mockCustomerData = [
        { id: 1, naam: "John Doe" },
        { id: 2, naam: "Alice Johnson" },
        { id: 3, naam: "Bob White" },
        { id: 4, naam: "Charlie Green" },
    ];

    const [vehicles, setVehicles] = useState([]);
    const [customerData, setCustomerData] = useState(mockCustomerData);

    useEffect(() => {
        setVehicles(mockVehicles);
    }, []);

    // Sort the vehicles by price
    const sortedVehicles = [...vehicles].sort((a, b) => a.prijs - b.prijs);

    return (
        <main className="content">
            <div className="divMain">
                <div>
                    <h1 className="divMain__text__FrontOffice">Voertuig uitgave</h1>
                    {sortedVehicles.length === 0 ? (
                        <p>Geen voertuigen aanwezig</p>
                    ) : (
                        sortedVehicles.map((vehicle) => {
                            const customer = customerData.find((cust) => cust.id === vehicle.id);

                            return (
                                <ExpenditureReview
                                    key={vehicle.id}
                                    vehicle={vehicle}
                                    customer={customer}
                                />
                            );
                        })
                    )}
                </div>
            </div>
        </main>
    );
}

export default FrontofficeExpenditure;
