import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './styles/index.css';
import App from './components/App.jsx';
import {AuthProvider} from "./components/AuthContext.jsx";
import {UserProvider} from "./components/UserContext.jsx";

createRoot(document.getElementById('root')).render(
    <StrictMode>
        <UserProvider>
            <AuthProvider>
                <App />
            </AuthProvider>
        </UserProvider>
    </StrictMode>,
);