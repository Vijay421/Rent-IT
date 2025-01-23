import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageBackOffice() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Instelligen aanpassen"/>
            <ProfilePageLinkButton link="/huuraanvraag-beoordelen" text="Huuraanvragen beoordelen"/>
            <ProfilePageLinkButton link="/abonnementsoverzicht" text="Abonnementsoverzicht"/>
            <ProfilePageLinkButton link="/voertuigoverzicht" text="Voertuigoverzicht"/>
            <ProfilePageLinkButton link="/verhuurde-voertuigen" text="Verhuurde voertuigen"/>
            <ProfilePageLinkButton link="/backoffice/schadeclaims" text="Schadeclaims bekijken"/>
            <ProfilePageLinkButton link="/voertuig-staten" text="Voertuig staten"/>

            <ProfilePageLinkButton link="/medewerker-aanmaken" text="Medewerker aanmaken"/>
            <ProfilePageLinkButton link="/medewerkersoverzicht" text="Medewerkersoverzicht"/>
        </ProfilePageBase>
    );
}

export default ProfilePageBackOffice;