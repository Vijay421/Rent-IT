import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageAdmin() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/medewerker-aanmaken" text="Medewerker aanmaken"/>
        </ProfilePageBase>
    );
}

export default ProfilePageAdmin;
