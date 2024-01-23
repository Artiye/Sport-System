import React, { useState, useEffect } from "react";
import "../../styles/ProfilePage.css";
import ProfileForm from "../../components/UserProfile/ProfileForm";
import ChangePasswordForm from "../../components/UserProfile/ChangePassword";
import { useNavigate } from "react-router-dom";
import { isUserLoggedIn } from "../../components/IdentityComponents/isUserLoggedIn";

const ProfilePage = () => {
    const [activeTab, setActiveTab] = useState("profile");
    const navigate = useNavigate();
    const isLoggedIn = isUserLoggedIn();
  
    useEffect(() => {
      if (!isLoggedIn) {
        navigate("/login");
      }
    }, [isLoggedIn, navigate]);
  
    const showProfile = () => {
        setActiveTab("profile");
    };

    const showChangePassword = () => {
        setActiveTab("changePassword");
    };

    
    return (
        <div className="container-xl px-4 mt-4">
            <nav className="nav nav-borders px-5">
                <a className={`nav-link ${activeTab === "profile" ? "active" : ""}`} onClick={showProfile}>
                    Profile
                </a>

                <a className={`nav-link ${activeTab === "changePassword" ? "active" : ""}`} onClick={showChangePassword}>
                    Change Password
                </a>

               
            </nav>

            {activeTab === "profile" && (
                <ProfileForm />
            )}

            {activeTab === "changePassword" && (
                <ChangePasswordForm/>
            )}

            
        </div>
    );
};

export default ProfilePage;
