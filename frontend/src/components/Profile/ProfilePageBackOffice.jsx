import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageBackOffice() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/huuraanvraag-beoordelen" text="Huuraanvragen beoordelen"/>
            <ProfilePageLinkButton link="/voertuigoverzicht" text="Voertuigoverzicht"/>
            <ProfilePageLinkButton link="/verhuurde-voertuigen" text="Verhuurde voertuigen"/>
            <ProfilePageLinkButton link="/backoffice/schadeclaims" text="Schadeclaims bekijken"/>
        </ProfilePageBase>
    );
}

export default ProfilePageBackOffice;