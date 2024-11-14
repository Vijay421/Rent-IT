import TempImage from '../assets/temp.jpg'
import NavButton from './NavButton.jsx'

function Navbar() {
    return(
        <div>
            <nav className='navbar'>
                <img src={TempImage} width="70"/>

                <div className='navigation-buttons-div'>
                    <NavButton title={"button"}></NavButton>
                    <NavButton title={"button"}></NavButton>
                    <NavButton title={"button"}></NavButton>
                </div>
                <div className='login-buttons-div'>
                    <button>Login</button>
                    <button>Register</button>
                </div>
            </nav>
        </div>
    )
}

export default Navbar