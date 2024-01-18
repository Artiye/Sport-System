import React, { useEffect, useState } from "react";
import '../styles/ProfileMenu.css';
import agent from '../api/agent';
import { useNavigate } from 'react-router-dom';

const ProfileMenu = () => {
  const [menuOpen, setMenuOpen] = useState(false);
  const userId = localStorage.getItem('userId');
  const [user, setUser] = useState(null);

  useEffect(() => {
    if (userId) {
      agent.User.getUserById(userId)
        .then(response => { setUser(response); })
        .catch(error => { console.error("Error fetching user data:", error); });
    }
  }, [userId]);

  const navigate = useNavigate();

  function handleLogout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    setUser(null);
    setMenuOpen(false);
    navigate('/');
    window.location.reload();
  }

  function goToProfile() {
    navigate('/profile');
    setMenuOpen(false);
  }

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <div className="profile-menu">
      <div className="menu-button" onClick={toggleMenu}>
        {user && (
          <div className="user-info">
            <i class="ri-shield-user-fill"></i>
            <span>
              {user.firstName} {user.lastName}
            </span>
          </div>
        )}
        <i className={`fas fa-caret-${menuOpen ? 'up' : 'down'}`} />
      </div>
      {menuOpen && (
        <div className="menu-options">
          <ul>
            <li onClick={goToProfile}> My Profile </li>
            <li> Settings </li>
            <li onClick={handleLogout}> Logout </li>
          </ul>
        </div>
      )}
    </div>
  );
};

export default ProfileMenu;
