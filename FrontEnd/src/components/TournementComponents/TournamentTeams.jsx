import React, { useState } from "react";
import "../../styles/tournament&player-teams.css";
import { Link } from "react-router-dom";
import agent from "../../api/agent";
import "react-toastify/dist/ReactToastify.css";
import handleApiError from "../../api/HandleApiError";
import { toast } from "react-toastify";
import ConfirmationModalForm from "../ConfirmationModalForm";

const TournamentTeams = ({ tournament, fetchTournament }) => {
  const [selectedTeamId, setSelectedTeamId] = useState(null);
  const [showConfirmModal, setShowConfirmModal] = useState(false);

  const userId = localStorage.getItem('userId');
  const isTournamentOwner = userId && userId === tournament.tournamentAdministratorId;

  const handleEditClick = (teamId) => {
    setSelectedTeamId(teamId);
    setShowConfirmModal(true);
  };

  const handleCloseConfirmModal = () => {
    setSelectedTeamId(null);
    setShowConfirmModal(false);
  };

  const handleKickOutClick = async () => {
    toast.dismiss();
    handleCloseConfirmModal();

    try {
      const response = await agent.Tournament.removeTeamFromTournament(tournament.tournamentId, selectedTeamId);
      if (response.status === 200) {
        fetchTournament();
        toast.success(`Team got kicked out of the tournament successfully.`, {closeButton: <div style={{ width: "25%" }}></div>});
      } else {
        handleApiError(response, "An error occurred while kicking out the team from the your tournament.");
      }
    } catch (error) {
      handleApiError(error, "An error occurred while kicking out the team from the your tournament.");
    }
  };

  const confirmDelete = () => {
    if (selectedTeamId) {
      handleKickOutClick(selectedTeamId);
    }
    handleCloseConfirmModal();
  };

  return (
    <div className="team-container">
      {tournament.teams.length === 0 ? (
        <h4 className="m-5"> This tournament doesn't have any teams yet. </h4>
      ) : (
        tournament.teams.map((team, index) => {
          return (
            <div key={index} className="team-card">
              {isTournamentOwner && (
                <div>
                  <button className="player_edit-button text-center" style={{margin:"0 0px", height:"0px"}} onClick={() => handleEditClick(team.teamId)}>
                    <i class="ri-logout-box-r-line"></i>
                  </button>
                  
                  <ConfirmationModalForm
                    headerText={"Kick-out Confirmation"}
                    bodyText={`Are you sure you want to kick out ${team.name}?`}
                    showConfirmModal={showConfirmModal}
                    confirmDelete={confirmDelete}
                    handleCloseConfirmModal={handleCloseConfirmModal}
                  />
                </div>
              )}           
              
              <Link to={`/teams/${team.teamId}`} style={{ textDecoration: "none", color: "inherit" }}>
                <div className="team-picture mt-2">
                  <img src={team.logoUrl} alt={team.name} />
                </div>

                <div className="team-info mb-2">
                  <div>
                    <h5>
                      <strong> {team.name} </strong>
                    </h5>
                  </div>
                </div>
              </Link>
            </div>
          );
        })
      )}
    </div>
  );
};

export default TournamentTeams;
