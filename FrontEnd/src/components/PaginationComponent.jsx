import React from "react";
import { Button } from "reactstrap";
import "../styles/pagination.css";

const PaginationComponent = ({ page, totalPages, handlePageChange }) => {
  return (
    <div className="pagination-wrapper">
      <ul className="pagination">
        {Array.from({ length: totalPages }, (_, i) => (
          <li key={i + 1} className={`page-item`}>
            <Button
              className={`${ page === i + 1 ? "pagination__active-button" : "pagination__notActive-button" }`}
              onClick={() => handlePageChange(i + 1)}
            >
              {i + 1}
            </Button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PaginationComponent;
