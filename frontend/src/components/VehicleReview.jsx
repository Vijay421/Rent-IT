export default function VehicleReview({data}){

    function voertuigAccepteren(){
        alert("Voertuig is YIPPIE");
    }

    function voertuigWeigeren(){
        alert("Voertuig is GONE");
    }

    return(
        <div className="voertuigTab">
            <span>{data.kenteken}</span>
            <span>{data.merk} {data.type}</span>    
            <button onClick={voertuigAccepteren}>Bekeken</button>
            <button onClick={voertuigWeigeren}>Bekeken</button>
        </div>
    )
}