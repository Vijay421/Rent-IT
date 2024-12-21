export default function VehicleReview({data}){

    function voertuigAccepteren(){
        alert("Voertuig is YIPPIE");
    }

    function voertuigWeigeren(){
        alert("Voertuig is GONE");
    }

    function voertuigRegistreren(){
        alert("Voertuig is geregistreerd!");
    }
    return(
        <div className="voertuigTab">
            <h2>{data.merk} {data.type} - {data.kenteken}</h2>
            <form>
                <input>
                </input>
                <input type="submit" onClick={voertuigRegistreren} value="Registreren"></input>
            </form>
            {/* <button onClick={voertuigAccepteren}>Akkoord</button>
            <button onClick={voertuigWeigeren}>Weigeren</button> */}
        </div>
    )
}