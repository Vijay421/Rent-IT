import styles from './ProfilePageBase.module.css';
import {useContext} from "react";
import {UserContext} from "../UserContext.jsx";

function ProfilePageBase({children}) {

    const {userName} = useContext(UserContext);
    return (
        <div className={styles.MainProfileDiv}>
            <p className={styles.MainDivTextWelkom} id='profiel-base-title'>Welkom {userName}.</p>
            {children}
        </div>
    );
}

export default ProfilePageBase;