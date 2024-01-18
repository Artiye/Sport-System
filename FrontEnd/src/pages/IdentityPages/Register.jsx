import RegisterForm from "../../components/IdentityComponents/RegisterForm";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { isUserLoggedIn } from "../../components/IdentityComponents/isUserLoggedIn";

const Register = () => {
  const navigate = useNavigate();
  const isLoggedIn = isUserLoggedIn();

  useEffect(() => {
    if (isLoggedIn) { navigate('/'); }
  }, [isLoggedIn, navigate]);
  
  return (
    <div>
      <RegisterForm />
    </div>
  );
};

export default Register;
