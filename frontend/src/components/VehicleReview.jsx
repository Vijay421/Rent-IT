export default function VehicleReview({data}){

    function voertuigRegistreren(){
        alert("Voertuig is geregistreerd");
    }

    return(
        <div className="voertuigTab">
            <span>{data.kenteken}</span>
            <span>{data.merk} {data.type}</span>    
            <button onClick={voertuigRegistreren}>Bekeken</button>
        </div>
    )
}