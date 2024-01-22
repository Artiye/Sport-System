import React from "react";
import { Col } from "reactstrap";
import { Link } from "react-router-dom";
import "../../styles/player-item.css";

const TeamItem = ({ player }) => {  
  const { id, firstName, lastName, profileUrl } = player;

  return (
    <Col lg="3" md="4" sm="6" className="mb-5">
       <Link to={`/player/${id}`} style={{ textDecoration: 'none' }}>
      <div className="player__item">
        <div className="player__img">
          <img src={profileUrl} alt="player Logo" className="w-100 rounded-circle" />
        </div>

        <div className="player__item-content mt-4">
          <h5 className="section__title text-center text-truncate text-nowrap">{firstName} {lastName}</h5>
        </div>
      </div>
      </Link>
    </Col>
  );
};

export default TeamItem;

 
