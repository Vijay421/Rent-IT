import '../styles/RentalVehicleBox.css';
import PropTypes from "prop-types";

export function RentalAutoBox( {data} ) {


    return (
        <div className='rental-vehicle-box__div'>
            <p className='rental-vehicle-merk__p'>Merk: {data.merk}</p>
            <p className='rental-vehicle-model__p'>Model: {data.type} </p>
            <p className='rental-vehicle-kenteken__p'>Kenteken: {data.kenteken}</p>
            <p className='rental-vehicle-kleur__p'>Kleur: {data.kleur}</p>
            <p className='rental-vehicle-aanschafjaar__p'>Aanschafjaar: {data.aanschafjaar}</p>
            <p className='rental-vehicle-status__p'>Status: {data.status}</p>
        </div>
    );
}

export function RentalCaravanBox( {data} ) {


    return (
        <div className='rental-vehicle-box__div'>
            <p className='rental-vehicle-merk__p'>Merk: {data.merk}</p>
            <p className='rental-vehicle-model__p'>Model: {data.type} </p>
            <p className='rental-vehicle-kenteken__p'>Kenteken: {data.kenteken}</p>
            <p className='rental-vehicle-kleur__p'>Kleur: {data.kleur}</p>
            <p className='rental-vehicle-aanschafjaar__p'>Aanschafjaar: {data.aanschafjaar}</p>
            <p className='rental-vehicle-status__p'>Status: {data.status}</p>
        </div>
    );
}

export function RentalCamperBox( {data} ) {


    return (
        <div className='rental-vehicle-box__div'>
            <p className='rental-vehicle-merk__p'>Merk: {data.merk}</p>
            <p className='rental-vehicle-model__p'>Model: {data.type} </p>
            <p className='rental-vehicle-kenteken__p'>Kenteken: {data.kenteken}</p>
            <p className='rental-vehicle-kleur__p'>Kleur: {data.kleur}</p>
            <p className='rental-vehicle-aanschafjaar__p'>Aanschafjaar: {data.aanschafjaar}</p>
            <p className='rental-vehicle-status__p'>Status: {data.status}</p>
        </div>
    );
}

RentalAutoBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        type: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.string.isRequired,
        status: PropTypes.string.isRequired,
    }).isRequired,
};

RentalCaravanBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        model: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.string.isRequired,
        status: PropTypes.string.isRequired,
    }).isRequired,
};

RentalCamperBox.propTypes = {
    data: PropTypes.shape({
        merk: PropTypes.string.isRequired,
        model: PropTypes.string.isRequired,
        kenteken: PropTypes.string.isRequired,
        kleur: PropTypes.string.isRequired,
        aanschafjaar: PropTypes.string.isRequired,
        status: PropTypes.string.isRequired,
    }).isRequired,
};