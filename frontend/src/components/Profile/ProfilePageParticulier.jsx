import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageParticulier() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/*" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/*" text="Neem zakelijk abonnement"/>
            <ProfilePageLinkButton link="/renting" text="Voertuig huren"/>
            <ProfilePageLinkButton link="/huur-geschiedenis" text="Huurgeschiedenis"/>
            <ProfilePageLinkButton link="/notificaties" text="Notificaties"/>
        </ProfilePageBase>
    );
}

export default ProfilePageParticulier;
