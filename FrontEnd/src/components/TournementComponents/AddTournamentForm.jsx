import React, { useState, useEffect } from "react";
import agent from "../../api/agent";
import "../../styles/add-team&tournament.css";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import handleApiError from "../../api/HandleApiError";

const AddTournamentForm = () => {
  const [tournamentName, setTournamentName] = useState("");
  const [tournamentDescription, setTournamentDescription] = useState("");
  const [tournamentPhoto, setTournamentPhoto] = useState(null);
  const [tournamentSport, setTournamentSport] = useState(0);
  const [sports, setSports] = useState([]);
  const userId = localStorage.getItem("userId");
  const navigate = useNavigate();

  useEffect(() => {
    handleFetchSports();
  }, []);

  const handleAddTournament = async (e) => {
    toast.dismiss();
    e.preventDefault();
    const tournamentData = new FormData();
    tournamentData.append("tournamentAdministratorId", userId);
    tournamentData.append("name", tournamentName);
    tournamentData.append("description", tournamentDescription);
    tournamentData.append("sportId", tournamentSport);
    tournamentData.append("logo", tournamentPhoto);

    try {
      const response = await agent.Tournament.addTournament(tournamentData);
      toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
      navigate("/my-tournaments");

    } catch (error) {
      console.error("Error adding tournament:", error);
      handleApiError(error, "The tournament couldn't be added successfully");
    }
  };

  const handleFetchSports = async () => {
    try {
      const response = await agent.Sport.getAllSports(userId);
      console.log("API Response:", response);
      setSports(response);
    } catch (error) {
      console.error("API Error:", error);
    }
  };

  return (
    <form onSubmit={handleAddTournament} className="centered-form">
      <div className="form-container">
        <div className="theHeader">
          <h4> <b> Create a new Tournament </b></h4>
        </div>

        <div className="col-md-12 mb-3 pt-3">
          <label className="small" htmlFor="inputDescription">
            Name:
          </label>
          <input
            type="text"
            value={tournamentName}
            placeholder="Tournament Name"
            onChange={(e) => setTournamentName(e.target.value)}
            className="input-field"
          />
        </div>

        <div className="row gx-3 mb-3">
          <div className="col-md-12">
            <label className="small" htmlFor="inputDescription">
              Select the Sport:
            </label>
            <select
              value={tournamentSport}
              onChange={(e) => setTournamentSport(e.target.value)}
              className="input-field"
            >
              <option value="0">Select a Sport</option>
              {sports.map((sport) => (
                <option key={sport.sportId} value={sport.sportId}>
                  {sport.name}
                </option>
              ))}
            </select>
          </div>

          <div className="col-md-12 mt-3">
            <label className="small" htmlFor="inputDescription">
              Select the Tournament Logo:
            </label>
            <input
              type="file"
              accept="image/*"
              onChange={(e) => setTournamentPhoto(e.target.files[0])}
              className="input-field"
              style={{ backgroundColor: "white" }}
            />
          </div>
        </div>

        <button type="submit" className="submit-button">
          Add Tournament
        </button>
      </div>
    </form>
  );
};

export default AddTournamentForm; 