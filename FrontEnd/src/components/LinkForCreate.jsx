import React from "react";
import { Link } from "react-router-dom";

const LinkForCreate = ({title, link}) => {
  return (
    <div className="container mt-0 mb-2">
      <div className="row">
        <div className="col-lg-12 mb-0">
          <Link to={link} style={{ textDecoration: 'none',  color: 'inherit' }}>
            <div className="card row-hover pos-relative py-3 px-3 mb-3 border-success border-3 border-top-0 border-right-0 border-bottom-0 rounded-3">
              <div className="row align-items-center">
                
                <div className="col-md-12 mb-sm-0 text-center">
                  <h4 className="text-black m-0">
                  <i class="ri-add-circle-line"></i> {title}
                  </h4>
                </div>

              </div>
            </div>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default LinkForCreate;
