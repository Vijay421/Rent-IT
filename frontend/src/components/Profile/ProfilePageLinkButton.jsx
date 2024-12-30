import {Link} from "react-router-dom";
import styles from './ProfilePageLinkButton.module.css';
import PropTypes from "prop-types";

function ProfilePageLinkButton({id, link, text}) {

    return (
        <Link id={id} to={link} className={styles.Link}>
            <div className={styles.LinkDiv}>
                <p className={styles.LinkDivText}>{text}</p>
            </div>
        </Link>
    );
}

ProfilePageLinkButton.propTypes = {
    link: PropTypes.string.isRequired,
    text: PropTypes.string.isRequired
};

export default ProfilePageLinkButton;