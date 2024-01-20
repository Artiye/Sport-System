import React, { useEffect, useState } from "react";
import "../../styles/team&tournament&player_details.css";
import TeamSettings from "./TeamSettings";
import agent from "../../api/agent";
import { useParams } from "react-router-dom";
import TeamTournaments from "./TeamTournaments";

const TeamDetailsForm = () => {
    const { teamId } = useParams();
    const [team, setTeam] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [activeTab, setActiveTab] = useState("players");
    const userId = localStorage.getItem('userId');

    const fetchTeam = async () => {
      try {
        var response = await agent.Team.getTeamById(teamId);
        setTeam(response);
        setLoading(false);
      } catch (error) {
        setError(error);
        setLoading(false);
      }
    };
    
    useEffect(() => {
        fetchTeam();
    }, [userId]);
  
    if (error) {
      console.error('API Error:', error);
      return <div>Error: {error.message}</div>;
    }

    if (loading) {
      console.log('Loading...');
      return <div>Loading...</div>;
    }
  
    const showTournaments = () => {
        setActiveTab("tournaments");
    };

    const showSettings = () => {
        setActiveTab("settings");
    };

    return (
        <div className="the-profile mt-4">
            <header className="custom-header">
                <div className="profile-info">
                    <div className="profile-picture">
                        <img src={team.logoUrl} alt="Team Logo" className="w-auto" />
                    </div>
                
                    <div className="the-info">
                        <h3><b>{team.name}</b></h3>
                        <p> <b>Team</b> </p>
                        <p> Sport: <b> {team.sportName} </b> </p>
                    </div>
                </div>
            </header>
        
            <nav className="nav nav-tabs">
                <a className={`nav-link ${activeTab === "tournaments" ? "active" : "notActive"}`} onClick={showTournaments} >
                    Tournaments
                </a>

                {team.teamOwnerId === userId && (
                    <a className={`nav-link ${activeTab === "settings" ? "active" : "notActive"}`} onClick={showSettings}>
                        Settings
                    </a>
                )}
            </nav>
        
            <div className="tab-content">   
                {activeTab === "tournaments" && (
                    <TeamTournaments tournaments={team.tournaments} />
                )}
            
                {activeTab === "settings" && (
                    <TeamSettings team={team} fetchTeam={fetchTeam} />
                )}
            </div>
        </div>
    );
}

export default TeamDetailsForm;
