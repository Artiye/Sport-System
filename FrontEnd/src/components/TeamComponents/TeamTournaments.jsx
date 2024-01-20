import React from "react";
import "../../styles/team-tournaments.css";
import { Link } from "react-router-dom";

const TeamTournaments = ({ tournaments }) => {
    return (
        <div className="tournament-container">
          {tournaments.length === 0 ? (
            <h4 className="text-center" style={{margin:"48px"}}>This team is not participating in any tournaments yet.</h4>
          ) : (
            tournaments.map((tournament, index) => {
              return (
                <div key={index} className="tournament-card">
                  <Link to={`/tournament/${tournament.tournamentId}`} style={{ textDecoration: "none", color: "inherit" }}>
                    <div className="tournament-picture">
                      <img src={tournament.imageUrl} alt={tournament.name} />
                    </div>
    
                    <div className="tournament-info">
                      <div>
                        <h5>
                          <strong> {tournament.name} </strong>
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

export default TeamTournaments;
