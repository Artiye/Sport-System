import ForgotPasswordForm from "../../components/IdentityComponents/ForgotPasswordForm";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { isUserLoggedIn } from "../../components/IdentityComponents/isUserLoggedIn";

const ForgotPassword = () => {
  const navigate = useNavigate();
  const isLoggedIn = isUserLoggedIn();

  useEffect(() => {
    if (isLoggedIn) { navigate('/'); }
  }, [isLoggedIn, navigate]);
  
  return (
    <div>
      <ForgotPasswordForm />
    </div>
  );
};

export default ForgotPassword;
