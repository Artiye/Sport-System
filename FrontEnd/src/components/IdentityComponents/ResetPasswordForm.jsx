import React, { useState } from 'react';
import agent from '../../api/agent';
import { useParams, useNavigate } from 'react-router-dom';
import handleApiError from '../../api/HandleApiError';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import "../../styles/resetpassword.css";

const ResetPasswordForm = () => {
  const { email, token } = useParams();
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    toast.dismiss();
    event.preventDefault();

    if (password !== confirmPassword) {
      toast.error("Passwords don't match!", { closeButton: <div style={{ width: "25%" }}></div> });
      return;
    }

    try {
      const response = await agent.Identity.reset({
        token,
        Email: email,
        NewPassword: password,
        ConfirmPassword: confirmPassword
      });

      toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
      navigate("/login");
    } catch (error) {
      console.error("An error occurred during registration. Please try again.", error);
      handleApiError(error, "An error occurred during registration. Please try again.");
    }
  };

  return (
    <div className="page-content">
    <div className="form-v9-content">
      <form className="form-detail" onSubmit={handleSubmit}>
        <h2>Reset Password</h2>
        
        <div className="form-row-last mt-5 mb-4">
          <input onChange={(e) => setPassword(e.target.value)} type="password" id="password" className="input-text-login" placeholder="Enter your new password" required />
        </div>
        <div className="form-row-last mb-5">
          <input type="password" id="password" onChange={(e) => setConfirmPassword(e.target.value)} className="input-text-login" placeholder="Confirm your new password" required />
        </div>
        <div className="form-row-last mb-5">
          <button type="submit" className="login-button mb-2 p-2">Reset Password</button>
        </div>
      </form>
    </div>
  </div>


  );
};

export default ResetPasswordForm;
