import Logo from '../assets/Logo.png';
import NavButton from './NavButton.jsx';
import '../styles/Navbar.css';
import { Link } from "react-router-dom";
import { AuthContext } from "./AuthContext.jsx";
import { useContext } from "react";

function Navbar() {

    const { isLoggedIn, logout } = useContext(AuthContext);

    return (
        <nav className='navbar'>
            <Link to="/">
                <img className='navbar-logo__img' src={Logo} alt="CarAndAll logo" />
            </Link>

            <div className='navbar__navigation-buttons'>
                <NavButton className="navbar_navigation-buttons-nagivation" title="Home" link="/"></NavButton>
                <NavButton className="navbar_navigation-buttons-nagivation" title="Huren" link="/huur-overzicht"></NavButton>
            </div>

            {isLoggedIn ? (
                <ul className='navbar__login-box__button'>
                    <NavButton className="navbar__login-box__button" link="/" title="Logout" onClick={logout}></NavButton>
                    <NavButton className="navbar__login-box__button" link="/profiel" title="Profiel"></NavButton>
                </ul>
            ) : (
                <ul className='navbar__login-box__button'>
                    <NavButton className="navbar__login-box__button" link="/login" title="Login"></NavButton>
                    <NavButton className="navbar__login-box__button" link="/registreren" title="Register"></NavButton>
                </ul>
            )}
        </nav>
    );
}

export default Navbar;
