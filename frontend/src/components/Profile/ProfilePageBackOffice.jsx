import ProfilePageBase from "./ProfilePageBase.jsx";
import ProfilePageLinkButton from "./ProfilePageLinkButton.jsx";

function ProfilePageBackOffice() {

    return (
        <ProfilePageBase>
            <ProfilePageLinkButton link="/*" text="Account instellingen aanpassen"/>
            <ProfilePageLinkButton link="/huuraanvraag-beoordelen" text="Huuraanvragen beoordelen"/>
        </ProfilePageBase>
    );
}

export default ProfilePageBackOffice;