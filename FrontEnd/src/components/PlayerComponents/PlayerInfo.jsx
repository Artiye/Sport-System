import React from "react";
import "../../styles/team&tournament_settings.css";

const PlayerInfo = ({ user }) => {
  return (
    <div className="container-xl px-4 mt-4">
      <div className="row" style={{ justifyContent: "center" }}>
        <div className="col-xl-8">
          <div className="card mb-4">
            <div className="card-header text-center">Player Details</div>
            <div className="card-body">
              <form className="">
                <div className="row gx-3 mb-3">
                  <div className="col-md-6">
                    <label className="small mb-1" htmlFor="inputTeamName"> Name: </label>
                    <input
                      className="form-control" 
                      name="name"
                      value={user.firstName}
                      disabled
                    />
                  </div>    

                  <div className="col-md-6">
                    <label className="small mb-1" htmlFor="inputTeamName"> Second Name: </label>
                    <input
                      className="form-control"
                      name="shortName"
                      type="text"
                      value={user.lastName}
                      disabled
                    />
                  </div>
                </div>

                <div className="mb-3">
                  <label className="small mb-1" htmlFor="inputDescription"> Nationality: </label>
                  <input
                    className="form-control"
                    name="description"
                    type="text"
                    value={user.nationality}
                    disabled
                  />
                </div>

                <div className="mb-3">
                  <label className="small mb-1" htmlFor="inputDescription"> Gender: </label>
                  <input
                    className="form-control"
                    name="description"
                    value={user.gender}
                    disabled
                  />
                </div>

                <div className="mb-3">
                  <label className="small mb-1" htmlFor="inputDescription"> Date of Birth: </label>
                  <input
                    className="form-control"
                    name="yearFounded"
                    type="text"
                    value= {new Date(user.dateOfBirth).toISOString().split('T')[0]}
                    disabled
                  />
                </div>

              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default PlayerInfo;
