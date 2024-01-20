import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import agent from "../../api/agent";
import "../../styles/team&tournament_settings.css";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import handleApiError from "../../api/HandleApiError";
import ConfirmationModalForm from "../ConfirmationModalForm";

const TeamSettings = ({ team, fetchTeam }) => {
  const [editableTeam, setEditableTeam] = useState({ ...team });
  const [showConfirmModal, setShowConfirmModal] = useState(false);
  const navigate = useNavigate();

  const handleImageUpload = (e) => {
    const file = e.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const imageDataURL = e.target.result;
        setEditableTeam((prevEditableTeam) => ({
          ...prevEditableTeam,
          logoUrl: file,
          logo: imageDataURL,
        }));
      };
      reader.readAsDataURL(file);
    }
  };

  const editTeamDetails = async () => {
    toast.dismiss();
    const teamDetails = {
      teamId: editableTeam.teamId,
      name: editableTeam.name,
      shortName: editableTeam.shortName,
      description: editableTeam.description,
      location: editableTeam.location,
      yearFounded: editableTeam.yearFounded,
    };

    try {
      const response = await agent.Team.editTeam(teamDetails);
      if (response.status === 200) {
        fetchTeam();
        toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
      } else {
        handleApiError(response, "The team details couldn't be updated successfully");
      }
    } catch (error) {
      handleApiError(error, "The team details couldn't be updated successfully");
    }
  };

  const editTeamLogo = async (e) => {
    e.preventDefault();
    toast.dismiss();
    const formData = new FormData();
    formData.append("logo", editableTeam.logoUrl);
    formData.append("teamId", editableTeam.teamId);

    try {
      const response = await agent.Team.editTeamLogo(formData);
      if (response.status === 200) {
        fetchTeam();
        toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
      } else {
        handleApiError(response, "The team logo couldn't be updated successfully");
      }
    } catch (error) {
      handleApiError(error, "The team logo couldn't be updated successfully");
    }
  };

  const handleShowConfirmModal = () => {
    setShowConfirmModal(true);
  };
  const handleCloseConfirmModal = () => {
    setShowConfirmModal(false);
  };
  const deleteTeam = async () => {
    handleShowConfirmModal(); 
  };

  const confirmDeleteTeam = async () => {
    handleCloseConfirmModal();
    try {
      const response = await agent.Team.deleteTeam(editableTeam.teamId);
      if (response.status === 200) {
        toast.success("Team got deleted successfully", { closeButton: <div style={{ width: "25%" }}></div> });
        navigate("/my-teams");
      } else {
        toast.error("Error deleting the team", { closeButton: <div style={{ width: "25%" }}></div> });
      }
    } catch (error) {
      handleApiError(error, "Error deleting the team");
    }
  };

  return (
    <div className="container-xl px-4 mt-4">
      <div className="row">
        <div className="col-xl-4">
          <div className="card mb-4 mb-xl-0">
            <div className="card-header text-center">Team Logo</div>
            <div className="card-body text-center">
              <div className="image-upload-container">
                <label htmlFor="uploadButton" className="image-clickable">
                  <img
                    src={editableTeam.logo || team.logoUrl}
                    className="img-account-profile img-thumbnail img-fluid mb-2"
                    alt="Profile"
                    style={{ objectFit: "contain", height: "150px", cursor: "pointer" }}
                  />
                  <input
                    type="file"
                    accept="image/*"
                    onChange={handleImageUpload}
                    id="uploadButton"
                    className="btn btn-primary w-auto"
                    style={{ display: "none" }}
                  />
                </label>
              </div>

              <div>
                <button
                  className="saveButton"
                  type="button"
                  onClick={editTeamLogo}
                >
                  Save Changes
                </button>
              </div>
            </div>
          </div>

          <div className="card my-4">
            <div className="card-header text-center">Team Deletion</div>
            <div className="card-body text-center">
              <button className="deleteButton" type="button" onClick={deleteTeam}>
                Delete Team
              </button>
            </div>
          </div>

          <ConfirmationModalForm 
            headerText={"Delete Confirmation"}
            bodyText={`Are you sure you want to delete ${team.name}?`} 
            showConfirmModal={showConfirmModal}
            handleCloseConfirmModal={handleCloseConfirmModal}
            confirmDelete={confirmDeleteTeam} 
          />
        </div>

        <div className="col-xl-8">
          <div className="card mb-4">
            <div className="card-header">Team Details</div>
            <div className="card-body">
              <form>

                <div className="row gx-3">
                  <div className="col-md-6 mb-3">
                    <label className="small mb-1" htmlFor="inputTeamName"> Team Name: </label>
                    <input
                      className="form-control"
                      name="name"
                      type="text"
                      placeholder="Enter your team name"
                      value={editableTeam.name}
                      onChange={(e) => setEditableTeam({ ...editableTeam, name: e.target.value })}
                    />
                  </div>

                  <div className="col-md-6 mb-3">
                    <label className="small mb-1" htmlFor="inputTeamName"> Team Short Name: </label>
                    <input
                      className="form-control"
                      name="shortName"
                      type="text"
                      placeholder="Enter your team short name"
                      value={editableTeam.shortName}
                      onChange={(e) => setEditableTeam({ ...editableTeam, shortName: e.target.value })}
                    />
                  </div>
                </div>

                <div className="row gx-3">
                  <div className="col-md-6 mb-3">
                    <label className="small mb-1" htmlFor="inputDescription"> Team Location: </label>
                    <input
                      className="form-control"
                      name="description"
                      type="text"
                      placeholder="Enter your team description"
                      value={editableTeam.location}
                      onChange={(e) => setEditableTeam({ ...editableTeam, location: e.target.value })}
                    />
                  </div>
                  
                  <div className="col-md-6 mb-3">
                    <label className="small mb-1" htmlFor="inputDescription"> Year Founded: </label>
                    <input
                      className="form-control"
                      name="yearFounded"
                      type="number"
                      placeholder="Enter the year"
                      value={editableTeam.yearFounded}
                      onChange={(e) => setEditableTeam({ ...editableTeam, yearFounded: e.target.value })}
                    />
                  </div>
                </div>

                <div className="mb-3">
                  <label className="small mb-1" htmlFor="inputDescription"> Team Description: </label>
                  <textarea
                    className="form-control"
                    name="description"
                    placeholder="Enter your team description"
                    value={editableTeam.description}
                    onChange={(e) => setEditableTeam({ ...editableTeam, description: e.target.value })}
                    rows={3}
                  ></textarea>
                </div>
              
                <button
                  className="saveButton"
                  type="button"
                  onClick={editTeamDetails}
                >
                  Save changes
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
export default TeamSettings;
