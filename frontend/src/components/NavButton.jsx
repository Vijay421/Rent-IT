import PropTypes from "prop-types";
import {Link} from "react-router-dom";

function NavButton(props) {

    return (
        <Link to={props.link}>
            <button>
                {props.title}
            </button>
        </Link>
    );
}

NavButton.propTypes = {
    title: PropTypes.string.isRequired,
    link: PropTypes.string.isRequired
};

export default NavButton;