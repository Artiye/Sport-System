import React, { useEffect } from "react";
import { Routes, Route, useNavigate  } from "react-router-dom";
import NotFound from "../pages/NotFound";

const Routers = () => {
  const navigate = useNavigate();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [navigate]);

  return (
    <Routes>   
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};

export default Routers;