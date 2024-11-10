import React, {useState, useEffect} from 'react'

function Login() {
    const [data, setData] = useState(null);

    // Handles fetching of data from DB and storing in const data
    useEffect(() => {
        var url = 'GET request link here'
        fetch(url)
            .then(response => response.json())
            .then(json => setData(json))
            .catch(error => console.error(error))
    }, []);

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    // Handles action when typing in email field
    function handleEmail(e) {
        setEmail(e.target.value)
    }

    // Handles action when typing in password field
    function handlePassword(e) {
        setPassword(e.target.value)
    }

    // Handles action when button is clicked
    function handleButtonClick() {
        const textField = document.getElementById('display-text-field') /*test code, change or remove*/
        if (data && data.length > 0) { /*test code, change or remove*/
            textField.textContent = data[0].name; /*test code, change or remove*/
        }
    }

    return (
        <div className='login-box'>
            <h1 className='login-text'>Login</h1>

            <h2 className='input-text'>E-mail</h2>
            <input className='input-field' type="text" value={email} onChange={handleEmail}/>

            <h2 className='input-text'>Password</h2>
            <input className='input-field' type='password' value={password} onChange={handlePassword}/>

            <button className='login-button' type='button' onClick={handleButtonClick}>Login</button>

            <p id='display-text-field'>placeholder</p>
        </div>
    )
}

export default Login