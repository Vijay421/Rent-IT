import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageBackOffice() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/*" text="Account instellingen aanpassen"/>
        </ProfilePageBase>
    );
}

export default ProfilePageBackOffice;