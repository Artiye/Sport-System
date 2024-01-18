import LoginForm from "../../components/IdentityComponents/LoginForm";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useContext } from 'react';
import { UserContext } from './UserContext';

const LogIn = () => {
  const navigate = useNavigate();
  const { isLoggedIn, setIsLoggedIn } = useContext(UserContext);

  useEffect(() => {
    if (isLoggedIn) { navigate('/'); }
  }, [isLoggedIn, navigate]);

  const handleLoginSuccess = () => {
    setIsLoggedIn(true); 
    navigate('/');
  };
  
  return (
    <div>
      <LoginForm onLoginSuccess={handleLoginSuccess} />
    </div>
  );
};

export default LogIn;
