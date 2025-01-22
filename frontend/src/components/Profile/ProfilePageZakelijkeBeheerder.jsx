import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageZakelijkeBeheerder() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Instelligen aanpassen"/>
            <ProfilePageLinkButton link="/*" text="Zakelijke huurders beheren"/>
            <ProfilePageLinkButton link="/abonnement" text="Abonnement aanmaken"/>
            <ProfilePageLinkButton link="/abonnementen" text="Abonnementen beheren"/>
            <ProfilePageLinkButton link="/zb-huurgeschiedenis" text="Werknemersgeschiedenissen"/>
        </ProfilePageBase>
    );
}

export default ProfilePageZakelijkeBeheerder;