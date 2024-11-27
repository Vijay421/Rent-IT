import '../styles/Renting.css';
import { useState } from "react";

function Renting() {
    const [selectedOptionVoertuigSoort, setSelectedOptionVoertuigSoort] = useState("Option0"); //Selecteer Voertuig soort
    const [selectedDateOphaalDatum, setSelectedDateOphaalDatum] = useState(""); //Selecteer OphaalDatum
    const [selectedDateInleverDatum, setSelectedDateInleverDatum] = useState(""); //Selecteer InleverDatum

    // Event handler for Selecteer Soort Voertuig Dropdown:
    const handleSelectChange = (event) => {
        const value = event.target.value;
        setSelectedOptionVoertuigSoort(value);

        // Handles output from Selected Soort Voertuig.. !!Change This!!:
        console.log("Selected value:", value);
    };

    // Event handler for Selecteer Ophaal Datum DateSelecter:
    const handleDateChangeOphaalDatum = (event) => {
        const date = event.target.value;
        setSelectedDateOphaalDatum(date);

        // Handles output from Selected Ophaal Datum.. !!Change This!!:
        console.log("Selected date:", date);
    };

    // Event handler for Selecteer Inlever Datum DateSelecter:
    const handleDateChangeInleverDatum = (event) => {
        const date = event.target.value;
        setSelectedDateInleverDatum(date);

        // Handles output from Selected Inlever Datum.. !!Change This!!:
        console.log("Selected date:", date);
    };

    return (
        <div className="content">
            <div className="divLeft">
                <p className="divLeft-Text-Filter">Filter auto's:</p>
            </div>

            <div className="divTop">
                <div className="divTop-header">
                    <p className="divTop-header-Text-Huren">Auto huren:</p>
                </div>
                <div className="rowDivs">

                    <div className="divTop-divSelect-Voertuig">
                        <div className="divTop-divSelect-Voertuig-dropdown-container">
                            <label htmlFor="options" className="dropdown-label">Voertuig: </label>
                            <select
                                id="options"
                                name="options"
                                className="divTop-divSelect-voertuig-dropdown"
                                value={selectedOptionVoertuigSoort} // Controlled component
                                onChange={handleSelectChange} // Event handler
                            >
                                <option value="Option0">Alle soorten voertuigen</option>
                                <option value="option1">Auto</option>
                                <option value="option2">Camper</option>
                                <option value="option3">Caravan</option>
                            </select>
                        </div>
                    </div>

                    <div className="divTop-divSelect-ophaalDatum">
                        <div className="divTop-divSelect-ophaalDatum-datePicker-container">
                            <label htmlFor="date-picker" className="date-label-ophaalDatum">Ophaal datum: </label>
                            <input
                                type="date"
                                id="date-picker"
                                className="date-input"
                                value={selectedDateOphaalDatum}
                                onChange={handleDateChangeOphaalDatum}
                            />
                            {selectedDateOphaalDatum && <p className="divTop-divSelect-ophaalDatum-datePicker"></p>}
                        </div>
                    </div>

                    <div className="divTop-divSelect-inleverDatum">
                        <div className="divTop-divSelect-inleverDatum-datePicker-container">
                            <label htmlFor="date-picker" className="date-label-inleverDatum">Inlever datum: </label>
                            <input
                                type="date"
                                id="date-picker"
                                className="date-input"
                                value={selectedDateInleverDatum}
                                onChange={handleDateChangeInleverDatum}
                            />
                            {selectedDateInleverDatum && <p className="divTop-divSelect-inleverDatum-datePicker"></p>}
                        </div>
                    </div>
                </div>
            </div>

            <div className="divMargin"></div>
            <div className="divMain"></div>
        </div>
    );
}

export default Renting;
