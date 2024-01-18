import React, { useState } from 'react';
import agent from '../../api/agent';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import handleApiError from '../../api/HandleApiError';
import '../../styles/login&register&forgot_form.css';

const ForgotPasswordForm = () => {
  const [email, setEmail] = useState('');

  const handleSubmit = async (event) => {
    toast.dismiss();
    event.preventDefault();
    try {
      const response = await agent.Identity.forgot(email);
      toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
    } catch (error) {
      console.error("An error occurred during Forget Password. Please try again.", error);
      handleApiError(error, "An error occurred during Forget Password. Please try again.");
    }
  };

  return (
    <div className="page-content">
      <div className="form-v9-content">
        <form className="form-detail" onSubmit={handleSubmit}>
          <h2>Forgot Password</h2>
          
          <div className="form-row-last" style={{margin:"80px 0px 110px 0px"}}>
            <input onChange={(e) => setEmail(e.target.value)} type="email" id="Email" className="input-text-login" placeholder="Enter your email" required />
          </div>

          <div className="form-row-last mb-5">
            <button type="submit" className="login-button mb-2">Search</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default ForgotPasswordForm;
