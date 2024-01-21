import React from "react";
import { Link } from "react-router-dom";

const TournamentItem = ({ tournament }) => {
  const { tournamentId, name, imageUrl, sportName } = tournament;

  return (
    <div className="container mt-1 mb-0">
      <div className="row">
        <div className="col-lg-12 mb-0">
          <Link to={`/tournament/${tournamentId}`} style={{ textDecoration: 'none', color: 'inherit' }}>
            <div className="card row-hover pos-relative py-3 px-3 mb-3 border-danger border-3 border-top-0 border-right-0 border-bottom-0 rounded-5">
              <div className="row align-items-center justify-content-center">

                <div className="col-md-4 op-7 pl-4">
                  <div className="row text-center op-7">
                    <div className="theImage">
                      <img
                        src={imageUrl}
                        alt="Team Logo"
                        className="img-thumbnail"
                        style={{ width: '80%', height: '120px', objectFit: 'contain' }}
                      />
                    </div>
                  </div>
                </div>

                <div className="col-md-4 mb-3 mb-sm-0 text-start">
                  <h3>
                    <p className="text-black fw-bold"> {name} </p>
                  </h3>
                  <div className="text-sm op-5">
                    <p className="text-black mr-2"> Sport: <b> {sportName} </b> </p>
                  </div>
                </div>

              </div>
            </div>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default TournamentItem;
