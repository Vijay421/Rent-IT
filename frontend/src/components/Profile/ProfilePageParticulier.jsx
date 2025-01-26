import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageParticulier() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Instellingen aanpassen"/>
            <ProfilePageLinkButton link="/huur-overzicht" text="Voertuig huren"/>
            <ProfilePageLinkButton link="/reserveringen" text="Reserveringen"/>
            <ProfilePageLinkButton link="/huur-geschiedenis" text="Huurgeschiedenis"/>
            <ProfilePageLinkButton link="/notificaties" text="Notificaties"/>
        </ProfilePageBase>
    );
}

export default ProfilePageParticulier;
