import React, { useEffect, useState } from "react";
import agent from "../../api/agent";
import "../../styles/ProfilePage.css";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import handleApiError from "../../api/HandleApiError";

const ProfileForm = () => {
  const userId = localStorage.getItem("userId");
  const [user, setUser] = useState(null);
  const [editableUser, setEditableUser] = useState(null);

  const handleFetchChanges = () => {
    if (userId) {
      agent.User.getUserById(userId)
        .then((response) => {
          setUser(response);
          setEditableUser({ ...response });
        })
        .catch((error) => {
          console.error("Error fetching user data:", error);
        });
    }
  };

  useEffect(() => {
    handleFetchChanges();
  }, [userId]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setEditableUser({ ...editableUser, [name]: value });
  };

  const saveChanges = async (e) => {
    e.preventDefault();
    toast.dismiss();

    const formData = new FormData();
    formData.append("id", editableUser.id);
    formData.append("firstName", editableUser.firstName);
    formData.append("lastName", editableUser.lastName);
    formData.append("username", editableUser.username);
    formData.append("gender", editableUser.gender);
    formData.append("dateOfBirth", editableUser.dateOfBirth);
    formData.append("nationality", editableUser.nationality);
    formData.append("email", editableUser.email);
    formData.append("roles", editableUser.roles);

    try {
      const response = await agent.User.updateUser(formData);
      if(response.status == 200) {
        toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
        handleFetchChanges();
      } else { handleApiError(response.message, "The user details couldn't be updated successfully")}
    } catch (error) {
      handleApiError(error, "The user details couldn't be updated successfully");
    }
  };

  const handleImageUpload = (e) => {
    const file = e.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const imageDataURL = e.target.result;
        setEditableUser((prevEditableTeam) => ({ ...prevEditableTeam, profileUrl: file, profile: imageDataURL }));
      };
      reader.readAsDataURL(file);
    }
  };

  const saveProfilePictureChanges = async (e) => {
    e.preventDefault();
    toast.dismiss();

    const formData = new FormData();
    formData.append("id", editableUser.id);
    formData.append("profileUrl", editableUser.profileUrl);

    try {
      const response = await agent.User.updateUserProfilePicture(formData);
      toast.success(response.message, {closeButton: <div style={{ width: "25%" }}></div>});
    } catch (error) {
      console.error("Error editing user profile picture:", error);
      handleApiError(error, "The user profile picture couldn't be updated successfully");
    }
  };

  return (
    <div className="container-xl px-4 mt-4" style={{ marginBottom: "70px" }}>
      <hr className="mt-0 mb-4" />
      {user && editableUser && (
        <div className="row">

          <div className="col-xl-4">
            <div className="card mb-4 mb-xl-0">
              <div className="card-header text-center">Profile Picture</div>
              <div className="card-body text-center">
                <div className="image-upload-container">
                  <label className="image-clickable">
                    <img
                      htmlFor="uploadButton"
                      className="img-account-profile rounded-circle mb-2"
                      src={editableUser.profile || user.profileUrl}
                      alt="Profile"
                      style={{ cursor: "pointer" }}
                    />

                    <input
                      name="profileUrl"
                      type="file"
                      id="uploadButton"
                      className="btn btn-primary w-auto"
                      style={{ display: "none" }}
                      accept=".jpg, .jpeg, .png"
                      onChange={handleImageUpload}
                    />
                  </label>
                </div>

                <div>
                  <button className="saveButton" type="button" onClick={saveProfilePictureChanges}>
                    Save Changes
                  </button>
                </div>
              </div>
            </div>
          </div>

          <div className="col-xl-8">
            <div className="card mb-4">
              <div className="card-header">Account Details</div>
              <div className="card-body">
                <form>
                  <div className="mb-3">
                    <label className="small mb-1" htmlFor="inputUsername">
                      Username:
                    </label>
                    <input
                      className="form-control"
                      id="inputUsername"
                      name="username"
                      type="text"
                      placeholder="Enter your username"
                      value={editableUser.username}
                      onChange={handleInputChange}
                    />
                  </div>

                  <div className="row gx-3 mb-3">
                    <div className="col-md-6">
                      <label className="small mb-1" htmlFor="inputFirstName">
                        First name
                      </label>
                      <input
                        placeholder="Enter your first name"
                        className="form-control"
                        id="inputFirstName"
                        name="firstName"
                        type="text"
                        value={editableUser.firstName}
                        onChange={handleInputChange}
                      />
                    </div>

                    <div className="col-md-6">
                      <label className="small mb-1" htmlFor="inputLastName">
                        Last name
                      </label>
                      <input
                        className="form-control"
                        id="inputLastName"
                        type="text"
                        placeholder="Enter your last name"
                        name="lastName"
                        value={editableUser.lastName}
                        onChange={handleInputChange}
                      />
                    </div>
                  </div>

                  <div className="row gx-3 mb-3">
                    <div className="col-md-6">
                      <label className="small mb-1" htmlFor="inputLocation">
                        Nationality
                      </label>
                      <input
                        className="form-control"
                        id="inputLocation"
                        type="text"
                        name="nationality"
                        value={editableUser.nationality}
                        onChange={handleInputChange}
                      />
                    </div>

                    <div className="col-md-6">
                      <label className="small mb-1" htmlFor="inputEmailAddress">
                        Email address
                      </label>
                      <input
                        className="form-control"
                        id="inputEmailAddress"
                        type="email"
                        name="email"
                        value={editableUser.email}
                        onChange={handleInputChange}
                      />
                    </div>
                  </div>

                  <div className="row gx-3 mb-3">
                    <div className="col-md-6">
                      <label className="small mb-1" htmlFor="inputPhone">
                        Gender
                      </label>
                      <input
                        className="form-control"
                        id="inputPhone"
                        type="text"
                        name="gender"
                        value={editableUser.gender}
                        onChange={handleInputChange}
                      />
                    </div>
                    <div className="col-md-6">
                      <label className="small mb-1" htmlFor="inputBirthday">
                        Birthday
                      </label>
                      <input
                        className="form-control"
                        id="inputBirthday"
                        type="datetime-local"
                        name="dateOfBirth"
                        value={editableUser.dateOfBirth ? editableUser.dateOfBirth : ""}
                        onChange={handleInputChange}
                      />
                    </div>
                  </div>

                  <button id="savebtn" className="btn btn-primary text-center" type="button" onClick={saveChanges}>
                    Save changes
                  </button>
                </form>
              </div>
            </div>
          </div>
        </div>
      )}
      <hr />
    </div>
  );
};

export default ProfileForm;
