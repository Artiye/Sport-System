import React from "react";
import "../../styles/tournament&player-teams.css";
import { Link } from "react-router-dom";

const PlayerTeams = ({ teams }) => {
  return (
    <div className="team-container">
      {teams.length === 0 ? (
        <h4 className="m-5">This player doesn't have any teams yet.</h4>
      ) : (
        teams.map((team, index) => {
          return (
            <div key={index} className="team-card">
              <Link to={`/teams/${team.teamId}`} style={{ textDecoration: "none", color: "inherit" }}>
                <div className="team-picture">
                  <img src={team.logoUrl} alt={team.name} />
                </div>

                <div className="team-info">
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

export default PlayerTeams;
