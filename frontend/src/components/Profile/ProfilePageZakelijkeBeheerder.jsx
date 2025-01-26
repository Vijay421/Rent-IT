import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageZakelijkeBeheerder() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Instellingen aanpassen"/>
            <ProfilePageLinkButton link="/abonnement" text="Abonnement aanmaken"/>
            <ProfilePageLinkButton link="/abonnementen" text="Abonnementen beheren"/>
            <ProfilePageLinkButton link="/zb-huurgeschiedenis" text="Werknemersgeschiedenissen"/>
        </ProfilePageBase>
    );
}

export default ProfilePageZakelijkeBeheerder;