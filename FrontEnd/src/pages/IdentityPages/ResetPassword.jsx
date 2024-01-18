import ResetPasswordForm from "../../components/IdentityComponents/ResetPasswordForm";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { isUserLoggedIn } from "../../components/IdentityComponents/isUserLoggedIn";

const ResetPassword = () => {
  const navigate = useNavigate();
  const isLoggedIn = isUserLoggedIn();

  useEffect(() => {
    if (isLoggedIn) { navigate('/'); }
  }, [isLoggedIn, navigate]);
  
  return (
    <div>
      <ResetPasswordForm />
    </div>
  );
};

export default ResetPassword;
