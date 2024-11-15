import TempImage from '../assets/temp.jpg';
import NavButton from './NavButton.jsx';

function Navbar() {
    return(
        <nav className='navbar'>
            <a href="#"><img src={TempImage} width="70" alt="CarAndAll logo"/></a>

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