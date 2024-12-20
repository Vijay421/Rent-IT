import '../styles/ReserveringWijziging.css';
import {useRef} from "react";

export default function ReserveringWijziging() {
    const form = useRef(null);

    function handleFormSubmit() {
        if (!form.current.checkValidity()) {
            return;
        }
    }

    return (
        <div className='wijziging-page-container__div'>
            <div className="wijziging-page-form-box__div">
                <h1 className='form-box-title__h1'>Reservering wijzigen</h1>
                <form ref={form} className='wijziging-form' onSubmit={(e) => e.preventDefault()}>
                    <div>
                        <label htmlFor="">
                            
                        </label>
                        <input type="text"/>
                    </div>
                </form>

                <button onClick={handleFormSubmit} className='form-box-submit__button'>Update</button>
            </div>
        </div>
    );
}