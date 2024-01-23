import React, { useState, useEffect } from "react";
import agent from "../../api/agent";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import handleApiError from "../../api/HandleApiError";
import { FaEye, FaEyeSlash } from "react-icons/fa";

const ChangePassword = () => {
  const [userId, setUserId] = useState("");
  const [showPassword, setShowPassword] = useState(false);

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  useEffect(() => {
    const storedUserId = localStorage.getItem("userId");
    if (storedUserId) {
      setUserId(storedUserId);
    }
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    const oldPassword = e.target.oldPassword.value;
    const newPassword = e.target.newPassword.value;
    const confirmPassword = e.target.confirmNewPassword.value;

    if (newPassword !== confirmPassword) {
      toast.error("New password and confirm password do not match.", { closeButton: <div style={{ width: "25%" }}></div> });
      return;
    }

    const formData = new FormData();
    formData.append("userId", userId);
    formData.append("oldPassword", oldPassword);
    formData.append("newPassword", newPassword);
    formData.append("confirmNewPassword", confirmPassword);

    agent.Identity.changePassword(formData)
      .then(() => {
        toast.success("Password got changed successfully", { closeButton: <div style={{ width: "25%" }}></div> });
        e.target.reset();
      })
      .catch((error) => {
        console.error("Error changing password:", error);
        handleApiError(error, "Password change failed");
      });
  };

  return (
    <div className="container-xl px-4 mt-4" style={{ marginBottom:"70px"}}>
      <hr className="mt-0 mb-4" />
      <div className="row" style={{ justifyContent: "center" }}>
        <div className="col-xl-9">
          <div className="card mb-4">
            <div className="card-header text-center"> Change Password </div>
            <div className="card-body">
              <form
                style={{ width: "800px", fontSize: "14px", margin: "0 auto" }}
                onSubmit={handleSubmit}
              >
                <div className="form-group mb-4">
                  <label>Old Password</label>
                  <div className="input-group">
                    <input
                      type={showPassword ? "text" : "password"}
                      id="oldPasswordInput"
                      className="form-control"
                      name="oldPassword"
                    />

                    <span
                      className="input-group-text"
                      onClick={togglePasswordVisibility}
                    >
                      {showPassword ? <FaEyeSlash /> : <FaEye />}
                    </span>
                  </div>
                </div>

                <div className="form-group mb-4">
                  <label htmlFor="newPassword">New Password</label>
                  <div className="input-group">
                    <input
                      type={showPassword ? "text" : "password"}
                      name="newPassword"
                      id="newPasswordInput"
                      className="form-control"
                    />
                  </div>
                </div>

                <div className="form-group mb-2">
                  <label>Confirm New Password</label>
                  <div className="input-group">
                    <input
                      type={showPassword ? "text" : "password"}
                      className="form-control"
                      name="confirmNewPassword"
                    />
                  </div>
                </div>
                <br />
                <button className="saveButton" style={{marginBottom:"10px", fontSize:"15px", width:"250px"}} type="submit">
                  Change Password
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
      <hr />
    </div>
  );
};

export default ChangePassword;
