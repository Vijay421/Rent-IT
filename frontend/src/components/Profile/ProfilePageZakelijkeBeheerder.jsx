import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageZakelijkeBeheerder() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/*" text="Instellingen aanpassen"/>
            <ProfilePageLinkButton link="/*" text="Zakelijke huurders beheren"/>
            <ProfilePageLinkButton link="/abonnement" text="Abonnement aanmaken"/>
            <ProfilePageLinkButton link="/abonnementen" text="Abonnementen beheren"/>
        </ProfilePageBase>
    );
}

export default ProfilePageZakelijkeBeheerder;