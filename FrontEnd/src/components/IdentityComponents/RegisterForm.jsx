import React, { useState } from 'react';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import agent from '../../api/agent';
import DatePicker from "react-datepicker";
import { useNavigate } from 'react-router-dom';
import '../../styles/login&register&forgot_form.css';
import 'react-datepicker/dist/react-datepicker.css';
import handleApiError from '../../api/HandleApiError';

const RegisterForm = () => {
  const [username, setUsername] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [gender, setGender] = useState('');
  const [nationality, setNationality] = useState('');
  const [dateOfBirth, setDateOfBirth] = useState(new Date());
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');

  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleRegister = async (event) => {
    toast.dismiss();
    event.preventDefault();

    const user = {
      Username: username,
      FirstName: firstName,
      LastName: lastName,
      Gender: gender,
      Nationality: nationality,
      DateOfBirth: dateOfBirth,
      Email: email,
      Password: password,
      ConfirmPassword: confirmPassword
    };

    setLoading(true);

    try {
      const response = await agent.Identity.register(user);
      toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
      setTimeout(() => { navigate('/login') }, 1000);
    } catch (error) {
      console.error("An error occurred during registration. Please try again.", error);
      handleApiError(error, "An error occurred during registration. Please try again.");
    }
  };

  return (
    <div className="page-content">
      <div className="form-v9-content">
        <form className="form-detail" onSubmit={handleRegister}>
          <h2>Register</h2>
          <div className="form-row-total">
            <div className="form-row">
              <input type="text" id="username" onChange={(e) => setUsername(e.target.value)} className="input-text" placeholder="Your Username" required />
            </div>
            <div className="form-row">
              <input type="eMail" id="eMail" value={email} onChange={(e) => setEmail(e.target.value)} className="input-text" placeholder="Your E-Mail" required />
            </div>
          </div>
          
          <div className="form-row-total">
            <div className="form-row">
              <input type="text" id="name" value={firstName} onChange={(e) => setFirstName(e.target.value)} className="input-text" placeholder="Your First Name" required />
            </div>

            <div className="form-row">
              <input type="text" id="secondName" value={lastName} onChange={(e) => setLastName(e.target.value)} className="input-text" placeholder="Your Last Name" required />
            </div>
          </div>

          <div className="form-row-total">
            <div className="form-row">
              <input type="password" id="password" value={password} onChange={(e) => setPassword(e.target.value)} className="input-text" placeholder="Your Password" required />
            </div>
            <div className="form-row">
              <input type="password" id="confirmPassword" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} className="input-text" placeholder="Confirm Your Password" required />
            </div>
          </div>
          
          <div className="form-row-total">
            <div className="form-row mx-2">
              <input type="text" id="gender" value={gender} onChange={(e) => setGender(e.target.value)} className="input-text" placeholder="Your Gender" required />
            </div>
            <div className="form-row mx-2">
              <input type="text" id="nationality" value={nationality} onChange={(e) => setNationality(e.target.value)} className="input-text" placeholder="Your Nationality" required />
            </div>
            <div className="form-row mx-2">
              <DatePicker
                selected={dateOfBirth}
                onChange={(date) => setDateOfBirth(date)}
                dateFormat="yyyy-MM-dd"
                maxDate={new Date()}
                showYearDropdown
                dropdownMode="select"
              />
            </div>
          </div>

          <div className="form-row-last">
            <button type="submit" className="register-button">Register</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default RegisterForm;
