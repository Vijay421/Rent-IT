import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageZakelijk() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Instellingen aanpassen"/>
            <ProfilePageLinkButton link="/huur-overzicht" text="Voertuig huren"/>
            <ProfilePageLinkButton link="/huur-geschiedenis" text="Huurgeschiedenis"/>
            <ProfilePageLinkButton link="/reserveringen" text="Reserveringen"/>
        </ProfilePageBase>
    );
}

export default ProfilePageZakelijk;