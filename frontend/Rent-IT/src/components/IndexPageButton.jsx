import '../styles/IndexPage.css';

function IndexPageButton() {
    return (
        <container className="Content">
            <div className="topDiv"></div>
            <div className="MainDivLeft">
                <div className="ParticulierDiv">
                    <h1 className="ParticulierH1">Particulier</h1>
                </div>
                <div className="ButtonDivLeft">
                    <h1 className="BottomDivLeftHuren">huren</h1>
                </div>
            </div>
            <div className="MainDivCenter"></div>
            <div className="MainDivRight">
                <div className="ZakelijkDiv">
                    <h1 className="ZakelijkH1">Zakelijk</h1>
                </div>
                <div className="ButtonDivRight">
                    <h1 className="BottomDivRightHuren">huren</h1>
                </div>
            </div>
        </container>
    )
}

export default IndexPageButton;
