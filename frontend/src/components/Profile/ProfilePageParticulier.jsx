import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageParticulier() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/*" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/*" text="Neem zakelijk abonnement"/>
            <ProfilePageLinkButton link="/renting" text="Voertuig huren"/>
        </ProfilePageBase>
    );
}

export default ProfilePageParticulier;