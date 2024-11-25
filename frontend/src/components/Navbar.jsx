import TempImage from '../assets/temp.jpg';
import NavButton from './NavButton.jsx';
import '../styles/Navbar.css';
import {Link} from "react-router-dom";

function Navbar() {
    return(
        <nav className='navbar'>
            <Link to="/">
                <a href="#"><img src={TempImage} width="70" alt="CarAndAll logo"/></a>
            </Link>

            <ul className='navbar__navigation-buttons'>
                <NavButton className="navbar_navigation-buttons-nagivation" title="button" link="/"></NavButton>
                <NavButton className="navbar_navigation-buttons-nagivation" title="button" link="/"></NavButton>
                <NavButton className="navbar_navigation-buttons-nagivation" title="button" link="/"></NavButton>
            </ul>
            <ul className='navbar__login-box__button'>
                <Link to="/login">
                    <button>Login</button>
                </Link>

                <Link to="/register">
                    <button>Register</button>
                </Link>
            </ul>
        </nav>
    );
}

export default Navbar;