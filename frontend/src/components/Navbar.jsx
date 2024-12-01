import Logo from '../assets/Logo.png';
import NavButton from './NavButton.jsx';
import '../styles/Navbar.css';
import {Link} from "react-router-dom";
import {AuthContext} from "./AuthContext.jsx";
import {useContext} from "react";

function Navbar() {
    const {isLoggedIn, logout} = useContext(AuthContext);

    return(
        <nav className='navbar'>
            <Link to="/"><img src={Logo} width="70" alt="CarAndAll logo"/></Link>

            <ul className='navbar__navigation-buttons'>
                <NavButton className="navbar_navigation-buttons-nagivation" title="button" link="/"></NavButton>
                <NavButton className="navbar_n  avigation-buttons-nagivation" title="button" link="/"></NavButton>
                <NavButton className="navbar_navigation-buttons-nagivation" title="button" link="/"></NavButton>
            </ul>

            {isLoggedIn ? (
                <ul className='navbar__login-box__button'>
                    <Link to="/">
                        <button onClick={logout}>Logout</button>
                    </Link>
                </ul>
            ) : (
                <ul className='navbar__login-box__button'>
                    <Link to="/login">
                        <button>Login</button>
                    </Link>

                    <Link to="/register">
                        <button>Register</button>
                    </Link>
                </ul>
            )}
        </nav>
    );
}

export default Navbar;