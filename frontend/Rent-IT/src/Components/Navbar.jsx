import TempImage from '../assets/temp.jpg';
import NavButton from './NavButton.jsx';

function Navbar() {
    return(
        <nav className='navbar'>
            <img src={TempImage} width="70" alt="CarAndAll logo"/>

            <ul className='navigation-buttons-div'>
                <NavButton title="button"></NavButton>
                <NavButton title="button"></NavButton>
                <NavButton title="button"></NavButton>
            </ul>
            <ul className='login-buttons-div'>
                <button>Login</button>
                <button>Register</button>
            </ul>
        </nav>
    );
}

export default Navbar;