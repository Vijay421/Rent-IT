import '../../styles/ProfileInfoBox.css';
import {useContext, useEffect, useState} from "react";
import {UserContext} from "../UserContext.jsx";

export default function ProfileInfoBox() {
    const [data, setData] = useState([]);
    const { userRole } = useContext(UserContext);

    useEffect(() => {
        async function fetchProfileData() {
            try {
                const response = await fetch('https://localhost:53085/api/User/profiel', {
                    method: 'GET',
                    credentials: 'include',
                    headers: {
                        'content-type': 'application/json',
                    },
                });
                const data = await response.json();
                setData(data);
            } catch (e) {
                console.error(e);
            }
        }

        fetchProfileData();
    }, []);

    return (
        <div className='profile-info-box__div'>
            <div className="profile-info-username-container">
                <p className="profile-info-title__p">Username:</p>
                <p className="profile-info-data__p">{data.userName}</p>
            </div>

            <div className="profile-info-email-container">
                <p className="profile-info-title__p">Email:</p>
                <p className="profile-info-data__p">{data.email}</p>
            </div>

            {userRole === "particuliere_huurder" && (
                <div className="profile-info--container">
                    <p className="profile-info-title__p">Address:</p>
                    <p className="profile-info-data__p">{data.phuurderAddress}</p>
                </div>
            )}

            <div className="profile-info-phonenumber-container">
                <p className="profile-info-title__p">Telefoonnummer:</p>
                <p className="profile-info-data__p">{data.phoneNumber}</p>
            </div>

            {userRole === "zakelijke_huurder" && (
                <>
                    <div className="profile-info-abonnement-container">
                        <p className="profile-info-title__p">Abonnement:</p>
                        <p className="profile-info-data__p">{data.zhuurderAbonnement}</p>
                    </div>

                    <div className="profile-info-factuuradres-container">
                        <p className="profile-info-title__p">Factuuradres:</p>
                        <p className="profile-info-data__p">{data.zhuurderFactuurAddress}</p>
                    </div>
                </>
            )}

            {userRole === "zakelijke_beheerder" && (
                <>
                    <div className="profile-info-bedrijf-container">
                        <p className="profile-info-title__p">Bedrijf:</p>
                        <p className="profile-info-data__p">{data.zbeheerderBedrijf}</p>
                    </div>

                    <div className="profile-info-bedrijfsrol-container">
                        <p className="profile-info-title__p">Bedrijfsrol:</p>
                        <p className="profile-info-data__p">{data.zbeheerderBedrijfsrol}</p>
                    </div>
                </>
            )}

            {userRole === "bedrijf" && (
                <>
                    <div className="profile-info-bedrijfnaam-container">
                        <p className="profile-info-title__p">Bedrijfsnaam:</p>
                        <p className="profile-info-data__p">{data.bedrijfName}</p>
                    </div>

                    <div className="profile-info-bedrijfadres-container">
                        <p className="profile-info-title__p">Bedrijfsadres:</p>
                        <p className="profile-info-data__p">{data.bedrijfAddress}</p>
                    </div>

                    <div className="profile-info-bedrijfKVK-container">
                        <p className="profile-info-title__p">KVK-nummer:</p>
                        <p className="profile-info-data__p">{data.bedrijfKVKNumber}</p>
                    </div>

                    <div className="profile-info-bedrijftelefoonnummer-container">
                        <p className="profile-info-title__p">Bedrijfstelnr.:</p>
                        <p className="profile-info-data__p">{data.bedrijfPhoneNumber}</p>
                    </div>

                    <div className="profile-info-bedrijfdomein-container">
                        <p className="profile-info-title__p">Domein:</p>
                        <p className="profile-info-data__p">{data.bedrijfDomein}</p>
                    </div>
                </>
            )}
        </div>
    );
}