function Navbar() {


    return(
        <div>
            <nav className='navbar'>
                <a href="#"><img src="#" alt="CarAndAll logo"/></a>

                <div className='navigation-buttons-div'>
                    <button>button1</button>
                    <button>button2</button>
                    <button>button3</button>
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