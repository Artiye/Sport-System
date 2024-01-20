import React, { useState, useEffect } from "react";
import agent from "../../api/agent";
import "../../styles/add-team&tournament.css";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import handleApiError from "../../api/HandleApiError";

const AddTeamForm = () => {
  const [teamName, setTeamName] = useState("");
  const [teamPhoto, setTeamPhoto] = useState(null);
  const [teamSport, setTeamSport] = useState("");
  const [teamShortName, setTeamShortName] = useState("");
  const [teamDescription, setTeamDescription] = useState("");
  const [teamYearFounded, setTeamYearFounded] = useState("");
  const [sports, setSports] = useState([]);
  const userId = localStorage.getItem("userId");
  const navigate = useNavigate();

  useEffect(() => {
    handleFetchSports();
  }, []);

  const handleAddTeam = async (e) => {
    toast.dismiss();
    e.preventDefault();
    const teamData = new FormData();
    teamData.append("name", teamName);
    teamData.append("shortName", teamShortName);
    teamData.append("description", teamDescription);
    teamData.append("yearFounded", teamYearFounded);
    teamData.append("sportId", teamSport);
    teamData.append("teamOwnerId", userId);
    teamData.append("logo", teamPhoto);

    try {
      const response = await agent.Team.addTeam(teamData);
      if (response.status === 200) {
        navigate("/my-teams");
        toast.success(response.message, {closeButton: <div style={{ width: "25%" }}></div>});
      } else {
        handleApiError(response, "Team couldn't be added successfully");
      }
    } catch (error) {
      handleApiError(error, "Team couldn't be added successfully");
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
    <form onSubmit={handleAddTeam} className="centered-form">
      <div className="form-container">
        <div className="theHeader">
          <h4> <b> Create a new Team </b></h4>
        </div>

        <div className="col-md-12 mb-3 pt-3">
          <label className="small" htmlFor="inputDescription">
            Name:
          </label>
          <input
            type="text"
            value={teamName}
            placeholder="Team Name"
            onChange={(e) => setTeamName(e.target.value)}
            className="input-field"
          />
        </div>

        <div className="row gx-3 mb-3">
          <div className="col-md-12">
            <label className="small" htmlFor="inputDescription">
              Select the Sport:
            </label>
            <select
              value={teamSport}
              onChange={(e) => setTeamSport(e.target.value)}
              className="input-field"
            >
              <option value="">Select a Sport</option>
              {sports.map((sport) => (
                <option key={sport.sportId} value={sport.sportId}>
                  {sport.name}
                </option>
              ))}
            </select>
          </div>
        
          <div className="col-md-12 mt-3">
            <label className="small" htmlFor="inputDescription">
              Select the Team Logo:
            </label>
            <input
              type="file"
              accept="image/*"
              onChange={(e) => setTeamPhoto(e.target.files[0])}
              className="input-field"
              style={{ backgroundColor: "white" }}
            />
          </div>
        </div>
        
        <button type="submit" className="submit-button">
          Add Team
        </button>
      </div>
    </form>
  );
};

export default AddTeamForm;
