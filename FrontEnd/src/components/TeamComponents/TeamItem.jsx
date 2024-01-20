import React from "react";
import { Col } from "reactstrap";
import { Link } from "react-router-dom";
import "../../styles/team-item.css";

const TeamItem = ({ team }) => {  
  const { teamId, name, logoUrl, sportName } = team;

  return (
      <Col lg="4" md="4" sm="6" className="mb-5">
        <div className="team__item">
          <div className="team__img">
            <img src={logoUrl} alt="Team Logo" className="w-100" />
          </div>

          <div className="team__item-content mt-4">
            <h4 className="section__title text-center">{name}</h4>
            <h6 className="text-center mt-0 text-truncate text-nowrap"> {sportName} Team </h6>
            <Link to={`/teams/${teamId}`} style={{ textDecoration: 'none' }}>
              <button className="w-100 team__item-btn"> Visit Team </button>
            </Link>
          </div>
        </div>
      </Col>
  );
};

export default TeamItem;
