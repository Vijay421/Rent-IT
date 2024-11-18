import PropTypes from "prop-types";

function NavButton(props) {

    return (
        <button>
            {props.title}
        </button>
    );
}

NavButton.propTypes = {
    title: PropTypes.string.isRequired,
};

export default NavButton;