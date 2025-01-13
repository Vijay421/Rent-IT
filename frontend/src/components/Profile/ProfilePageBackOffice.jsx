import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageBackOffice() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/account-instellingen" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/huuraanvraag-beoordelen" text="Huuraanvragen beoordelen"/>
            <ProfilePageLinkButton link="/voertuigoverzicht" text="Voertuigoverzicht"/>
            <ProfilePageLinkButton link="/verhuurde-voertuigen" text="Verhuurde voertuigen"/>
            <ProfilePageLinkButton data-cy="voertuig-staten-button" link="/voertuig-staten" text="Voertuig staten"/>
        </ProfilePageBase>
    );
}

export default ProfilePageBackOffice;