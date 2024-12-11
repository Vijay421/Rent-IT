import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageZakelijk() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/*" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/renting" text="Voertuig huren"/>
        </ProfilePageBase>
    );
}

export default ProfilePageZakelijk;