import Logo from '../assets/Logo.png';
import NavButton from './NavButton.jsx';
import '../styles/Navbar.css';

function Navbar() {
    return(
        <nav className='navbar'>
            <a href="#"><img src={Logo} width="130" alt="CarAndAll logo"/></a>

            <ul className='navbar__navigation-buttons'>
                <NavButton title="button"></NavButton>
                <NavButton title="button"></NavButton>
                <NavButton title="button"></NavButton>
            </ul>
            <ul className='navbar__login-box__button'>
                <button>Login</button>
                <button>Register</button>
            </ul>
        </nav>
    );
}

export default Navbar;