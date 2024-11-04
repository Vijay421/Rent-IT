import React, {useState, useEffect} from 'react'

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    function handleEmail(e) {
        setEmail(e => e.target.value)
    }

    function handlePassword(e) {
        setPassword(e => e.target.value)
    }

    return (
        <div className='login-box'>
            <h1 className='login-text'>Login</h1>

            <h2 className='input-text'>E-mail</h2>
            <input className='input-field' type="text" value={email}/>

            <h2 className='input-text'>Password</h2>
            <input className='input-field' type='password' value={password}/>

            <button className='login-button' type='submit'>Login</button>
            <h2></h2>
        </div>
    )
}

export default Login