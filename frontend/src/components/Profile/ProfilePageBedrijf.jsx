import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageBedrijf() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/*" text="Zakelijke beheerder aanmaken"/>
            <ProfilePageLinkButton link="/*" text="Zakelijke huurder aanmaken"/>
        </ProfilePageBase>
    );
}

export default ProfilePageBedrijf;
