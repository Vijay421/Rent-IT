import PropTypes from "prop-types";
import { useNavigate } from "react-router-dom";

function NavButton(props) {
    const navigate = useNavigate();

    return (
        <button
            data-cy={props.cy ? props.cy : null}
            onClick={(e) => {
                if (props.onClick) {
                    props.onClick(e);
                }
                navigate(`${props.link}`);
            }}
        >
            {props.title}
        </button>
    );
}

NavButton.propTypes = {
    title: PropTypes.string.isRequired,
    link: PropTypes.string.isRequired,
    onClick: PropTypes.func,
};

export default NavButton;
