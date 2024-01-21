import React, { useEffect, useState } from "react";
import "../../styles/team&tournament&player_details.css";
import TournamentSettings from "./TournamentSettings";
import TournamentTeams from "./TournamentTeams";
import agent from "../../api/agent";
import { useParams } from "react-router-dom";


const TournamentDetailsForm = () => {
    const { tournamentId } = useParams();
    const [tournament, setTournament] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [activeTab, setActiveTab] = useState("teams");
    const userId = localStorage.getItem('userId');
    const [user, setUser] = useState(null); 

    const isTournamentOwner = user && user.id === tournament.tournamentAdministratorId;

    useEffect(() => {
        if (userId) {
            agent.User.getUserById(userId)
                .then(response => { setUser(response) })
                .catch(error => { console.error("Error fetching user data:", error); });
        }
    }, [userId]);

    const fetchTournament = async () => {
        try {
            var response = await agent.Tournament.getTournamentById(tournamentId);
            setTournament(response);
            setLoading(false);
        } catch (error) {
            setError(error);
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchTournament();
    }, []);

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


    const showSettings = () => {
        setActiveTab("settings");
    };

    
    
    return (
        <div className="the-profile mt-4">
            <header className="custom-header">
                <div className="profile-info">
                    <div className="profile-picture">
                        <img src={tournament.imageUrl} alt="Tournament Logo" className="w-auto" />
                    </div>
                    
                    <div className="the-info">
                        <h3><b>{tournament.name}</b></h3>
                        <p> <b>Tournament</b> </p>
                        <p> Sport: <b> {tournament.sportName} </b> </p>
                    </div>
                </div>
            </header>

            <nav className="nav nav-tabs">
                <a className={`nav-link ${activeTab === "teams" ? "active" : "notActive"}`} onClick={showTeams}>
                    Teams
                </a>
          

                {isTournamentOwner && (
                    <a className={`nav-link ${activeTab === "settings" ? "active" : "notActive"}`} onClick={showSettings}>
                        Settings
                    </a>
                )}

                
            </nav>

            <div className="tab-content">
                {activeTab === "teams" && (
                   <TournamentTeams tournament={tournament} fetchTournament={fetchTournament} />
                )}
                
                {activeTab === "settings" && isTournamentOwner && (
                    <TournamentSettings tournament={tournament} fetchTournament={fetchTournament} />
                )}

               
            </div>
        </div>
    );
}

export default TournamentDetailsForm;
