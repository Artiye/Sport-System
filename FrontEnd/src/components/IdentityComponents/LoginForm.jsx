import "../../styles/login&register&forgot_form.css";
import agent from '../../api/agent';
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const LoginForm = (props) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate =  useNavigate();

  const handleSubmit = async (event) => {
    toast.dismiss();
    event.preventDefault();

    try {
      const response = await agent.Identity.login({ email, password });

      if (response && response.token) {
        localStorage.setItem('token', response.token);
        localStorage.setItem('userId', response.userId);

        if (props.onLoginSuccess) { props.onLoginSuccess(); }
        toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
        navigate("/");
      } else {
        toast.error("Login failed. Please check your email and password.");
      }
    } catch (error) {
      if (error.response && error.response.data && error.response.data.message) {
        toast.error(error.response.data.message, { closeButton: <div style={{ width: "25%" }}></div> });
      } else {
        toast.error("An error occurred during login. Please try again.");
      }
    }
  };

  return (
    <div className="page-content">
      <div className="form-v9-content">
        <form className="form-detail" onSubmit={handleSubmit}>
          <h2>Login</h2>
          
          <div className="form-row-last mt-5 mb-4">
            <input onChange={(e) => setEmail(e.target.value)} type="email" id="Email" className="input-text-login" placeholder="Enter your email" required />
          </div>
          <div className="form-row-last mb-5">
            <input type="password" id="password" onChange={(e) => setPassword(e.target.value)} className="input-text-login" placeholder="Enter your password" required />
          </div>
          <div className="form-row-last mb-5">
            <button type="submit" className="login-button mb-2">Login</button>
            <br/>
            <Link to="/forgot-password" className="forgot-password_link">Forgot Password?</Link>
          </div>
        </form>
      </div>
    </div>
  );
};

export default LoginForm;
