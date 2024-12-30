import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageFrontOffice() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Account instellingen aanpassen"/>
        </ProfilePageBase>
    );
}

export default ProfilePageFrontOffice;