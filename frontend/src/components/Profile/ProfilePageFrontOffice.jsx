import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageFrontOffice() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/frontoffice/inname" text="Innames bekijken"/>
            <ProfilePageLinkButton link="/frontoffice/uitgave" text="Uitgaves bekijken"/>
        </ProfilePageBase>
    );
}

export default ProfilePageFrontOffice;