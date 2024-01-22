import React, { useEffect, useState } from "react";
import "../../styles/team&tournament&player_details.css";
import agent from "../../api/agent";
import { useParams } from "react-router-dom";
import PlayerTeams from "./PlayerTeams";
import PlayerInfo from "./PlayerInfo";

const PlayerDetailsForm = () => {
  const { applicationUserId } = useParams();
  const [user, setUser] = useState([]);
  const [teamsUserPlaysAt, setTeamsUserPlaysAt] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [activeTab, setActiveTab] = useState("teams");
  const [playerProfiles, setPlayerProfiles] = useState([]);
  
  const fetchTeamsUserPlaysAt = async () => {
    try {
      const response = await agent.Team.getTeamsUserPlaysFor(applicationUserId);
      setTeamsUserPlaysAt(response);
      setLoading(false);
    } catch (error) {
      setError(error);
      setLoading(false);
    }
  };

  const fetchUser = async () => {
    try {
      var response = await agent.User.getUserById(applicationUserId)
      setUser(response);
      setLoading(false);
    } catch (error) {
      setError(error);
      setLoading(false);
    }
  };

  const fetchPlayersList = async () => {
    try {
      const playersResponse = await agent.Player.getPlayersByApplicationUser(applicationUserId); 
      setPlayerProfiles(playersResponse);
    } catch (error) {
      console.error('Error fetching teams:', error);
    }
  };

  useEffect(() => {
      fetchUser();
      fetchPlayersList();
      fetchTeamsUserPlaysAt();
  }, [applicationUserId]);
  
  if (error) {
    console.error('API Error:', error);
    return <div>Error: {error.message}</div>;
  }
  if (loading) {
    console.log('Loading...');
    return <div>Loading...</div>;
  }

  const showTeams = () => {
    setActiveTab("teams");
  };

  const showPlayerDetails = () => {
    setActiveTab("details");
  };  

  return (
    <div className="the-profile mt-4">
      <header className="custom-header">
          <div className="profile-info">
              <div className="player_profile-picture">
                <img src={user.profileUrl} alt="Team Logo" className="rounded-circle" />
              </div>
          
              <div className="the-info">
                <h3><b>{user.firstName} {user.lastName}</b></h3>
                <p> <b>Player</b> </p>
              </div>
          </div>
      </header>

      <nav className="nav nav-tabs">        
        <a className={`nav-link ${activeTab === "teams" ? "active" : "notActive"}`} onClick={showTeams} >
          Teams
        </a>

        <a className={`nav-link ${activeTab === "details" ? "active" : "notActive"}`} onClick={showPlayerDetails}>
          Details
        </a>
      </nav>
  
      <div className="tab-content">
        {activeTab === "teams" && (
          <PlayerTeams teams={teamsUserPlaysAt} />
        )}
        
        {activeTab === "details" && (
          <PlayerInfo user={user} />
        )}
      </div>
    </div>
  );
}

export default PlayerDetailsForm;
