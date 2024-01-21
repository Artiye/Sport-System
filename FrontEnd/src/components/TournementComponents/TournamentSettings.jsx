import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import agent from "../../api/agent";
import "../../styles/team&tournament_settings.css";
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import handleApiError from "../../api/HandleApiError";
import ConfirmationModalForm from "../ConfirmationModalForm";

const TournamentSettings = ({ tournament, fetchTournament }) => {
  const [editableTournament, setEditableTournament] = useState({ ...tournament });
  const [showConfirmModal, setShowConfirmModal] = useState(false);
  const navigate = useNavigate();

  const handleImageUpload = (e) => {
    const file = e.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const imageDataURL = e.target.result;
        setEditableTournament((prevEditableTournament) => ({
          ...prevEditableTournament,
          imageUrl: file,
          logo: imageDataURL,
        }));
      };
      reader.readAsDataURL(file);
    }
  };

  const editTournamentDetails = async () => {
    toast.dismiss();
    const tournamentDetails = {
      tournamentId: editableTournament.tournamentId,
      name: editableTournament.name,
      description: editableTournament.description,
      location: editableTournament.location,
      startDate: editableTournament.startDate,
      endDate: editableTournament.endDate,
      rules: editableTournament.rules,
    };
    
    try {
      const response = await agent.Tournament.editTournament(tournamentDetails);
      if (response.status === 200) {
        fetchTournament();
        toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
      } else {
        handleApiError(response, "The tournament details couldn't be updated successfully");
      }
    } catch (error) {
      handleApiError(error, "The tournament details couldn't be updated successfully");
    }
  };

  const editTournamentLogo = async () => {
    toast.dismiss();
    const formData = new FormData();
    formData.append("logo", editableTournament.imageUrl);
    formData.append("tournamentId", editableTournament.tournamentId);

    try {
      const response = await agent.Tournament.editTournamentLogo(formData);
      if (response.status === 200) {
        fetchTournament();
        toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
      } else {
        handleApiError(response, "The tournament logo couldn't be updated successfully");
      }
    } catch (error) {
      handleApiError(error, "The tournament logo couldn't be updated successfully");
    }
  };

  const handleShowConfirmModal = () => {
    setShowConfirmModal(true);
  };

  const handleCloseConfirmModal = () => {
    setShowConfirmModal(false);
  };

  const handleDelete = async () => {
    handleShowConfirmModal(); 
  };

  const deleteTournament = async () => {
    toast.dismiss();
    handleCloseConfirmModal(); 
    try {
      const response = await agent.Tournament.deleteTournament(editableTournament.tournamentId);
      if (response.status === 200) {
        toast.success("The tournament got deleted successfully", {closeButton: <div style={{ width: "25%" }}></div> });
        navigate("/tournaments");
      } else {
        handleApiError(response, "Error deleting the tournament");
      }
    } catch (error) {
      handleApiError(error, "Error deleting the tournament");
    }
  };

  return (
    <div className="container-xl px-4 mt-4">
      <div className="row">
        <div className="col-xl-4">
          <div className="card mb-4 mb-xl-0">
            <div className="card-header text-center">Tournament Logo</div>
            <div className="card-body text-center">
              <div className="image-upload-container">
                <label htmlFor="uploadButton" className="image-clickable">
                  <img
                    src={editableTournament.logo || tournament.imageUrl}
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
                  onClick={editTournamentLogo}
                >
                  Save Changes
                </button>
              </div>
            </div>
          </div>

          <div className="card my-4">
            <div className="card-header text-center">Tournament Deletion</div>
            <div className="card-body text-center">
              <button className="deleteButton" type="button" onClick={handleDelete}>
                Delete Tournament
              </button>
            </div>
          </div>

          <ConfirmationModalForm
            headerText={"Delete Confirmation"}
            bodyText={`Are you sure you want to delete the ${tournament.name}?`} 
            showConfirmModal={showConfirmModal}
            handleCloseConfirmModal={handleCloseConfirmModal} 
            confirmDelete={deleteTournament}
          />
        </div>

        <div className="col-xl-8">
          <div className="card mb-4">
            <div className="card-header">Tournament Details</div>
            <div className="card-body">
              <form>
                <div className="mb-3">
                  <label className="small mb-1" htmlFor="inputTournamentName"> Name: </label>
                  <input
                    className="form-control"
                    name="name"
                    type="text"
                    placeholder="Enter your tournament name"
                    value={editableTournament.name}
                    onChange={(e) => setEditableTournament({ ...editableTournament, name: e.target.value })}
                  />
                </div>
                
                <div className="mb-5">
                  <label className="small mb-1" htmlFor="inputDescription"> Description: </label>
                  <textarea
                    className="form-control "
                    name="description"
                    placeholder="Enter your tournament description"
                    value={editableTournament.description}
                    onChange={(e) => setEditableTournament({ ...editableTournament, description: e.target.value })}
                    rows={5}
                  ></textarea>
                </div>

                <button
                  className="saveButton"
                  type="button"
                  onClick={editTournamentDetails}
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
export default TournamentSettings;
