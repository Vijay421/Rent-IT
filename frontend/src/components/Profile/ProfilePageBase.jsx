import styles from './ProfilePageBase.module.css'
import {useContext} from "react";
import {UserContext} from "../UserContext.jsx";

function ProfilePageBase({children}) {

    const {userName} = useContext(UserContext)
    return (
        <div className={styles.MainDiv}>
            <p className={styles.MainDivTextWelkom}>Welkom {userName}.</p>
            {children}
        </div>
    );
}

export default ProfilePageBase;