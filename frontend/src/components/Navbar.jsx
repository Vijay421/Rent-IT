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

            <div className='navbar__navigation-buttons'>
                <NavButton className="navbar_navigation-buttons-nagivation" title="Home" link="/"></NavButton>
                <NavButton className="navbar_navigation-buttons-nagivation" title="Huren" link="/renting"></NavButton>
            </div>

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
                        <button id='register-button__button'>Register</button>
                    </Link>
                </ul>
            )}
        </nav>
    );
}

export default Navbar;