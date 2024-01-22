import React, { useState, useEffect } from "react";
import "../../styles/team-players.css";
import { Link } from "react-router-dom";
import agent from "../../api/agent";
import "react-toastify/dist/ReactToastify.css";
import handleApiError from "../../api/HandleApiError";
import { toast } from "react-toastify";
import ConfirmationModalForm from "../ConfirmationModalForm";

const TeamPlayers = ({ players, team, fetchTeam }) => {
  const [userPlayer, setUserPlayer] = useState({});
  const [selectedPlayerId, setSelectedPlayerId] = useState(null);
  const [editedPlayerData, setEditedPlayerData] = useState({ jerseyNumber: "", position: "" });
  const [isEditMode, setIsEditMode] = useState(false);
  const [showConfirmModal, setShowConfirmModal] = useState(false);

  const userId = localStorage.getItem('userId');
  const isTeamOwner = team.teamOwnerId === userId;

  const fetchData = async () => {
    const userPlayerData = {};
    const playerPromises = players.map(async (player) => {
      const userData = await agent.User.getUserById(player.applicationUserId);
      userPlayerData[player.playerId] = { ...player, userData };
    });
    await Promise.all(playerPromises);
    setUserPlayer(userPlayerData);
  };

  useEffect(() => {
    fetchData();
  }, [players]);

  const handleEditClick = (playerId) => {
    setSelectedPlayerId(playerId);
    setIsEditMode(true);

    setEditedPlayerData({
      jerseyNumber: userPlayer[playerId].jerseyNumber,
      position: userPlayer[playerId].position,
    });
  };

  const handleCancelClick = () => {
    setSelectedPlayerId(null);
    setIsEditMode(false);
  };

  const handleSaveClick = async () => {
    toast.dismiss();
    try { 
      const formData = new FormData();
      formData.append('playerId', selectedPlayerId);
      formData.append('jerseyNumber', editedPlayerData.jerseyNumber);
      formData.append('position', editedPlayerData.position);

      const response = await agent.Player.updatePlayer(formData);
  
      if (response.status === 200) {
        fetchTeam();
        setSelectedPlayerId(null);
        setIsEditMode(false);
        toast.success(response.message, { closeButton: <div style={{ width: "25%" }}></div> });
      } else {
        handleApiError(response, "The player details couldn't be updated successfully");
      }
    } catch (error) {
      handleApiError(error, "The player details couldn't be updated successfully");
    }
  };

  const handleShowConfirmModal = () => {
    setShowConfirmModal(true);
  };
  const handleCloseConfirmModal = () => {
    setShowConfirmModal(false);
  };
  const kickOutPlayer = async () => {
    handleShowConfirmModal(); 
  };

  const handleKickOutClick = async (playerId) => {
    toast.dismiss();
    handleCloseConfirmModal(); 
    try {  
      const response = await agent.Player.deletePlayer(playerId);
  
      if (response.status === 200) {
        fetchTeam();
        setIsEditMode(false);
        toast.success('Player got kicked out successfully', { closeButton: <div style={{ width: "25%" }}></div> });
      } else {
        handleApiError( response, "The player couldn't be kicked out of the team successfully");
      }
    } catch (error) {
      handleApiError( error, "The player couldn't be kicked out of the team successfully");
    }
  };
  
  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedPlayerData((prevData) => ({ ...prevData, [name]: value }));
  };

  const filteredPlayers = players.filter((player) => userPlayer[player.playerId]);

  return (
    <div className="player-container">
      {filteredPlayers.length === 0 ? (
        <h4 className="m-5">This team doesn't have any players yet.</h4>
      ) : (
        filteredPlayers.map((player) => {
          const playerUserData = userPlayer[player.playerId];
          return (
            <div key={player.playerId} className="player-card">
              {isEditMode && selectedPlayerId === player.playerId ? null : (
                <div>
                  {isTeamOwner ? (
                    <button className="player_edit-button text-center" onClick={() => handleEditClick(player.playerId)}>
                      <i className="ri-edit-box-line"></i>
                    </button>
                    ):<Link to={`/player/${playerUserData.userData.id}`} style={{ textDecoration: "none", color: "inherit" }}>
                        <div className="pt-3"> </div>
                      </Link>
                  }
                </div>
              )}
              
              {isEditMode && selectedPlayerId === player.playerId ? (
                <div className="edit-form">
                  <label>
                    <strong>Position:</strong>
                    <input
                      type="text"
                      name="position"
                      value={editedPlayerData.position}
                      onChange={handleChange}
                      className="player_edit-fields"
                    />
                  </label>

                  <label>
                    <strong>Jersey Number:</strong>
                    <input
                      type="number"
                      name="jerseyNumber"
                      value={editedPlayerData.jerseyNumber}
                      onChange={handleChange}
                      className="player_edit-fields"
                    />
                  </label>
                  
                  <div className="edit-buttons">
                    <button id="edit-button_save" onClick={handleSaveClick}>Save</button>
                    <button id="edit-button_cancel" onClick={handleCancelClick}>Cancel</button>
                  </div>

                  <hr className="hr-line"/>

                  <div className="kickOut-button">
                    <button onClick={kickOutPlayer}>Kick Out</button>
                  </div>

                  <ConfirmationModalForm
                    headerText={"Kick-out Confirmation"}
                    bodyText={`Are you sure you want to kick out ${playerUserData.userData.firstName} ${playerUserData.userData.lastName}?`}
                    showConfirmModal={showConfirmModal}
                    confirmDelete={() => handleKickOutClick(player.playerId)}
                    handleCloseConfirmModal={handleCloseConfirmModal}
                  />
                </div>
              ) : (
                <Link to={`/player/${playerUserData.userData.id}`} style={{ textDecoration: "none", color: "inherit" }}>
                  <div className="player-picture">
                    <img src={playerUserData.userData.profileUrl} alt={player.name} />
                  </div>

                  <div className="player-info">
                    <div>
                      <p>
                        <strong>Name: </strong> {playerUserData.userData.firstName} {playerUserData.userData.lastName}
                      </p>
                      <p>
                        <strong>Nationality: </strong> {playerUserData.userData.nationality}
                      </p>
                    </div>
                    <p>
                      <strong>Position: </strong> {playerUserData.position}
                    </p>
                    <p>
                      <strong>Jersey Number: </strong> {playerUserData.jerseyNumber}
                    </p>
                  </div>
                </Link>
              )}
            </div>
          );
        })
      )}
    </div>
  );
};

export default TeamPlayers;
