import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageZakelijkeBeheerder() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/*" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/*" text="Zakelijke huurders beheren"/>
        </ProfilePageBase>
    );
}

export default ProfilePageZakelijkeBeheerder;